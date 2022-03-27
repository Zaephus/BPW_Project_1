using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,IDamageable {

    private FSM fsm;

    public float viewDist = 1;

    public float rotationSpeed = 1f;

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

        float singleStep = rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward,destination,singleStep,0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

    }
    
}