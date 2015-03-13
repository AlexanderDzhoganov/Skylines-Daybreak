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
                UpdateAllHeadlights();
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

        void UpdateAllHeadlights()
        {
            VehicleManager vManager = Singleton<VehicleManager>.instance;

            List<Light> used = new List<Light>();

            for (int i = 0; i < vManager.m_vehicleCount; i++)
            {
                Vehicle v = vManager.m_vehicles.m_buffer[i];
                Vector3 position = Vector3.zero;
                Quaternion orientation = Quaternion.identity;
                v.GetSmoothPosition(0, out position, out orientation);

                if (activeHeadlights.Count == 0)
                {
                    var go = new GameObject();
                    var newLight = go.AddComponent<Light>();

                    newLight.intensity = 8.0f;
                    newLight.type = LightType.Point;
                    newLight.color = XKCDColors.Magenta;
                    newLight.range = 16.0f;
                    newLight.renderMode = LightRenderMode.ForcePixel;
                    newLight.shadows = LightShadows.None;
                    activeHeadlights.Add(newLight);
                }

                var light = activeHeadlights[0];
                activeHeadlights.RemoveAt(0);

                light.type = debugPoint ? LightType.Point : LightType.Spot;
                light.spotAngle = debugSpotAngle;
                light.range = debugRange;
                light.intensity = debugIntensity;
                
                used.Add(light);
                light.enabled = true;
                light.transform.position = position + Vector3.up*0.10f;// + (orientation * Vector3.forward) * debugDisplacement;

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
