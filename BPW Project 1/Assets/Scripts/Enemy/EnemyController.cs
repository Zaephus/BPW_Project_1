using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,IDamageable {

    private FSM fsm;

    public float viewDist = 1;

    public int health = 3;
    public int Health {
        get;
        set;
    }

    [HideInInspector]
    public PlayerController player;

    public void Start() {

        fsm = new FSM(typeof(IdleState),GetComponents<BaseState>());

        Health = health;

        player = FindObjectOfType<PlayerController>();

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

    public void FaceTarget(Vector3 destination) {

        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,1);

    }
    
}