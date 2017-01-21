using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StateText : MonoBehaviour {
	
    string printlist(List<string> states)
    {
        string ans ="";
        for(int i = 0; i < states.Count; i++)
        {
            ans += states[i] + "\n";
        }
        return ans;
    }

	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "現在状態\n" +printlist(InputLanguage.init_NL);
    }
}
