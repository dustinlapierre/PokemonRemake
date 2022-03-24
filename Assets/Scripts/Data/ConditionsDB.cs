using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsDB
{
    public static Dictionary<ConditionID, Condition> Conditions { get; set; } = new Dictionary<ConditionID, Condition>()
    {
        { 
            ConditionID.psn, 
            new Condition()
            { 
                Name = "Poison" ,
                StartMessage = "has been poisoned"
            }
        }
    };
}

public enum ConditionID
{
    none, psn, brn, slp, par, frz
}