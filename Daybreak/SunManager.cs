using System;
using ColossalFramework;
using UnityEngine;
using UnityEngine.Rendering;

namespace Daybreak
{
    public class SunManager : MonoBehaviour
    {

        private static readonly float GlobalAmbientIntensity = 0.3f;
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
                    return XKCDColors.OffWhite * 0.7f;
                case TimeOfDay.Sunset:
                    return XKCDColors.Yellowish * 0.3f;
                case TimeOfDay.Night:
                    return Color.black;
                case TimeOfDay.LateNight:
                    return Color.black;
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
                    return XKCDColors.LightBlue * 0.6f;
                case TimeOfDay.Morning:
                    return XKCDColors.LightBlue * 0.9f;
                case TimeOfDay.Noon:
                    return XKCDColors.SunYellow * 1.0f;
                case TimeOfDay.Afternoon:
                    return XKCDColors.OrangeYellow * 0.7f;
                case TimeOfDay.Sunset:
                    return XKCDColors.FadedOrange * 0.3f;
                case TimeOfDay.Night:
                    return XKCDColors.DarkBlueGrey * 0.1f;
                case TimeOfDay.LateNight:
                    return XKCDColors.AlmostBlack * 0.05f;
            }

            return Color.magenta;
        }

        public static Color GetAmbientColorByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var colorA = GetAmbientColorByTimeOfDay(timeOfDay);
            var colorB = GetAmbientColorByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Color.Lerp(colorA, colorB, t);
        }

        private Timer timer;
        private Light light;

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

            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientIntensity = GlobalAmbientIntensity;
            RenderSettings.ambientLight = GetAmbientColorByTimeOfDay(timer.TimeOfDay, timer.T);

            light.color = GetSunColorByTimeOfDay(timer.TimeOfDay, timer.T);
            light.intensity = GlobalSunIntensity;

            var sunDirection = GetSunDirectionByTimeOfDay(timer.TimeOfDay, timer.T);
            light.transform.rotation = Quaternion.LookRotation(sunDirection, Vector3.up);
        }

    }

}
