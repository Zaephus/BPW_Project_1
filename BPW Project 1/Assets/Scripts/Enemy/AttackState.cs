using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState {

    private EnemyController enemy;
    private NavMeshAgent navMeshAgent;

    private Vector3 surgeTarget;

    public int surgeDamage = 15;

    public float minSurgeCooldown = 1.5f;
    public float maxSurgeCooldown = 3f;
    private float surgeCooldown;

    public float maxSurgeTime = 2f;
    private float surgeTime;

    public float surgeModifier = 0.1f;

    private bool isSurging;

    public override void OnEnter() {

        enemy = GetComponent<EnemyController>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        surgeCooldown = Random.Range(minSurgeCooldown,maxSurgeCooldown);
        surgeTime = maxSurgeTime;

    }

    public override void OnUpdate() {

        if(Vector3.Distance(transform.position,enemy.player.transform.position) >= enemy.viewDist) {
            owner.SwitchState(typeof(IdleState));
        }

        if(surgeCooldown > 0) {

            surgeTarget = enemy.player.transform.position - transform.position;

            enemy.FaceTarget(surgeTarget);
            surgeCooldown -= Time.deltaTime;

            surgeTarget.Normalize();
            surgeTarget *= surgeModifier;

        }

        if(surgeCooldown <= 0) {

            surgeCooldown = 0;
            surgeTime -= Time.deltaTime;

            if(surgeTime >= 0) {
                Surge(surgeTarget);
            }

            if(surgeTime <= 0) {
                owner.SwitchState(typeof(AttackState));
            }

        }

    }

    public override void OnExit() {}

    public void OnTriggerEnter(Collider c) {
        if(c.GetComponent<IAttackable>() != null) {
            c.GetComponent<IAttackable>().TakeDamage(surgeDamage);
        }
    }

    public void Surge(Vector3 target) {
        navMeshAgent.Move(target);
    }

}