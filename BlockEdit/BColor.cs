using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BColor : MonoBehaviour
{

    public void ChangeColor(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("B red");
                StateManager.BlockState[1] = "red";
                break;
            case 1:
                Debug.Log("B blue");
                StateManager.BlockState[1] = "blue";
                break;
            case 2:
                Debug.Log("B green");
                StateManager.BlockState[1] = "green";
                break;
            default:
                break;
        }
    }


}
