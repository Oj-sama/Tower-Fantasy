using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [Range(0,50)] int poolSize = 6;
 [Range(0.1f,30f)] float timeToWait = 2f;
    GameObject[] pool;
    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(EnemyInstantiating());
    }
    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    IEnumerator EnemyInstantiating()
    {
        while (true)
        {
            EnableObjectOfPool();
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void EnableObjectOfPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }

        }
    }
}
