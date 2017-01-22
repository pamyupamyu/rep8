using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgButton : MonoBehaviour {
    GoalStage goalstage;
    public void OnClick()
    {
        goalstage.obj = "B";
        //Debug.Log("AButton Clicked!");
        //Debug.Log(initstage.obj);
    }
    // Use this for initialization
    void Start () {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
