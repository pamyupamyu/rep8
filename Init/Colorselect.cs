using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorselect : MonoBehaviour {

    public string color;
    public void OnValueChanged(int value)
    {
        switch (value)
        {
            case 0:
                color = "red";
                break;
            case 1:
                color = "blue";
                break;
            case 2:
                color = "green";
                break;
            default:
                break;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
