using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer
{
    //ham tinh thoi gian
    public static void TimeClock(TimeModel timeData)
    {
        //gia su thoi gian dau vao la 00:00:00
        if (timeData.timegget == "00:00:00")
        {
            //thoi gian + them theo moi deltatime
            float t = timeData.timeToDisplay += Time.deltaTime;
            //tinh gio/ phut/ giay
            timeData.second = Mathf.FloorToInt(t % 3600 % 60);
            timeData.minute = Mathf.FloorToInt(t % 3600 / 60);
            timeData.hour = Mathf.FloorToInt(t / 3600);
            //gan time vao text neu time <10 thi hien 0 o phia truoc
            timeData.txt_time.text = ((timeData.hour < 10) ? "0" + timeData.hour : timeData.hour.ToString()) + ":" +
                ((timeData.minute < 10) ? "0" + timeData.minute : timeData.minute.ToString()) + ":" +
                ((timeData.second < 10) ? "0" + timeData.second : timeData.second.ToString());
        }
        //gia su thoi gian dau vao kha 00:00:00
        else if (timeData.timegget != "00:00:00")
        {
            //lay thoi gian dau vao theo gio/ phut/ giay
            float tsecond = (float.Parse(timeData.timegget.Substring(0, 2)) * 3600 +
                float.Parse(timeData.timegget.Substring(3, 2)) * 60 + float.Parse(timeData.timegget.Substring(6, 2)));
            float t = timeData.timeToDisplay = tsecond;
            //thoi gian + them theo moi deltatime
            t += Time.deltaTime;
            //tinh gio/ phut/ giay
            timeData.second = Mathf.FloorToInt(t % 3600 % 60);
            timeData.minute = Mathf.FloorToInt(t % 3600 / 60);
            timeData.hour = Mathf.FloorToInt(t / 3600);
            //gan time vao text neu time <10 thi hien 0 o phia truoc
            timeData.txt_time.text = ((timeData.hour < 10) ? "0" + timeData.hour : timeData.hour.ToString()) + ":" +
                ((timeData.minute < 10) ? "0" + timeData.minute : timeData.minute.ToString()) + ":" + ((timeData.second < 10) ? "0" +
                timeData.second : timeData.second.ToString());
        }
    }
}
