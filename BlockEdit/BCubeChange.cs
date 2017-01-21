using UnityEngine;
using System.Collections;

public class BCubeChange : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //gameObject取得 
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.BlockState[1].Equals("red"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (StateManager.BlockState[1].Equals("blue"))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (StateManager.BlockState[1].Equals("green"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        Vector3 BCube_scale = transform.localScale;
        if (StateManager.BlockState[4].Equals("cube"))
        {
            //float型
            BCube_scale.x = 2;
            BCube_scale.y = 2;
            BCube_scale.z = 2;
            transform.localScale = BCube_scale;
        }
        else if (StateManager.BlockState[4].Equals("tri"))
        {
            BCube_scale.x = 0;
            BCube_scale.y = 0;
            BCube_scale.z = 0;
            transform.localScale = BCube_scale;
        }


    }
}

