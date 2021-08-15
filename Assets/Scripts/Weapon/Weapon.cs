using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string m_WeaponName = "Test Weapon";
    public float m_ShotSpeed = 2f ;
}
