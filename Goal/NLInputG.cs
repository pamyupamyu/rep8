using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NLInputG : MonoBehaviour
{

    InputField inputField;

    GoalStage goalstage;
    public GameObject ACube;
    public GameObject BCube;
    public GameObject CCube;
    public Vector3 A, B, C;
    List<string> goalstate;
    /// <summary>
        /// Startメソッド
        /// InputFieldコンポーネントの取得および初期化メソッドの実行
        /// </summary>

    // Use this for initialization
    void Start()
    {
        goalstage = GameObject.Find("GoalStage").GetComponent<GoalStage>();
        A = ACube.transform.position;
        B = BCube.transform.position;
        C = CCube.transform.position;
        goalstate = goalstage.Goallist;


        inputField = GetComponent<InputField>();
        InitInputField();
    }

    public void InputLogger()
    {
        //これをon end editに入れることで
        //フォーカスが外れるたびに実行される

        string inputValue = inputField.text;
        //string state = NaturalLanguage.Natural_State(inputValue);
        string order = NaturalLanguage.Natural_Order(inputValue);


        //表示
        Debug.Log(inputValue);
        //Debug.Log(state);
        Debug.Log(order);

        OrderDo(order);

        InitInputField(); //フォーカスが外れたとき初期化
    }

    /// <summary>
        /// InputFieldの初期化用メソッド
        /// 入力値をリセットして、フィールドにフォーカスする
        /// </summary>

    void InitInputField()
    {

        // 値をリセット
        inputField.text = "";
        // フォーカス
        inputField.ActivateInputField();
    }



    void OrderDo(string order)
    {
        string[] orderList = order.Split();

        //12pattern
        //pick and remove
        if ((orderList[0].Equals("pick") && orderList[2].Equals("A")) || (orderList[0].Equals("remove") && orderList[1].Equals("A")))
        {
            goalstage.obj = "A";
            pick(goalstage.obj);
        }
        else if ((orderList[0].Equals("pick") && orderList[2].Equals("B")) || (orderList[0].Equals("remove") && orderList[1].Equals("B")))
        {
            goalstage.obj = "B";
            pick(goalstage.obj);
        }
        else if ((orderList[0].Equals("pick") && orderList[2].Equals("C")) || (orderList[0].Equals("remove") && orderList[1].Equals("C")))
        {
            goalstage.obj = "C";
            pick(goalstage.obj);
        }
        //put
        else if ((orderList[0].Equals("put") && orderList[1].Equals("A")))
        {
            put();
        }
        else if ((orderList[0].Equals("put") && orderList[1].Equals("B")))
        {
            put();
        }
        else if ((orderList[0].Equals("put") && orderList[1].Equals("C")))
        {
            put();
        }
        //place
        else if (orderList[0].Equals("place") && orderList[1].Equals("A") && orderList[3].Equals("B"))
        {
            Debug.Log("A on B");
            goalstage.obj = "B";
            stack(goalstage.obj);
        }
        else if (orderList[0].Equals("place") && orderList[1].Equals("A") && orderList[3].Equals("C"))
        {
            Debug.Log("A on C");
            goalstage.obj = "C";
            stack(goalstage.obj);
        }
        else if (orderList[0].Equals("place") && orderList[1].Equals("B") && orderList[3].Equals("A"))
        {
            goalstage.obj = "A";
            stack(goalstage.obj);
        }
        else if (orderList[0].Equals("place") && orderList[1].Equals("B") && orderList[3].Equals("C"))
        {
            goalstage.obj = "C";
            stack(goalstage.obj);
        }
        else if (orderList[0].Equals("place") && orderList[1].Equals("C") && orderList[3].Equals("A"))
        {
            goalstage.obj = "A";
            stack(goalstage.obj);
        }
        else if (orderList[0].Equals("place") && orderList[1].Equals("C") && orderList[3].Equals("B"))
        {
            goalstage.obj = "B";
            stack(goalstage.obj);
        }
    }//order

    bool match_list(List<string> goalstate, string match)

    {
        bool C = false;
        foreach (string s in goalstate)
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
            if (match_list(goalstate, "clear A") && match_list(goalstate, "handEmpty"))
            {
                A.x = 305;
                A.y = 4;
                goalstate.Remove("handEmpty");
                goalstate.Add("holding A");
                if (match_list(goalstate, "ontable A"))
                {
                    goalstate.Remove("ontable A");
                }
                else if (match_list(goalstate, "A on B"))
                {
                    goalstate.Remove("A on B");
                    goalstate.Add("clear B");
                }
                else if (match_list(goalstate, "A on C"))
                {
                    goalstate.Remove("A on C");
                    goalstate.Add("clear C");
                }
                ACube.transform.position = A;
                //debug(goalstate);
            }
        }
        else if (block.Equals("B"))
        {
            if (match_list(goalstate, "clear B") && match_list(goalstate, "handEmpty"))
            {
                B.x = 305;
                B.y = 4;
                goalstate.Remove("handEmpty");
                goalstate.Add("holding B");
                if (match_list(goalstate, "ontable B"))
                {
                    goalstate.Remove("ontable B");
                }
                else if (match_list(goalstate, "B on A"))
                {
                    goalstate.Remove("B on A");
                    goalstate.Add("clear A");
                }
                else if (match_list(goalstate, "B on C"))
                {
                    goalstate.Remove("B on C");
                    goalstate.Add("clear C");
                }
                BCube.transform.position = B;
                //debug(goalstate);
            }
        }
        else if (block.Equals("C"))
        {
            if (match_list(goalstate, "clear C") && match_list(goalstate, "handEmpty"))
            {
                C.x = 305;
                C.y = 4;
                goalstate.Remove("handEmpty");
                goalstate.Add("holding C");
                if (match_list(goalstate, "ontable C"))
                {
                    goalstate.Remove("ontable C");
                }
                else if (match_list(goalstate, "C on A"))
                {
                    goalstate.Remove("C on A");
                    goalstate.Add("clear A");
                }
                else if (match_list(goalstate, "C on B"))
                {
                    goalstate.Remove("C on B");
                    goalstate.Add("clear B");
                }
                CCube.transform.position = C;
                //debug(goalstate);
            }
        }
    }

    void put()
    {
        if (match_list(goalstate, "holding A"))
        {
            A.x = 314.2f;
            A.y = 0;
            goalstate.Remove("holding A");
            goalstate.Add("ontable A");
            goalstate.Add("handEmpty");
            ACube.transform.position = A;
            //debug(goalstate);
        }
        else if (match_list(goalstate, "holding B"))
        {
            B.x = 310.3f;
            B.y = 0;
            goalstate.Remove("holding B");
            goalstate.Add("ontable B");
            goalstate.Add("handEmpty");
            BCube.transform.position = B;
            //debug(goalstate);
        }
        else if (match_list(goalstate, "holding C"))
        {
            C.x = 318;
            C.y = 0;
            goalstate.Remove("holding C");
            goalstate.Add("ontable C");
            goalstate.Add("handEmpty");
            CCube.transform.position = C;
            //debug(goalstate);
        }
    }

    void stack(string block)
    {
        if (block.Equals("A"))
        {
            if (match_list(goalstate, "clear A") && match_list(goalstate, "holding B"))
            {

                B.x = A.x;
                B.y = A.y + 2f;
                goalstate.Remove("clear A");
                goalstate.Remove("holding B");
                goalstate.Add("B on A");
                goalstate.Add("handEmpty");
                BCube.transform.position = B;
                //debug(goalstate);
            }
            else if (match_list(goalstate, "clear A") && match_list(goalstate, "holding C"))
            {
                C.x = A.x;
                C.y = A.y + 2f;
                goalstate.Remove("clear A");
                goalstate.Remove("holding C");
                goalstate.Add("C on A");
                goalstate.Add("handEmpty");
                CCube.transform.position = C;
                //debug(goalstate);
            }
        }
        else if (block.Equals("B"))
        {
            if (match_list(goalstate, "clear B") && match_list(goalstate, "holding A"))
            {
                A.x = B.x;
                A.y = B.y + 2f;
                goalstate.Remove("clear B");
                goalstate.Remove("holding A");
                goalstate.Add("A on B");
                goalstate.Add("handEmpty");
                ACube.transform.position = A;
                //debug(goalstate);
            }
            else if (match_list(goalstate, "clear B") && match_list(goalstate, "holding C"))
            {
                C.x = B.x;
                C.y = B.y + 2f;
                goalstate.Remove("clear B");
                goalstate.Remove("holding C");
                goalstate.Add("C on B");
                goalstate.Add("handEmpty");
                CCube.transform.position = C;
                //debug(goalstate);
            }

        }
        else if (block.Equals("C"))
        {
            if (match_list(goalstate, "clear C") && match_list(goalstate, "holding A"))
            {
                A.x = C.x;
                A.y = C.y + 2f;
                goalstate.Remove("clear C");
                goalstate.Remove("holding A");
                goalstate.Add("A on C");
                goalstate.Add("handEmpty");
                ACube.transform.position = A;
                //debug(goalstate);
            }
            else if (match_list(goalstate, "clear C") && match_list(goalstate, "holding B"))
            {
                B.x = C.x;
                B.y = C.y + 2f;
                goalstate.Remove("clear C");
                goalstate.Remove("holding B");
                goalstate.Add("B on C");
                goalstate.Add("handEmpty");
                BCube.transform.position = B;
                //debug(goalstate);
            }
        }
    }

}

