using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour {
    public Text min,sec,timeup;
    private float settingTime,minTime,secTime;
    public ButtonSetting buttonSetting;
    private bool isStart,isFirst,isEnd;

    public Button startB, stopB, resetB;

    //初回起動か
    public bool IsFirst{
        get{
            return isFirst;
        }
    }

    public bool IsStart 
    {
        get
        {
            return isStart;
        }
    }

	// Use this for initialization
	void Start () {
        buttonSetting = GetComponent<ButtonSetting>();
        startB = GameObject.Find("Start").GetComponent<Button>();
        stopB=GameObject.Find("Stop").GetComponent<Button>();
        resetB = GameObject.Find("Reset").GetComponent<Button>();

        isStart= false;
        isFirst =true;
        isEnd = false;

        if (startB == null || stopB == null || resetB == null)
            Debug.LogError("is null");
	}
	
	// Update is called once per frame
	void Update () {
        int displaySec = (int)secTime;
        int displayMin = (int)minTime;

        if (isStart && !isEnd)
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
                isEnd = true;
            }
            timeup.text = "どうさちゅう！！";
        }
        else if(!isEnd)
        {
            timeup.text = "たいきちゅう！！";
        }

        if(isEnd){
            timeup.text = "おしまい！！";
           // endFlag = true;
            isStart = false;
        }
        //int displayTime = (int)settingTime;
        //sec.text = displayTime.ToString("D2");

        


        if (!isStart && !isEnd)
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
        if (isFirst)
        {
            settingTime = (buttonSetting.TimerMin * 60) + (buttonSetting.TimerSec);
            minTime = buttonSetting.TimerMin;
            secTime = buttonSetting.TimerSec;
            isFirst = false;
            isStart = true;
            Debug.Log("_____"+settingTime);
        }
        else
        {
            isStart = true;
        }

    }

    public void StopTimer()
    {
        isStart = false;
        isEnd = false;
    }

    public void ResetTimer()
    {
        isFirst = true;
        isStart = false;

        buttonSetting.TimerMin = 3;
        buttonSetting.TimerSec = 0;

    }
}
