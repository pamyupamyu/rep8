using UnityEngine;
using System.Collections;

public class BTriGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 BTri_scale = transform.localScale;

        if (StateManager.BlockState[4].Equals("tri") && StateManager.BlockState[1].Equals("green"))
        {
            //float型
            BTri_scale.x = 1;
            BTri_scale.y = 1;
            BTri_scale.z = 1;
            transform.localScale = BTri_scale;
        }
        else
        {
            BTri_scale.x = 0;
            BTri_scale.y = 0;
            BTri_scale.z = 0;
            transform.localScale = BTri_scale;
        }
	}
}
