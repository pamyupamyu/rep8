using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AColor : MonoBehaviour {

    public void ChangeColor(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("A red");
                StateManager.BlockState[0] = "red";
                break;
            case 1:
                Debug.Log("A blue");
                StateManager.BlockState[0] = "blue";
                break;
            case 2:
                Debug.Log("A green");
                StateManager.BlockState[0] = "green";
                break;
            default:
                break;
        }
    }


}
