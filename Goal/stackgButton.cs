using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackgButton : MonoBehaviour {

    GoalStage goalstage;
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    List<string> state;



    public void OnClick()
    {
        stack(goalstage.obj);

    }

    // Use this for initialization
    void Start()
    {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
        state = goalstage.Goallist;
        //state = GoalStage.Goallist;
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


    void stack(string block)
    {
        if (block.Equals("A"))
        {
            if (match_list(state, "clear A") && match_list(state, "holding B"))
            {

                B.x = A.x;
                B.y = A.y + 30.5f;
                state.Remove("clear A");
                state.Remove("holding B");
                state.Add("B on A");
                state.Add("handEmpty");
                BCube.transform.position = B;
                //debug(state);
            }
            else if (match_list(state, "clear A") && match_list(state, "holding C"))
            {
                C.x = A.x;
                C.y = A.y + 30.5f;
                state.Remove("clear A");
                state.Remove("holding C");
                state.Add("C on A");
                state.Add("handEmpty");
                CCube.transform.position = C;
                //debug(state);
            }
        }
        else if (block.Equals("B"))
        {
            if (match_list(state, "clear B") && match_list(state, "holding A"))
            {
                A.x = B.x;
                A.y = B.y + 30.5f;
                state.Remove("clear B");
                state.Remove("holding A");
                state.Add("A on B");
                state.Add("handEmpty");
                ACube.transform.position = A;
                //debug(state);
            }
            else if (match_list(state, "clear B") && match_list(state, "holding C"))
            {
                C.x = B.x;
                C.y = B.y + 30.5f;
                state.Remove("clear B");
                state.Remove("holding C");
                state.Add("C on B");
                state.Add("handEmpty");
                CCube.transform.position = C;
                //debug(state);
            }

        }
        else if (block.Equals("C"))
        {
            if (match_list(state, "clear C") && match_list(state, "holding A"))
            {
                A.x = C.x;
                A.y = C.y + 30.5f;
                state.Remove("clear C");
                state.Remove("holding A");
                state.Add("A on C");
                state.Add("handEmpty");
                ACube.transform.position = A;
                //debug(state);
            }
            else if (match_list(state, "clear C") && match_list(state, "holding B"))
            {
                B.x = C.x;
                B.y = C.y + 30.5f;
                state.Remove("clear C");
                state.Remove("holding B");
                state.Add("B on C");
                state.Add("handEmpty");
                BCube.transform.position = B;
                //debug(state);
            }
        }
    }
}
