using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState {

    private EnemyController enemy;
    private NavMeshAgent navMeshAgent;

    public List<Transform> wayPoints = new List<Transform>();
    private int currentWayPointIndex = -1;
    private Transform targetWayPoint;

    public override void OnEnter() {

        enemy = GetComponent<EnemyController>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;

        currentWayPointIndex = (currentWayPointIndex+1) % wayPoints.Count;
        targetWayPoint = wayPoints[currentWayPointIndex];

    }

    public override void OnUpdate() {

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
            owner.SwitchState(typeof(IdleState));
        }

        if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) < enemy.viewDist) {
            owner.SwitchState(typeof(Attack_State));
        }

        navMeshAgent.SetDestination(targetWayPoint.position);

    }

    public override void OnExit() {
        navMeshAgent.isStopped = true;
    }

}