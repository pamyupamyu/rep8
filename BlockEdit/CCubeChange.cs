using UnityEngine;
using System.Collections;

public class CCubeChange : MonoBehaviour
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
        if (StateManager.BlockState[2].Equals("red"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (StateManager.BlockState[2].Equals("blue"))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (StateManager.BlockState[2].Equals("green"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        Vector3 CCube_scale = transform.localScale;
        if (StateManager.BlockState[5].Equals("cube"))
        {
            //float型
            CCube_scale.x = 2;
            CCube_scale.y = 2;
            CCube_scale.z = 2;
            transform.localScale = CCube_scale;
        }
        else if (StateManager.BlockState[5].Equals("tri"))
        {
            CCube_scale.x = 0;
            CCube_scale.y = 0;
            CCube_scale.z = 0;
            transform.localScale = CCube_scale;
        }

    }
}

