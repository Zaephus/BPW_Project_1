using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState {

    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public EnemyController enemy;

    public float viewDist = 15;

    public Transform[] wayPoints;
    private int currentWayPointIndex = -1;
    private Transform targetWayPoint;

    public override void OnEnter() {

        currentWayPointIndex = (currentWayPointIndex+1) % wayPoints.Length;
        targetWayPoint = wayPoints[currentWayPointIndex];

    }

    public override void OnUpdate() {

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
            owner.SwitchState(typeof(IdleState));
        }

        if(Vector3.Distance(transform.position,enemy.target.position) < viewDist) {
            owner.SwitchState(typeof(AttackState));
        }

        navMeshAgent.SetDestination(targetWayPoint.position);

    }

    public override void OnExit() {}

}