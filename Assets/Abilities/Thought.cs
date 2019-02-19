using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Thought{


    public float reflex;
    public float priority;
    public readonly Ability ability;


    public Thought(float reflex, float priority, Ability ability)
    {
        this.reflex = reflex;
        this.priority = priority;
        this.ability = ability;
    }

}
