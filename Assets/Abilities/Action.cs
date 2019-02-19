using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action{

    public float toHit;
    public float reflex;
    //public float priority;
    public readonly Ability ability;


    public Action(float toHit, float reflex, Ability ability)
    {
        this.toHit = toHit;
        this.reflex = reflex;
        this.ability = ability;
    }
}
