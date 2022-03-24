// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AttackState : BaseState {

//     public UnityEngine.AI.NavMeshAgent navMeshAgent;

//     public float viewDist = 15;

//     public float attackRange = 5;
//     public float surgeSpeed = 10;

//     public float surgeCooldown = 2;
//     private float surgeCooldownTimer;
//     public float surgeLength = 2;
//     private float surgeLengthTimer;

//     public int damage = 5;

//     public EnemyController enemy;

//     private bool entered = false;

//     public override void OnEnter() {

//     }

//     public override void OnUpdate() {

//         if(Vector3.Distance(transform.position,enemy.target.position) > viewDist) {
//             owner.SwitchState(typeof(IdleState));
//         }

//         if(Vector3.Distance(transform.position,enemy.target.position) <= attackRange) {
                
//             navMeshAgent.isStopped = true;            
//             surgeCooldownTimer -= Time.deltaTime;

//             if(surgeCooldownTimer <= 0) {
//                 Surge();
//                 surgeLengthTimer -= Time.deltaTime;
//             }

//         }
//         else {
//             navMeshAgent.isStopped = false;
//             navMeshAgent.SetDestination(enemy.target.position);
//         }

//         if(surgeLengthTimer <= 0) {
//             surgeCooldownTimer = surgeCooldown;
//             surgeLengthTimer = surgeLength;
//         }

//         if(Vector3.Distance(transform.position,enemy.target.position) <= 1 && entered == false) {
//             entered = true;
//             enemy.player.TakeDamage(damage);
//         }

//         if(Vector3.Distance(transform.position,enemy.target.position) > 1) {
//             entered = false;
//         }

//     }

//     public override void OnExit() {}

//     public void Surge() {
//         enemy.transform.position += enemy.transform.forward * surgeSpeed * Time.deltaTime;
//     }

// }