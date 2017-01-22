using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgButton : MonoBehaviour {
    GoalStage goalstage;
    public void OnClick()
    {
        goalstage.obj = "A";
        //Debug.Log("AButton Clicked!");
        Debug.Log(goalstage.obj);
    }
    // Use this for initialization
    void Start () {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
