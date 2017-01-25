using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private Vector3 A_loc;

    // Use this for initialization
    void Start()
    {
        A_loc = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
            A_loc.y += 0.2f;
            transform.localEulerAngles = A_loc;
        
    }
}
