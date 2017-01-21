using UnityEngine;
using System.Collections;

public class ACubeChange : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

// Update is called once per frame
void Update()
    {
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

        Vector3 ACube_scale = transform.localScale;
        if (StateManager.BlockState[3].Equals("cube"))
        {
            //float型
            ACube_scale.x = 2;
            ACube_scale.y = 2;
            ACube_scale.z = 2;
            transform.localScale = ACube_scale;
        }
        else if (StateManager.BlockState[3].Equals("tri"))
        {
            ACube_scale.x = 0;
            ACube_scale.y = 0;
            ACube_scale.z = 0;
            transform.localScale = ACube_scale;
        }

    }
}
