using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer
{
    public static void TimeClock(TimeModel timeData)
    {
        if (timeData.timegget == "00:00:00")
        {
            float t = Time.time - timeData.timeToDisplay;

            timeData.second = Mathf.FloorToInt(t % 3600 % 60);
            timeData.minute = Mathf.FloorToInt(t % 3600 / 60);
            timeData.hour = Mathf.FloorToInt(t / 3600);

            timeData.txt_time.text = ((timeData.hour < 10) ? "0" + timeData.hour : timeData.hour.ToString()) + ":" +
                ((timeData.minute < 10) ? "0" + timeData.minute : timeData.minute.ToString()) + ":" +
                ((timeData.second < 10) ? "0" + timeData.second : timeData.second.ToString());
        }
        else if (timeData.timegget != "00:00:00")
        {
            float tsecond = (float.Parse(timeData.timegget.Substring(0, 2)) * 3600 +
                float.Parse(timeData.timegget.Substring(3, 2)) * 60 + float.Parse(timeData.timegget.Substring(6, 2)));
            float t = (tsecond + Time.time) - timeData.timeToDisplay;

            timeData.second = Mathf.FloorToInt(t % 3600 % 60);
            timeData.minute = Mathf.FloorToInt(t % 3600 / 60);
            timeData.hour = Mathf.FloorToInt(t / 3600);

            timeData.txt_time.text = ((timeData.hour < 10) ? "0" + timeData.hour : timeData.hour.ToString()) + ":" +
                ((timeData.minute < 10) ? "0" + timeData.minute : timeData.minute.ToString()) + ":" + ((timeData.second < 10) ? "0" +
                timeData.second : timeData.second.ToString());
        }
    }
}
