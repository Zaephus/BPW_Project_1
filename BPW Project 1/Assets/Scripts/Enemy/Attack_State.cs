using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack_State : BaseState {

    private EnemyController enemy;
    private NavMeshAgent navMeshAgent;

    public float maxSurgeCooldown = 2f;
    private float surgeCooldown;

    public float maxSurgeTime = 2f;
    private float surgeTime;

    public float surgeModifier = 0.1f;

    private bool isSurging;

    public override void OnEnter() {

        enemy = GetComponent<EnemyController>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        surgeCooldown = maxSurgeCooldown;
        surgeTime = maxSurgeTime;

    }

    public override void OnUpdate() {

        if(Vector3.Distance(transform.position,enemy.player.transform.position) >= enemy.viewDist) {
            owner.SwitchState(typeof(IdleState));
        }

        if(surgeCooldown >= 0) {
            enemy.FaceTarget(enemy.player.transform.position);
            surgeCooldown -= Time.deltaTime;
        }

        if(surgeCooldown <= 0) {

            surgeCooldown = 0;
            surgeTime -= Time.deltaTime;

            if(surgeTime >= 0) {
                Surge();
            }

            if(surgeTime <= 0) {
                owner.SwitchState(typeof(IdleState));
            }

        }

    }

    public override void OnExit() {}

    public void Surge() {

        Vector3 surgeTarget = enemy.player.transform.position - transform.position;
        surgeTarget.Normalize();

        navMeshAgent.Move(surgeTarget*surgeModifier);

    }

}