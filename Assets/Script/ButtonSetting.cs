using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : MonoBehaviour {
    public Text min,sec;
    private int timerMin,timerSec;
    public TimeSetting timeSetting;

    public int TimerMin
    {
        get
        {
            return timerMin;
        }
        set
        {
            timerMin = value;
        }
    }

    public int TimerSec
    {
        get
        {
            return timerSec;
        }
        set
        {
            timerSec = value;
        }
    }

	// Use this for initialization
	void Start () {
        timerMin = 3;
        timerSec = 0;
        min.text = timerMin.ToString("D2");
        sec.text = timerSec.ToString("D2");

        timeSetting = GetComponent<TimeSetting>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timeSetting.FirstFlag)
        {
            min.text = timerMin.ToString("D2");
            sec.text = timerSec.ToString("D2");
        }
		
	}

    public void TimeSet(int i)
    {
        switch (i)
        {
            case 0:
                if(timerMin <= 59)
                    timerMin++;
                break;
            case 1:
                if(timerMin > 0)
                    timerMin--;
                break;
            case 2:
                if(timerSec <= 50)
                    timerSec += 10;
                if (timerSec >= 60)
                    timerSec = 0;
                break;
            case 3:
                if(timerSec > 0)
                    timerSec -= 10;
                break;
        }
    }

}
