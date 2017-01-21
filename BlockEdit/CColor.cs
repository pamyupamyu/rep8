using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CColor : MonoBehaviour
{

    public void ChangeColor(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("C red");
                StateManager.BlockState[2] = "red";
                break;
            case 1:
                Debug.Log("C blue");
                StateManager.BlockState[2] = "blue";
                break;
            case 2:
                Debug.Log("C green");
                StateManager.BlockState[2] = "green";
                break;
            default:
                break;
        }
    }


}
