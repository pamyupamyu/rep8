using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdgButton : MonoBehaviour {

    GoalStage goalstage;
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    List<string> state;



    public void OnClick()
    {
        pick(goalstage.obj);
        foreach (string element in state)
        {
            Debug.Log(element);
        }

    }

    // Use this for initialization
    void Start()
    {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
        //state = GoalStage.Goallist;
        state = goalstage.Goallist;
        //state = GoalStage.getGoallist();
    }

    // Update is called once per frame
    void Update()
    {
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
    }


    /*
         * state中にmatchがあるときtrueを返す
         */
    bool match_list(List<string> state, string match)

    {
        bool C = false;
        foreach (string s in state)
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
            if (match_list(state, "clear A") && match_list(state, "handEmpty"))
            {
                A.x = 260;
                A.y = 90;
                state.Remove("handEmpty");
                state.Add("holding A");
                if (match_list(state, "ontable A"))
                {
                    state.Remove("ontable A");
                }
                else if (match_list(state, "A on B"))
                {
                    state.Remove("A on B");
                    state.Add("clear B");
                }
                else if (match_list(state, "A on C"))
                {
                    state.Remove("A on C");
                    state.Add("clear C");
                }
                ACube.transform.position = A;
                //debug(state);
            }
        }
        else if (block.Equals("B"))
        {
            if (match_list(state, "clear B") && match_list(state, "handEmpty"))
            {
                B.x = 260;
                B.y = 90;
                state.Remove("handEmpty");
                state.Add("holding B");
                if (match_list(state, "ontable B"))
                {
                    state.Remove("ontable B");
                }
                else if (match_list(state, "B on A"))
                {
                    state.Remove("B on A");
                    state.Add("clear A");
                }
                else if (match_list(state, "B on C"))
                {
                    state.Remove("B on C");
                    state.Add("clear C");
                }
                BCube.transform.position = B;
                //debug(state);
            }
        }
        else if (block.Equals("C"))
        {
            if (match_list(state, "clear C") && match_list(state, "handEmpty"))
            {
                C.x = 260;
                C.y = 90;
                state.Remove("handEmpty");
                state.Add("holding C");
                if (match_list(state, "ontable C"))
                {
                    state.Remove("ontable C");
                }
                else if (match_list(state, "C on A"))
                {
                    state.Remove("C on A");
                    state.Add("clear A");
                }
                else if (match_list(state, "C on B"))
                {
                    state.Remove("C on B");
                    state.Add("clear B");
                }
                CCube.transform.position = C;
                //debug(state);
            }
        }
    }
}
