using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityToken{


    public float reflex;
    public float priority;
    public readonly Ability ability;


    public AbilityToken(float reflex, float priority, Ability ability)
    {
        this.reflex = reflex;
        this.priority = priority;
        this.ability = ability;
    }

}
