using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputLanguage : MonoBehaviour {

    InputField inputField;
    public static List<string> init_NL = new List<string>();
    /// <summary>
        /// Startメソッド
        /// InputFieldコンポーネントの取得および初期化メソッドの実行
        /// </summary>

    // Use this for initialization
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
        //init_NL.Add("ontable A");
        //init_NL.Add("ontable B");
        //init_NL.Add("ontable C");
        //init_NL.Add("clear A");
        //init_NL.Add("clear B");
        //init_NL.Add("clear C");
        //init_NL.Add("handEmpty");
    }

    public void InputLogger()
    {
        //これをon end editに入れることで
        //フォーカスが外れるたびに実行される

        string inputValue = inputField.text;
        string state = NaturalLanguage.Natural_State(inputValue);
        //string order = NaturalLanguage.Natural_Order(inputValue);


        //表示
        Debug.Log(inputValue);
        Debug.Log(state);
        //Debug.Log(order);

       StateCheck(init_NL,state);

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

    void StateCheck(List<string> states,string state)
    {
        //put ? down on the table
        if (state.Equals("holding A"))
        {
            states.Add("holding A");
        }
        else if (state.Equals("holding B"))
        {
            states.Add("holding B");
        }
        else if (state.Equals("holding C"))
        {
            states.Add("holding C");
        }
        else if (state.Equals("clear A"))
        {
            states.Add("clear A");
        }
        else if (state.Equals("clear B"))
        {
            states.Add("clear B");
        }
        else if (state.Equals("clear C"))
        {
            states.Add("clear C");
        }
        else if (state.Equals("ontable A"))
        {
            states.Add("ontable A");
        }
        else if (state.Equals("ontable B"))
        {
            states.Add("ontable B");
        }
        else if (state.Equals("ontable C"))
        {
            states.Add("ontable C");
        }
        else if (state.Equals("A on B"))
        {
            states.Add("A on B");
        }
        else if (state.Equals("A on C"))
        {
            states.Add("A on C");
        }
        else if (state.Equals("B on A"))
        {
            states.Add("B on A");
        }
        else if (state.Equals("B on C"))
        {
            states.Add("B on C");
        }
        else if (state.Equals("C on A"))
        {
            states.Add("C on A");
        }
        else if (state.Equals("C on B"))
        {
            states.Add("C on B");
        }
        else if (state.Equals("handEmpty"))
        {
            states.Add("handEmpty");
        }






    }//statecheck


}
