using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

    public static string[] BlockState = { "red","blue","green","cube","cube","cube"};

    // Use this for initialization
    void Start () {
        Debug.Log(BlockState[0]+ BlockState[3]);
	}
    bool Missmatch(string a,string b,string c)
    {
        if (a.Equals(b)||b.Equals(c)||c.Equals(a))
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public void TaskOnClick()
    {
        Debug.Log("Next scene");
        if (Missmatch(BlockState[0],BlockState[1],BlockState[2]))
        {
            SceneManager.LoadScene("Init");
        }
    }

}
