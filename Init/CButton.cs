using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CButton : MonoBehaviour {
    InitStage initstage;

    public void OnClick ()
    {
        initstage.obj = "C";
        //Debug.Log(initstage.obj);
    }

	// Use this for initialization
	void Start () {
        initstage = GameObject.Find("InitStage").GetComponent<InitStage>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
