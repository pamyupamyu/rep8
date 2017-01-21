using UnityEngine;
using System.Collections;

public class CTriRed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 CTri_scale = transform.localScale;

        if (StateManager.BlockState[5].Equals("tri") && StateManager.BlockState[2].Equals("red"))
        {
            //float型
            CTri_scale.x = 1;
            CTri_scale.y = 1;
            CTri_scale.z = 1;
            transform.localScale = CTri_scale;
        }
        else
        {
            CTri_scale.x = 0;
            CTri_scale.y = 0;
            CTri_scale.z = 0;
            transform.localScale = CTri_scale;
        }
    }
}
