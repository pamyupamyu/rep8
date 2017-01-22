using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putgButton : MonoBehaviour {

    GoalStage goalstage;
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    List<string> state;

    public void OnClick()
    {
        put();

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

    void put()
    {
        if (match_list(state, "holding A"))
        {
            A.x = 246;
            A.y = 15;
            state.Remove("holding A");
            state.Add("ontable A");
            state.Add("handEmpty");
            ACube.transform.position = A;
            //debug(state);
        }
        else if (match_list(state, "holding B"))
        {
            B.x = 182;
            B.y = 15;
            state.Remove("holding B");
            state.Add("ontable B");
            state.Add("handEmpty");
            BCube.transform.position = B;
            //debug(state);
        }
        else if (match_list(state, "holding C"))
        {
            C.x = 317;
            C.y = 15;
            state.Remove("holding C");
            state.Add("ontable C");
            state.Add("handEmpty");
            CCube.transform.position = C;
            //debug(state);
        }
    }
}
