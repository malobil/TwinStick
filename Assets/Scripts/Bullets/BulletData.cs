using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Bullet", fileName = "New bullet")]
public class BulletData : ScriptableObject
{
    public float m_bulletSpeed = 10f;
    public float m_bulletDamage = 1f ;
}
