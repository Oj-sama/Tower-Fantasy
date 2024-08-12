using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitpoints;
    int currenthitpoints;
    int difficulty = 1;
    Enemy enemy;
    void OnEnable()
    {
        currenthitpoints = maxHitpoints;
    }
    void Awake()
    {
        enemy = GetComponent<Enemy>();    
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currenthitpoints--;
        if (currenthitpoints <= 0)
        {  enemy.RewardGold();
            maxHitpoints += difficulty;
           gameObject.SetActive(false);
           
        }
    }
}
