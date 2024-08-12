using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] GameObject EnemyPrefeb;
    float speed = 0.7f;
    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        RestartPos();
        StartCoroutine(Timer());
    }
    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }

    }
    void RestartPos()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator Timer()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercentage = 0f;



            transform.LookAt(endPos);
            while (travelPercentage < 1f)
            {

                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }
        gameObject.SetActive(false);
        enemy.PenaltyGold();
    }
}
