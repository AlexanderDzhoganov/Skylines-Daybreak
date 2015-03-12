using System;
using System.Collections.Generic;
using System.Text;

namespace Daybreak
{

    public enum TimeOfDay
    {
        Sunrise = 0,
        Morning = 1,
        Noon = 2,
        Afternoon = 3,
        Sunset = 4,
        Night = 5,
        LateNight = 6
    }

    public static class TimeUtils
    {

        public static TimeOfDay GetNextTimeOfDay(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Sunrise:
                    return TimeOfDay.Morning;
                case TimeOfDay.Morning:
                    return TimeOfDay.Noon;
                case TimeOfDay.Noon:
                    return TimeOfDay.Afternoon;
                case TimeOfDay.Afternoon:
                    return TimeOfDay.Sunset;
                case TimeOfDay.Sunset:
                    return TimeOfDay.Night;
                case TimeOfDay.Night:
                    return TimeOfDay.LateNight;
                case TimeOfDay.LateNight:
                    return TimeOfDay.Sunrise;
            }

            return TimeOfDay.Sunrise;
        }

    }

}
