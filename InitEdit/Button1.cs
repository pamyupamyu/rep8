using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour {

    //StateManager.BlockState
    //InputLanguage.init_NL

    bool CheckContradiction()
    {
        bool c = true;
        //状況的に無理なものを除外する
        //同一
        //A on B ontable A
        //tri A   B on A
        //A on B A on C


        if (StateManager.BlockState[3].Equals("tri")) //A tri
        {
            if(InputLanguage.init_NL.Equals("B on A")|| InputLanguage.init_NL.Equals("C on A"))
            {
                c= false;
            }
        }
        if (StateManager.BlockState[4].Equals("tri")) //B tri
        {
            if (InputLanguage.init_NL.Equals("A on B") || InputLanguage.init_NL.Equals("C on B"))
            {
                c= false;
            }
        }
        if (StateManager.BlockState[3].Equals("tri")) //C tri
        {
            if (InputLanguage.init_NL.Equals("B on C") || InputLanguage.init_NL.Equals("A on C"))
            {
                c= false;
            }
        }

        return c;
    }

    public void TaskOnClick()
    {
        Debug.Log("Next scene");
        if (CheckContradiction())
        {
            SceneManager.LoadScene("GoalEdit");
        }
    }
}
