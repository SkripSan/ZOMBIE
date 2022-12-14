using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Player player;


    private CapsuleCollider capsuleCollider;
    private Animator animator;
    private MovementAnimator movementAnimator;
    private bool dead;

    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        
        //Говорим что мы сами будет управлять поворотом персонажа
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();
    }

    
    void Update()
    {
        if(dead)
            return;
        navMeshAgent.SetDestination(player.transform.position);
        // Задаем поворот персонажа
        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
    }

    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            Destroy(capsuleCollider);
            Destroy(movementAnimator);
            Destroy(navMeshAgent);
            animator.SetTrigger("died");
        }
    }
}
