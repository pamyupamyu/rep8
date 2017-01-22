using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputLanguage2 : MonoBehaviour
{

    InputField inputField;
    public static List<string> goal_NL = new List<string>();

    /// <summary>
        /// Startメソッド
        /// InputFieldコンポーネントの取得および初期化メソッドの実行
        /// </summary>

    // Use this for initialization
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
        goal_NL = InputLanguage.init_NL;
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

        OrderCheck(goal_NL, order);
        

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

    void OrderCheck(List<string> states, string order)
    {
        //put ? down on the table
        if (order.Equals("put A down on the table") && states.Contains("holding A"))
        {
            states.Add("clear A");
            states.Add("ontable A");
            states.Add("handEmpty");
            states.Remove("holding A");
        }
        else if (order.Equals("put B down on the table") && states.Contains("holding B"))
        {
            states.Add("clear B");
            states.Add("ontable B");
            states.Add("handEmpty");
            states.Remove("holding B");
        }
        else if (order.Equals("put C down on the table") && states.Contains("holding C"))
        {
            states.Add("clear C");
            states.Add("ontable C");
            states.Add("handEmpty");
            states.Remove("holding C");
        }
        //place ? on ?
        else if (order.Equals("place A on B") && states.Contains("holding A") && states.Contains("clear B"))
        {
            states.Add("clear A");
            states.Add("A on B");
            states.Add("handEmpty");
            states.Remove("holding A");
            states.Remove("clear B");
        }
        else if (order.Equals("place A on C") && states.Contains("holding A") && states.Contains("clear C"))
        {
            states.Add("clear A");
            states.Add("A on C");
            states.Add("handEmpty");
            states.Remove("holding A");
            states.Remove("clear C");
        }
        else if (order.Equals("place B on A") && states.Contains("holding B") && states.Contains("clear A"))
        {
            states.Add("clear B");
            states.Add("B on A");
            states.Add("handEmpty");
            states.Remove("holding B");
            states.Remove("clear A");
        }
        else if (order.Equals("place B on C") && states.Contains("holding B") && states.Contains("clear C"))
        {
            states.Add("clear B");
            states.Add("B on C");
            states.Add("handEmpty");
            states.Remove("holding B");
            states.Remove("clear C");
        }
        else if (order.Equals("place C on A") && states.Contains("holding C") && states.Contains("clear A"))
        {
            states.Add("clear C");
            states.Add("C on A");
            states.Add("handEmpty");
            states.Remove("holding C");
            states.Remove("clear A");
        }
        else if (order.Equals("place C on B") && states.Contains("holding C") && states.Contains("clear B"))
        {
            states.Add("clear C");
            states.Add("C on B");
            states.Add("handEmpty");
            states.Remove("holding C");
            states.Remove("clear B");
        }
        //remove ? from top on ?
        else if (order.Equals("remove A from top on B") && states.Contains("clear A") && states.Contains("A on B") && states.Contains("handEmpty"))
        {
            states.Add("holding A");
            states.Add("clear B");
            states.Remove("clear A");
            states.Remove("A on B");
            states.Remove("handEmpty");
        }
        else if (order.Equals("remove A from top on C") && states.Contains("clear A") && states.Contains("A on C") && states.Contains("handEmpty"))
        {
            states.Add("holding A");
            states.Add("clear C");
            states.Remove("clear A");
            states.Remove("A on C");
            states.Remove("handEmpty");
        }
        else if (order.Equals("remove B from top on A") && states.Contains("clear B") && states.Contains("B on A") && states.Contains("handEmpty"))
        {
            states.Add("holding B");
            states.Add("clear A");
            states.Remove("clear B");
            states.Remove("B on A");
            states.Remove("handEmpty");
        }
        else if (order.Equals("remove B from top on C") && states.Contains("clear B") && states.Contains("B on C") && states.Contains("handEmpty"))
        {
            states.Add("holding B");
            states.Add("clear C");
            states.Remove("clear B");
            states.Remove("B on C");
            states.Remove("handEmpty");
        }
        else if (order.Equals("remove C from top on A") && states.Contains("clear C") && states.Contains("C on A") && states.Contains("handEmpty"))
        {
            states.Add("holding C");
            states.Add("clear A");
            states.Remove("clear C");
            states.Remove("C on A");
            states.Remove("handEmpty");
        }
        else if (order.Equals("remove C from top on B") && states.Contains("clear C") && states.Contains("C on B") && states.Contains("handEmpty"))
        {
            states.Add("holding C");
            states.Add("clear B");
            states.Remove("clear C");
            states.Remove("C on B");
            states.Remove("handEmpty");
        }
        //pick up ? from the table
        else if (order.Equals("pick up A from the table") && states.Contains("clear A") && states.Contains("ontable A") && states.Contains("handEmpty"))
        {
            states.Add("holding A");
            states.Remove("clear A");
            states.Remove("ontable A");
            states.Remove("handEmpty");
        }
        else if (order.Equals("pick up B from the table") && states.Contains("clear B") && states.Contains("ontable B") && states.Contains("handEmpty"))
        {
            states.Add("holding B");
            states.Remove("clear B");
            states.Remove("ontable B");
            states.Remove("handEmpty");
        }
        else if (order.Equals("pick up B from the table") && states.Contains("clear B") && states.Contains("ontable B") && states.Contains("handEmpty"))
        {
            states.Add("holding B");
            states.Remove("clear B");
            states.Remove("ontable B");
            states.Remove("handEmpty");
        }

    }//statecheck

  

}

