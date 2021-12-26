using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public enum WeaponType { Sword, Bomb, Bow, Sling, Fist, Staff }

    public WeaponType weaponType;

    public Sprite weaponIcon;

    public float durability;
    public float durabilityMAX;
    public int amount;
    public int amountMAX;

    public string name;
}
