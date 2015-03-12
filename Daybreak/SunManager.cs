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

        void Awake()
        {
            
        }

        void Update()
        {
            
        }

    }

}
