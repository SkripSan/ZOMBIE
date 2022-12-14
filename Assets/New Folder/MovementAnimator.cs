using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementAnimator : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        //запрашиваем у navmesha его вектор скорости,рассчитываем длину и передаём аниматору в качестве параметра speed
        animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
    }
}
