using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AShape : MonoBehaviour {

    public void ChangeShape(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("A Cube");
                StateManager.BlockState[3] = "cube";
                break;
            case 1:
                Debug.Log("A Pylamid");
                StateManager.BlockState[3] = "tri";
                break;
            default:
                break;
        }
    }
}
