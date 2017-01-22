using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextButton : MonoBehaviour {
    public void OnClick()
    {
        GameObject.Find("InitStrage").GetComponent<Initstrage>().Initlist = GameObject.Find("InitStage").GetComponent<InitStage>().Initlist;
        SceneManager.LoadScene("Goal");
    }

 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
