using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage : MonoBehaviour {
    public List<string> Initlist;
    public string obj;
	// Use this for initialization
	void Start () {
        Initlist.Add("ontable A");
        Initlist.Add("ontable B");
        Initlist.Add("ontable C");
        Initlist.Add("clear A");
        Initlist.Add("clear B");
        Initlist.Add("clear C");
        Initlist.Add("handEmpty");
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
