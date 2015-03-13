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
            return true;

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

        List<Light> activeHeadlights = new List<Light>();

        void Awake()
        {
        }

        void Update()
        {
            timer = GetComponent<Timer>();

            bool state = HeadlightsStateByTimeOfDay(timer.TimeOfDay);
            if (state != headlightsState)
            {
                if (state)
                {
                }
                else
                {
                    RemoveAllHeadlights();          
                }

                headlightsState = state;
            }

            if (headlightsState)
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

        public float debugSpotAngle = 30.0f;
        public float debugRange = 8.0f;
        public bool debugPoint = true;
        public float debugIntensity = 8.0f;
        public float debugDisplacement = 1.0f;
        public float debugSideOffset = 0.8f;

        Light FetchLight(LightType type, Color color, float intensity, float range, float spotAngle = 0.0f)
        {
            if (activeHeadlights.Count == 0)
            {
                var go = new GameObject();
                var newLight = go.AddComponent<Light>();
                newLight.renderMode = LightRenderMode.ForcePixel;
                newLight.shadows = LightShadows.None;
                activeHeadlights.Add(newLight);
            }

            var light = activeHeadlights[0];
            light.intensity = intensity;
            light.type = type;
            light.color = color;
            light.range = range;
            light.spotAngle = spotAngle;

            activeHeadlights.RemoveAt(0);
            return light;
        }

        void UpdateAllHeadlights()
        {
            VehicleManager vManager = Singleton<VehicleManager>.instance;

            List<Light> used = new List<Light>();

            for (int i = 0; i < vManager.m_vehicles.m_buffer.Length; i++)
            {
                Vehicle v = vManager.m_vehicles.m_buffer[i];

                if ((v.m_flags & Vehicle.Flags.Spawned) == 0)
                {
                    continue;
                }

                if (v.Info == null)
                {
                    continue;
                }

                if (v.Info.m_vehicleType != VehicleInfo.VehicleType.Car)
                {
                    continue;
                }

                Vector3 position = Vector3.zero;
                Quaternion orientation = Quaternion.identity;
                v.GetSmoothPosition((ushort)i, out position, out orientation);

                var leftHeadlight = FetchLight(LightType.Spot, Color.white, debugIntensity, debugRange, debugSpotAngle);
                var rightHeadlight = FetchLight(LightType.Spot, Color.white, debugIntensity, debugRange, debugSpotAngle);

                Vector3 forward = orientation * Vector3.forward;
                Vector3 right = orientation * Vector3.right;
                Vector3 up = orientation*Vector3.up;

                Vector3 sideOffset = right * debugSideOffset;

                leftHeadlight.enabled = true;
                leftHeadlight.transform.position = position + forward * v.Info.m_attachOffsetFront + sideOffset + up * 0.5f;
                Vector3 lookAt = position + (orientation * Vector3.forward) * 64.0f + sideOffset;
                leftHeadlight.transform.LookAt(lookAt, Vector3.up);
                used.Add(leftHeadlight);

                rightHeadlight.enabled = true;
                rightHeadlight.transform.position = position + forward * v.Info.m_attachOffsetFront - sideOffset + up * 0.5f;
                lookAt = position + (orientation * Vector3.forward) * 64.0f - sideOffset;
                rightHeadlight.transform.LookAt(lookAt, Vector3.up);
                used.Add(rightHeadlight);
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
