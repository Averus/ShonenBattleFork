using UnityEngine;
using System.Collections;
using System;

public class IncludesEffect_SelectionCriteria : SelectionCriteria
{

    String effectName;
    

    public override void Assess(AbilityToken abil)
    {
       //Debug.Log("Looking for abilities in " + abil.abilityName + " that contain an effect called " + effectName);
        for (int i = 0; i < abil.ability.effects.Count; i++)
        {
            if (abil.ability.effects[i].effectName == effectName)
            {
                //Debug.Log(abil.abilityName + " contains an effect called " + effectName);
                abil.priority += UnityEngine.Random.Range(minPriority, maxPriority);
            }
        }
        //Debug.Log(abil.abilityName + " does not contain an effect called " + effectName);
       

    }


    public IncludesEffect_SelectionCriteria(BattleManager battleManager, Being parentBeing, string selectionCriteriaName, string effectName, float minPriority, float maxPriority) : base(battleManager, parentBeing, selectionCriteriaName, minPriority, maxPriority)
    {
        this.battleManager = battleManager;
        this.parentBeing = parentBeing;
        this.effectName = effectName;
        this.minPriority = minPriority;
        this.maxPriority = maxPriority;
    }



}
