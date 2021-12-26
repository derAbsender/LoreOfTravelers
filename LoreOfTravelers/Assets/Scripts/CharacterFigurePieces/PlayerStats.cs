using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   //public float stealth;

    [Header("Resources")]
    public Stat health;
    public Stat stamina;
    public Stat magic;
    public Stat charisma;

    [Header("Physical")]
    public Stat pAtk;
    public Stat pDef;

    [Header("Magical")]
    public Stat mAtk;
    public Stat mDef;

    [Header("Charismatic")]
    public Stat cAtk;
    public Stat cDef;

    [Header("Spiritual")]
    public Stat sAtk;
    public Stat sDef;

    [Header("Values")]
    public Stat speed;
    public Stat reflex;
    public Stat accuracy;
    public Stat evasiveness;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
