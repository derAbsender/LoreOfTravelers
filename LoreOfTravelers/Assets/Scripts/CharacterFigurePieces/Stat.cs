using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Stat
{
    public string designation;
    
    public float baseInitValue = 10f;
    public float initValue = 10f;
    public float currentMultiplier = 1f;
    public float currValue = 10;

    public void SetCurrValue()
    {
        currValue = initValue * currentMultiplier;
    }
}
