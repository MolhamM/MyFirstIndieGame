using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour 
{
   NavMeshAgent agent;
   [SerializeField]
   PlayerAnimator animator;
   void Awake()
   {
       agent = GetComponent<NavMeshAgent>();
   }
    void Update()
    {
        if (agent.remainingDistance!=Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance==0){
            if(!animator.getPickUpStatus()){
                animator.SetIdle();
            }
        }
    }
   public void MoveToPoint(Vector3 point){
       agent.SetDestination(point);
       animator.SetWalkingAnimation();
   }
}
