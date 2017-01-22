using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextgButton : MonoBehaviour {

    public void OnClick()
    {
        //GameObject.Find("GoalStrage").GetComponent<Goalstrage>().Initlist = GameObject.Find("InitStrage").GetComponent<Initstrage>().Initlist;
        GameObject.Find("GoalStrage").GetComponent<Goalstrage>().Goallist = GameObject.Find("GoalStage").GetComponent<GoalStage>().Goallist;
        SceneManager.LoadScene("Mainscene");
        //goallist = goalstage.Goallist;
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
