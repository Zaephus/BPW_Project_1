using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState {

    public EnemyController enemy;

    public float viewDist = 15;
    
    public float waitDuration = 1;
    private float timer = 0;

    public override void OnEnter() {

        timer = waitDuration;

    }

    public override void OnUpdate() {

        timer -= Time.deltaTime;
        if(timer <= 0) {
            owner.SwitchState(typeof(PatrolState));
        }

        if(Vector3.Distance(transform.position,enemy.target.position) < viewDist) {
            owner.SwitchState(typeof(AttackState));
        }

    }

    public override void OnExit() {}

}