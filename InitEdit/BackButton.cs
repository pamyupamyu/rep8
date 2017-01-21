using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    public void TaskOnClick()
    {
        Debug.Log("delete");
        InputLanguage.init_NL.RemoveAt(InputLanguage.init_NL.Count-1);
    }

}
