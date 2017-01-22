using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStage : MonoBehaviour {
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    public List<string> Goallist;

    public string obj;
    
	// Use this for initialization
   

    

    void Start () {
        
        Goallist.Add("ontable C");
        Goallist.Add("ontable B");
        Goallist.Add("ontable A");
        Goallist.Add("clear A");
        Goallist.Add("clear B");
        Goallist.Add("clear C");
        Goallist.Add("handEmpty");
        
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
        }
    // Update is called once per frame
    void Update () {
      
    }

   
}
