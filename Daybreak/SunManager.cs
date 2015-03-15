using System;
using ColossalFramework;
using UnityEngine;
using UnityEngine.Rendering;

namespace Daybreak
{
    public class SunManager : MonoBehaviour
    {

        private static readonly float GlobalAmbientIntensity = 1.0f;
        private static readonly float GlobalSunIntensity = 1.0f;

        public static Vector3 GetSunDirectionByTimeOfDay(TimeOfDay timeOfDay)
        {
            Vector3 dir = Vector3.up;

            switch (timeOfDay)
            {
                case TimeOfDay.Sunrise:
                    dir = new Vector3(1.0f, 0.0f, 0.0f);
                    break;
                case TimeOfDay.Morning:
                    dir = new Vector3(1.0f, -1.0f, 0.0f);
                    break;
                case TimeOfDay.Noon:
                    dir = new Vector3(0.0f, -1.0f, 0.0f);
                    break;
                case TimeOfDay.Afternoon:
                    dir = new Vector3(-1.0f, -1.0f, 0.0f);
                    break;
                case TimeOfDay.Sunset:
                    dir = new Vector3(-1.0f, 0.0f, 0.0f);
                    break;
                case TimeOfDay.Night:
                    break;
                case TimeOfDay.LateNight:
                    break;
            }

            return Vector3.Normalize(dir);
        }

        public static Vector3 GetSunDirectionByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var dirA = GetSunDirectionByTimeOfDay(timeOfDay);
            var dirB = GetSunDirectionByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Vector3.Slerp(dirA, dirB, t);
        }

        public static Color GetSunColorByTimeOfDay(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Sunrise:
                    return XKCDColors.VeryLightBlue * 0.6f;
                case TimeOfDay.Morning:
                    return XKCDColors.VeryLightBlue * 0.9f;
                case TimeOfDay.Noon:
                    return XKCDColors.White * 1.0f;
                case TimeOfDay.Afternoon:
                    return XKCDColors.OffWhite * 0.6f;
                case TimeOfDay.Sunset:
                    return XKCDColors.Yellowish * 0.4f;
                case TimeOfDay.Night:
                    return XKCDColors.Black;
                case TimeOfDay.LateNight:
                    return XKCDColors.Black;
            }

            return Color.magenta;
        }

        public static Color GetSunColorByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var colorA = GetSunColorByTimeOfDay(timeOfDay);
            var colorB = GetSunColorByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Color.Lerp(colorA, colorB, t);
        }

        public static Color GetAmbientColorByTimeOfDay(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Sunrise:
                    return XKCDColors.VeryLightBlue * 0.6f;
                case TimeOfDay.Morning:
                    return XKCDColors.VeryLightBlue * 0.9f;
                case TimeOfDay.Noon:
                    return XKCDColors.White * 1.0f;
                case TimeOfDay.Afternoon:
                    return XKCDColors.OffWhite * 0.6f;
                case TimeOfDay.Sunset:
                    return XKCDColors.Yellowish * 0.4f;
                case TimeOfDay.Night:
                    return XKCDColors.BluishPurple;
                case TimeOfDay.LateNight:
                    return XKCDColors.DarkSkyBlue;
            }

            return Color.magenta;
        }

        public static Color GetAmbientColorByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var colorA = GetAmbientColorByTimeOfDay(timeOfDay);
            var colorB = GetAmbientColorByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Color.Lerp(colorA, colorB, t);
        }

        public static Color GetFogColorByTimeOfDay(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Sunrise:
                    return XKCDColors.VeryLightBlue * 0.6f;
                case TimeOfDay.Morning:
                    return XKCDColors.VeryLightBlue * 0.9f;
                case TimeOfDay.Noon:
                    return XKCDColors.White * 1.0f;
                case TimeOfDay.Afternoon:
                    return XKCDColors.OffWhite * 0.6f;
                case TimeOfDay.Sunset:
                    return XKCDColors.Yellowish * 0.4f;
                case TimeOfDay.Night:
                    return XKCDColors.Black;
                case TimeOfDay.LateNight:
                    return XKCDColors.Black;
            }

            return Color.magenta;
        }

        public static Color GetFogColorByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var colorA = GetFogColorByTimeOfDay(timeOfDay);
            var colorB = GetFogColorByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Color.Lerp(colorA, colorB, t);
        }

        private Timer timer;
        private Light light;
        private RenderProperties renderProperties;

        void Update()
        {
            if (timer == null)
            {
                timer = GetComponent<Timer>();
            }

            if (light == null)
            {
                var lights = FindObjectsOfType<Light>();
                foreach (var _light in lights)
                {
                    if (_light.type == LightType.Directional)
                    {
                        light = _light;
                        break;
                    }
                }
            }

            if (renderProperties == null)
            {
                renderProperties = FindObjectOfType<RenderProperties>();
            }

            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientIntensity = GlobalAmbientIntensity;
            RenderSettings.ambientGroundColor = GetAmbientColorByTimeOfDay(timer.TimeOfDay, timer.T);
            RenderSettings.ambientLight = Color.black;
            RenderSettings.ambientSkyColor = GetAmbientColorByTimeOfDay(timer.TimeOfDay, timer.T);
            RenderSettings.customReflection = null;

            renderProperties.m_ambientLight = RenderSettings.ambientSkyColor;
            renderProperties.m_fogColor = GetFogColorByTimeOfDay(timer.TimeOfDay, timer.T);
            renderProperties.m_volumeFogColor = GetFogColorByTimeOfDay(timer.TimeOfDay, timer.T);
            renderProperties.m_pollutionFogColor = GetFogColorByTimeOfDay(timer.TimeOfDay, timer.T);

            light.color = GetSunColorByTimeOfDay(timer.TimeOfDay, timer.T);
            renderProperties.m_inscatteringColor = light.color;

            light.intensity = GlobalSunIntensity;

            var sunDirection = GetSunDirectionByTimeOfDay(timer.TimeOfDay, timer.T);
            light.transform.rotation = Quaternion.LookRotation(sunDirection, Vector3.up);
        }

    }

}
