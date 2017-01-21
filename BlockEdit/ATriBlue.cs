using UnityEngine;
using System.Collections;

public class ATriBlue : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ATri_scale = transform.localScale;

        if (StateManager.BlockState[3].Equals("tri") && StateManager.BlockState[0].Equals("blue"))
        {
            //float型
            ATri_scale.x = 1;
            ATri_scale.y = 1;
            ATri_scale.z = 1;
            transform.localScale = ATri_scale;
        }
        else
        {
            ATri_scale.x = 0;
            ATri_scale.y = 0;
            ATri_scale.z = 0;
            transform.localScale = ATri_scale;
        }

    }
}


