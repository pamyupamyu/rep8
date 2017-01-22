using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour {
    public Dropdown colorselect;
    public Dropdown shapeselect;
    public GameObject AICube;
    public GameObject BICube;
    public GameObject CICube;
    public GameObject AITriangle;
    public GameObject BITriangle;
    public GameObject CITriangle;
    int count=0;
    Vector3 position;
    public void OnClick()
    {
        count++;
        if (count < 4)
        {

            switch(count){
               case 1:
                    position = new Vector3(400, 15, -78);
                    break;
                case 2:
                    position = new Vector3(320, 15, -78);
                    break;
                case 3:
                    position = new Vector3(480, 15, -78);
                    break;   
            }

            switch (colorselect.value)
            {
                //redのとき
                case 0:
                    if (shapeselect.value == 0)
                    {
                        Instantiate(AICube, position, transform.rotation);
                    }
                    else if (shapeselect.value == 1)
                    {

                        Instantiate(AITriangle, transform.position, transform.rotation);
                    }
                    break;
                case 1:
                    if (shapeselect.value == 0)
                    {
                        Instantiate(BICube, position, transform.rotation);
                    }
                    else if (shapeselect.value == 1)
                    {
                        Instantiate(BITriangle, transform.position, transform.rotation);
                    }
                    break;
                case 2:
                    if (shapeselect.value == 0)
                    {
                        Instantiate(CICube, position, transform.rotation);
                    }
                    else if (shapeselect.value == 1)
                    {
                        Instantiate(CITriangle, transform.position, transform.rotation);
                    }
                    break;
                default:
                    break;

            }
        }
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
