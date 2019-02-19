using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_LISTviewer : MonoBehaviour {


    public ActionManager actionmanager;
    public Text text;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {


        string t = "LIST1" + "\n";

        

        for (int i = 0; i < actionmanager.LIST1.Count; i++)
        {
            t += actionmanager.LIST1[i].beingName + " Reflex: " + actionmanager.LIST1[i].currentActionReflex + "\n";
        }

        t += "\n";
        t += "LIST2";
        t += "\n";

        for (int i = 0; i < actionmanager.LIST2.Count; i++)
        {
            t += actionmanager.LIST2[i].ability.GetParentBeing().beingName + ": " + actionmanager.LIST2[i].ability.abilityName + " Reflex: " + actionmanager.LIST2[i].reflex     +     "\n";
        }

        t += "\n";
        t += "LIST3";
        t += "\n";

        for (int i = 0; i < actionmanager.LIST3.Count; i++)
        {
            t += actionmanager.LIST3[i].ability.GetParentBeing().beingName + ": " + actionmanager.LIST3[i].ability.abilityName + "\n";
        }

    

        text.text = t;
    }
}
