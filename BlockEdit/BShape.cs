using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BShape : MonoBehaviour
{

    public void ChangeShape(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("B Cube");
                StateManager.BlockState[4] = "cube";
                break;
            case 1:
                Debug.Log("B Pylamid");
                StateManager.BlockState[4] = "tri";
                break;
            default:
                break;
        }
    }
}
