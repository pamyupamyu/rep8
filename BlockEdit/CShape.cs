using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CShape : MonoBehaviour
{

    public void ChangeShape(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Debug.Log("C Cube");
                StateManager.BlockState[5] = "cube";
                break;
            case 1:
                Debug.Log("C Pylamid");
                StateManager.BlockState[5] = "tri";
                break;
            default:
                break;
        }
    }
}
