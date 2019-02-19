using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour {

    public bool turnNotFinishedYet = false;

    public List<Being> LIST1 = new List<Being>(); //A list of beings acting in the location
    public List<AbilityToken> LIST2 = new List<AbilityToken>();//A list of actions declared by said beings ready to be ordered and added to...
    public List<AbilityToken> LIST3 = new List<AbilityToken>(); //The main stack of public actions, ready to be resolved one by one

    public int currentTurn = 0;
    public int step = 0;
    public bool pause = false;

    public AbilityToken currentAction = null; //The current action that is being evaluated





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            SortList1();
        }

        if (Input.GetMouseButtonDown(0) && pause == false)
        {

            if (step == 3)
            {

            }

            if (step == 1)
            {
                step = 2;
                CommitToAction();
                Debug.Log("XXXXXXXXXXXXXXXXXX");
                pause = true;
            }

            if (step == 0)
           {
               step = 1; //fires the turn of the current Being, asking them to Think() and filling LIST2
               Step1();
               pause = true;
            }




        }

        if (Input.GetMouseButtonUp(0) && pause == true)
        {
            pause = false;
        }

    }

    void Step1()
    {
        turnNotFinishedYet = true;
        if (LIST1.Count > 0)
        {
            ProposeActions(LIST1[currentTurn].Think());
        }
    }

    public void AddToBeingQueue(Being being)
    {
        LIST1.Add(being);
        //SortList1();
    }

    private void SortList1()
    {
        Debug.Log("sorting");
        List<Being> SortedList = LIST1.OrderBy(o => o.currentActionReflex).ToList();
    }

    public void ProposeActions(List<AbilityToken> actions)
    {
        LIST2.AddRange(actions);
        SortList2();
    }

    private void SortList2()
    {
        List<AbilityToken> SortedList = LIST2.OrderBy(o => o.reflex).ToList();
    }

    private void CommitToAction()
    {
        
        if (LIST2.Count > 0)
        {
            LIST2[0].ability.GetParentBeing().isCommittedToAction = true;
            Debug.Log(LIST2[0].ability.visual);
            currentAction = LIST2[0];
            LIST3.Add(LIST2[0]);
            LIST2.RemoveAt(0);
            List<AbilityToken> tempList = new List<AbilityToken>();
            for (int i = 0; i < LIST1.Count; i++)
            {
                if (LIST1[i].isCommittedToAction == false) //May change this later, either put it in the Being or think about situations where they can't return a PublicAction but can a mental or instant action
                {
                    Debug.Log(LIST1[i].beingName + " is thinking about a response");
                    tempList.AddRange(LIST1[i].Think());
                }
            }
            for (int i = tempList.Count - 1; i > -1; i--)
            {
                if (tempList[i].reflex < currentAction.reflex)
                {
                    Debug.Log(tempList[i].ability.GetParentBeing().beingName + " " + tempList[i].ability.abilityName +" " + tempList[i].reflex + " is less than " + currentAction.reflex);
                    tempList.RemoveAt(i);
                }
            }
            LIST2.AddRange(tempList);
            SortList2();
        }
        else
        {
            step = 3;
        }

    }
}
