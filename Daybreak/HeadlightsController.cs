using System;
using System.Collections.Generic;
using ColossalFramework;
using UnityEngine;

namespace Daybreak
{
    public class HeadlightsController : MonoBehaviour
    {

        public static bool HeadlightsStateByTimeOfDay(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Sunset:
                case TimeOfDay.Night:
                case TimeOfDay.LateNight:
                    return true;
            }

            return false;
        }

        private Timer timer;
        private bool headlightsState = false;

        public List<LightSource> activeHeadlights = new List<LightSource>();

        private bool fadingInHeadlights = false;
        private bool fadingOutHeadlights = false;
        private float fadingHeadlightsFactor = 1.0f;

        void Awake()
        {
        }

        void FadeInHeadlights()
        {
            fadingInHeadlights = true;
            fadingOutHeadlights = false;
        }

        void FadeOutHeadlights()
        {
            fadingOutHeadlights = true;
            fadingInHeadlights = false;
        }

        void LateUpdate()
        {
            timer = GetComponent<Timer>();

            bool state = HeadlightsStateByTimeOfDay(timer.TimeOfDay);
            if (state != headlightsState)
            {
                if (state)
                {
                    FadeInHeadlights();
                }
                else
                {
                    FadeOutHeadlights();
                }

                headlightsState = state;
            }

            if (fadingInHeadlights)
            {
                fadingHeadlightsFactor += Time.deltaTime;
                if (fadingHeadlightsFactor >= 1.0f)
                {
                    fadingHeadlightsFactor = 1.0f;
                    fadingInHeadlights = false;
                }
            }
            else if (fadingOutHeadlights)
            {
                fadingHeadlightsFactor -= Time.deltaTime;
                if (fadingHeadlightsFactor <= 0.0f)
                {
                    fadingHeadlightsFactor = 0.0f;
                    fadingOutHeadlights = false;
                    RemoveAllHeadlights();
                }
            }

            if (fadingInHeadlights || fadingOutHeadlights || headlightsState)
            {
                try
                {
                    UpdateAllHeadlights();
                }
                catch (Exception ex)
                {
                    Log.Error("Exception: " + ex.Message);
                }
            }
        }

        void RemoveAllHeadlights()
        {
            foreach (var item in activeHeadlights)
            {
                item.enabled = false;
            }
        }

        public static float headlightSpotAngle = 68.0f;
        private static float headlightRange = 10.5f;
        private static float headlightIntensity = 3.0f;

        LightSource FetchLight(LightType type, Color color, float intensity, float range, float spotAngle = 0.0f)
        {
            LightSource light = null;

            if (activeHeadlights.Count == 0)
            {
                light = Singleton<RenderManager>.instance.ObtainLightSource();
            }
            else
            {
                light = activeHeadlights[0];
                activeHeadlights.RemoveAt(0);
            }

            light.m_light.intensity = intensity*fadingHeadlightsFactor;
            light.m_light.type = type;
            light.m_light.color = color;
            light.m_light.range = range;
            light.m_light.spotAngle = spotAngle;
            light.m_light.shadows = LightShadows.None;
            light.enabled = true;

            return light;
        }

        void UpdateAllHeadlights()
        {
            VehicleManager vManager = Singleton<VehicleManager>.instance;

            List<LightSource> used = new List<LightSource>();

            for (int i = 0; i < vManager.m_vehicles.m_buffer.Length; i++)
            {
                if((vManager.m_vehicles.m_buffer[i].m_flags & (Vehicle.Flags.Created | Vehicle.Flags.Deleted)) != Vehicle.Flags.Created)
                {
                    continue;
                }

                Vehicle v = vManager.m_vehicles.m_buffer[i];

                if (v.Info.m_vehicleType != VehicleInfo.VehicleType.Car)
                {
                    continue;
                }

                Vector3 position = Vector3.zero;
                Quaternion orientation = Quaternion.identity;
                v.GetSmoothPosition((ushort)i, out position, out orientation);

                var headlight = FetchLight(LightType.Spot, Color.white, headlightIntensity, headlightRange, headlightSpotAngle);

                Vector3 forward = orientation * Vector3.forward;
                Vector3 right = orientation * Vector3.right;
                Vector3 up = orientation*Vector3.up;

                headlight.transform.position = position + forward*v.Info.m_attachOffsetFront*2.0f + up;
                Vector3 lookAt = position + (orientation * Vector3.forward) * 64.0f;
                headlight.transform.LookAt(lookAt, Vector3.up);
                used.Add(headlight);
            }

            foreach (var light in activeHeadlights)
            {
                light.enabled = false;
            }

            foreach (var light in used)
            {
                activeHeadlights.Add(light);
            }
        }

    }

}
