using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        ProjectileParent();
    }

    private void ProjectileParent()
    {
        
        if (projectile)
        {
            projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        }
        else
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            /* 
             * On "Animator" we have a bool parameter "IsAttacking"
             * On animation transition (from idle to attack) we have a condition IsAttacking.
             * If the condition is true, the idle animation changes to the attacking animation.
             * On the transition from attack to idle if the condition is false the animation
             * changes to the idle animation~
             * We can change the condition state using the code below.
            */
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        GameObject newProjectile = 
            Instantiate(projectile, gun.transform.position, Quaternion.identity)
            as GameObject;
        //newProjectile.transform.parent = projectileParent.transform;
    }
}
