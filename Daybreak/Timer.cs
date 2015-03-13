using UnityEngine;

namespace Daybreak
{
    public class Timer : MonoBehaviour
    {

        public float secondsPerTimeOfDay = 20.0f;
        public bool timerRunning = true;

        private TimeOfDay timeOfDay = TimeOfDay.Sunrise;

        private float secondsUntilNextTimeOfDay = 0.0f;

        public TimeOfDay TimeOfDay
        {
            get
            {
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
