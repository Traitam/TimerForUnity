using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour {
    public Text min,sec,timeup;
    private float settingTime,minTime,secTime;
    public ButtonSetting buttonSetting;
    private bool startFlag,firstFlag,endFlag;

    public Button startB, stopB, resetB;

    public bool FirstFlag{
        get{
            return firstFlag;
        }
    }

    public bool StartFlag
    {
        get
        {
            return startFlag;
        }
    }

	// Use this for initialization
	void Start () {
        buttonSetting = GetComponent<ButtonSetting>();
        startB = GameObject.Find("Start").GetComponent<Button>();
        stopB=GameObject.Find("Stop").GetComponent<Button>();
        resetB = GameObject.Find("Reset").GetComponent<Button>();

        startFlag= false;
        firstFlag =true;
        endFlag = false;

        if (startB == null || stopB == null || resetB == null)
            Debug.LogError("is null");
	}
	
	// Update is called once per frame
	void Update () {
        int displaySec = (int)secTime;
        int displayMin = (int)minTime;

        if (startFlag && !endFlag)
        {
            settingTime -= Time.deltaTime;
            secTime -= Time.deltaTime;
            sec.text = displaySec.ToString("D2");
            min.text = displayMin.ToString("D2");

            if (secTime <= 0 && minTime >= 1)
            {
                minTime--;
                secTime = 60;
            }
            else if (minTime == 0 && secTime <= 0)
            {
                endFlag = true;
            }
            timeup.text = "どうさちゅう！！";
        }
        else if(!endFlag)
        {
            timeup.text = "たいきちゅう！！";
        }

        if(endFlag){
            timeup.text = "おしまい！！";
           // endFlag = true;
            startFlag = false;
        }
        //int displayTime = (int)settingTime;
        //sec.text = displayTime.ToString("D2");

        


        if (!startFlag && !endFlag)
        {
            startB.interactable = true;
            stopB.interactable = false;
            resetB.interactable = true;
        }
        else
        {
            startB.interactable = false;
            stopB.interactable = true;
            resetB.interactable = false;
        }

	}

    public void StartTimer()
    {
        if (firstFlag)
        {
            settingTime = (buttonSetting.TimerMin * 60) + (buttonSetting.TimerSec);
            minTime = buttonSetting.TimerMin;
            secTime = buttonSetting.TimerSec;
            firstFlag = false;
            startFlag = true;
            Debug.Log("_____"+settingTime);
        }
        else
        {
            startFlag = true;
        }

    }

    public void StopTimer()
    {
        startFlag = false;
        endFlag = false;
    }

    public void ResetTimer()
    {
        firstFlag = true;
        startFlag = false;

        buttonSetting.TimerMin = 3;
        buttonSetting.TimerSec = 0;

    }
}
