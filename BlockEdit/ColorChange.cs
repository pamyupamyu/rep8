using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //gameObject取得 
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update () {
        if (StateManager.BlockState[0].Equals("red"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (StateManager.BlockState[0].Equals("blue"))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (StateManager.BlockState[0].Equals("green"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	
	}
}
