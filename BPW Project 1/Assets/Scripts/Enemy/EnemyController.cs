using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,IDamageable {

    private FSM fsm;

    public int health = 3;
    public int Health {
        get;
        set;
    }

    public PlayerController player;

    public Transform target;

    public void Start() {

        fsm = new FSM(typeof(IdleState),GetComponents<BaseState>());

        Health = health;

        target = player.transform;

    }

    public void Update() {

        fsm.OnUpdate();

    }

    public void TakeDamage(int dmg) {

        Health -= dmg;

        if(Health <= 0) {
            Destroy(gameObject);
        }

    }
    
}