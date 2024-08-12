using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefeb;

    [SerializeField] bool isPlaceable = false;
    Bank bank;
    int towerGold = 75;
    public bool IsPlaceable { get { return isPlaceable; } }
    void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }
    void OnMouseDown()
    {
        if (isPlaceable && (bank.CurrentBalance >= towerGold))
        {
            Instantiate(towerPrefeb, transform.position, Quaternion.identity);
            isPlaceable = !isPlaceable;
            bank.Withdraw(towerGold);

        }

    }
}
