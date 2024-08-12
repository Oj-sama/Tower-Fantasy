using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25 ;
    [SerializeField] int goldPenalty = 50;
    Bank bank ;
    void Awake()
    {
        bank =FindObjectOfType<Bank>();    
    }
    public void RewardGold()
    {
        bank.Deposit(goldReward);
    }
    public void PenaltyGold()
    {
        bank.Withdraw(goldPenalty);
    }
}
