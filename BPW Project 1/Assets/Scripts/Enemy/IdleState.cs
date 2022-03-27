using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState {

    private EnemyController enemy;
    
    public float waitDuration = 1;
    public float timer = 0;

    public override void OnEnter() {

        enemy = GetComponent<EnemyController>();

        timer = waitDuration;

    }

    public override void OnUpdate() {

        timer -= Time.deltaTime;
        if(timer <= 0) {
            owner.SwitchState(typeof(PatrolState));
            timer = 0;
            
        }

        if(Vector3.Distance(transform.position,enemy.player.transform.position) < enemy.viewDist) {
            owner.SwitchState(typeof(AttackState));
        }

    }

    public override void OnExit() {}

}