using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack_State : BaseState {

    private EnemyController enemy;
    private NavMeshAgent navMeshAgent;

    public override void OnEnter() {
        enemy = GetComponent<EnemyController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void OnUpdate() {

        if(Vector3.Distance(transform.position,enemy.player.transform.position) >= enemy.viewDist) {
            owner.SwitchState(typeof(IdleState));
        }

        enemy.FaceTarget(enemy.player.transform.position);

    }

    public override void OnExit() {}

    public IEnumerator Surge() {

        yield return null;
    }

}