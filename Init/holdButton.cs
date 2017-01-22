using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdButton : MonoBehaviour {

    InitStage initstage;
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    List<string> initstate;

  

    public void OnClick()
    {
        pick(initstage.obj);

    }

    // Use this for initialization
    void Start()
    {
        initstage = GameObject.Find("InitStage").GetComponent<InitStage>();
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
        initstate = initstage.Initlist;

    }

    // Update is called once per frame
    void Update()
    {

    }


    /*
         * initstate中にmatchがあるときtrueを返す
         */
    bool match_list(List<string> initstate, string match)

    {
        bool C = false;
        foreach (string s in initstate)
        {
            string temp = s;
            if (temp.Equals(match))
            {
                //System.out.println("OK");
                C = true;
            }
        }
        return C;
    }


    void pick(string block)
    {
        if (block.Equals("A"))
        {
            if (match_list(initstate, "clear A") && match_list(initstate, "handEmpty"))
            {
                A.x = 260;
                A.y = 90;
                initstate.Remove("handEmpty");
                initstate.Add("holding A");
                if (match_list(initstate, "ontable A"))
                {
                    initstate.Remove("ontable A");
                }
                else if (match_list(initstate, "A on B"))
                {
                    initstate.Remove("A on B");
                    initstate.Add("clear B");
                }
                else if (match_list(initstate, "A on C"))
                {
                    initstate.Remove("A on C");
                    initstate.Add("clear C");
                }
                ACube.transform.position = A;
                //debug(initstate);
            }
        }
        else if (block.Equals("B"))
        {
            if (match_list(initstate, "clear B") && match_list(initstate, "handEmpty"))
            {
                B.x = 260;
                B.y = 90;
                initstate.Remove("handEmpty");
                initstate.Add("holding B");
                if (match_list(initstate, "ontable B"))
                {
                    initstate.Remove("ontable B");
                }
                else if (match_list(initstate, "B on A"))
                {
                    initstate.Remove("B on A");
                    initstate.Add("clear A");
                }
                else if (match_list(initstate, "B on C"))
                {
                    initstate.Remove("B on C");
                    initstate.Add("clear C");
                }
                BCube.transform.position = B;
                //debug(initstate);
            }
        }
        else if (block.Equals("C"))
        {
            if (match_list(initstate, "clear C") && match_list(initstate, "handEmpty"))
            {
                C.x = 260;
                C.y = 90;
                initstate.Remove("handEmpty");
                initstate.Add("holding C");
                if (match_list(initstate, "ontable C"))
                {
                    initstate.Remove("ontable C");
                }
                else if (match_list(initstate, "C on A"))
                {
                    initstate.Remove("C on A");
                    initstate.Add("clear A");
                }
                else if (match_list(initstate, "C on B"))
                {
                    initstate.Remove("C on B");
                    initstate.Add("clear B");
                }
                CCube.transform.position = C;
                //debug(initstate);
            }
        }
    }

 
}
