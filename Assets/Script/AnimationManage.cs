using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManage : MonoBehaviour {
    public TimeSetting timeSetting;
    public GameObject samidare;
    private Animator anim;

	// Use this for initialization
	void Start () {
        timeSetting = GetComponent<TimeSetting>();
        anim = samidare.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeSetting.StartFlag)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;
        }
		
	}
}
