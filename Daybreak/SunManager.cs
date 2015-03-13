using System;
using UnityEngine;

namespace Daybreak
{
    public class SunManager : MonoBehaviour
    {

        public static Vector3 GetSunDirectionByTimeOfDay(TimeOfDay timeOfDay)
        {
            return Vector3.up;
        }

        public static Vector3 GetSunDirectionByTimeOfDay(TimeOfDay timeOfDay, float t)
        {
            var dirA = GetSunDirectionByTimeOfDay(timeOfDay);
            var dirB = GetSunDirectionByTimeOfDay(TimeUtils.GetNextTimeOfDay(timeOfDay));
            return Vector3.Lerp(dirA, dirB, t);
        }

        public static Color GetSunColorByTimeOfDay(TimeOfDay timeOfDay)
        {
            return Color.black;
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
                    return XKCDColors.LightBlue;
                case TimeOfDay.Morning:
                    return XKCDColors.BrightLightBlue;
                case TimeOfDay.Noon:
                    return XKCDColors.SunYellow;
                case TimeOfDay.Afternoon:
                    return XKCDColors.OrangeYellow;
                case TimeOfDay.Sunset:
                    return XKCDColors.FadedOrange;
                case TimeOfDay.Night:
                    return XKCDColors.DarkBlueGrey;
                case TimeOfDay.LateNight:
                    return XKCDColors.AlmostBlack;
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

        void Awake()
        {
            timer = GetComponent<Timer>();
        }

        void Update()
        {
            RenderSettings.ambientIntensity = 1.0f;
            RenderSettings.ambientLight = GetAmbientColorByTimeOfDay(timer.TimeOfDay, timer.T);
        }

    }

}
