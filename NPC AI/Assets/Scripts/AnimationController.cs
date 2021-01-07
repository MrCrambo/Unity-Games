using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public float velocity = 0.1f;
    public string runName = "Run";
    public string speedName = "Speed";
    
    private float maxSpeed;

    private NavMeshAgent thisAgent = null;
    private Animator thisAnimator = null;

    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisAnimator = GetComponent<Animator>();
        maxSpeed = thisAgent.speed;
    }

    private void Update()
    {
        thisAnimator.SetBool(runName, thisAgent.velocity.magnitude > velocity); 
        thisAnimator.SetFloat(speedName, thisAgent.velocity.magnitude / maxSpeed);   
    }
}
