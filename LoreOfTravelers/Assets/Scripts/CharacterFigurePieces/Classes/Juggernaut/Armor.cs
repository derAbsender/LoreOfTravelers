using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    public Sprite armorIcon;

    public int id;
    public enum ArmorType { Head, Body, Limbs};
    public ArmorType armorType;

    public int armorSingle;
    public int armorSet;

    [Header("Resources")]
    public int health;
    public int stamina;
    public int magic;
    public int charisma;

    [Header("Physical")]
    public int pAtk;
    public int pDef;

    [Header("Magical")]
    public int mAtk;
    public int mDef;

    [Header("Charismatic")]
    public int cAtk;
    public int cDef;

    [Header("Spiritual")]
    public int sAtk;
    public int sDef;

    [Header("Values")]
    public int speed;
    public int reflex;
    public int accuracy;
    public int evasiveness;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
