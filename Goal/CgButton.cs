using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CgButton : MonoBehaviour {
    GoalStage goalstage;

    public void OnClick()
    {
        goalstage.obj = "C";
        Debug.Log("C");
        
    }
    // Use this for initialization
    void Start () {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
