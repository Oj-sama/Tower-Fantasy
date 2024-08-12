using Unity.VisualScripting;
using UnityEngine;

public class TragetLocator : MonoBehaviour
{
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform weapon;
    float range = 20f;

    Transform target;
    void Update()
    {
        FindClosestTarget();
        Aimweapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistant = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistant)
            {
                closestTarget = enemy.transform;
                maxDistant = targetDistance;
            }
        }
        target = closestTarget;
    }

    void Aimweapon()
    {
        float targetPosition = Vector3.Distance(transform.position, target.position);
        if (targetPosition <= range)
        {
            weapon.LookAt(target);
            Attack(true);
        }
        else
            Attack(false);

    }
    void Attack(bool isActive)
    {
        var emission = projectileParticles.emission;
        emission.enabled = isActive;
    }
}
