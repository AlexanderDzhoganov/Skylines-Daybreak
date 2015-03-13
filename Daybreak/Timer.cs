using UnityEngine;

namespace Daybreak
{
    public class Timer : MonoBehaviour
    {

        public float secondsPerTimeOfDay = 20.0f;
        public bool timerRunning = true;

        private TimeOfDay timeOfDay = TimeOfDay.Sunrise;

        private float secondsUntilNextTimeOfDay = 0.0f;

        private TimeOfDay forcedTimeOfDay = TimeOfDay.Sunrise;
        private bool forceTimeOfDay = false;

        public void ForceTimeOfDay(TimeOfDay timeOfDay)
        {
            forcedTimeOfDay = timeOfDay;
            forceTimeOfDay = true;
        }

        public void StopEnforcingTimeOfDay()
        {
            forceTimeOfDay = false;
        }

        public TimeOfDay TimeOfDay
        {
            get
            {
                if (forceTimeOfDay)
                {
                    return forcedTimeOfDay;
                }

                return timeOfDay;
            }
        }

        public float T
        {
            get { return 1.0f - secondsUntilNextTimeOfDay/secondsPerTimeOfDay; }
        }

        void Awake()
        {
            secondsUntilNextTimeOfDay = secondsPerTimeOfDay;
        }

        void Update()
        {
            if (!timerRunning)
            {
                return;
            }

            secondsUntilNextTimeOfDay -= Time.deltaTime;
            if (secondsUntilNextTimeOfDay <= 0.0f)
            {
                timeOfDay = TimeUtils.GetNextTimeOfDay(timeOfDay);
                secondsUntilNextTimeOfDay = secondsPerTimeOfDay;
            }
        }

    }

}
