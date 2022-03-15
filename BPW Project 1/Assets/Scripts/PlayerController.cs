using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int maxHealth = 100;
    public int Health {
        get;
        set;
    }

    public float gravity = -9.81f;
    public float rotationSpeed = 2;
    public float rotationLimitX = 45;

    public Vector3 velocity;
    public float speed = 3;
    public bool onGround;
    private float rotationX;

    public CharacterController controller;
    public Camera playerCamera;
    public LayerMask groundMask;

    public List<Ability> abilities = new List<Ability>();

    public void Start() {

        groundMask = LayerMask.GetMask("Ground");

        Health = maxHealth;

        foreach(Ability ability in abilities) {
            ability.Initialize(this);
        }

    }

    public void Update() {

        foreach(Ability ability in abilities) {
            ability.OnUpdate();
        }

        float radius = 0.09f;
        onGround = Physics.CheckSphere(this.transform.position,radius,groundMask);

        if(onGround && velocity.y < 0) {
            velocity.y = 0;
        }

        Vector3 move = transform.right*Input.GetAxis("Horizontal") + transform.forward*Input.GetAxis("Vertical");
        controller.Move(move*Time.deltaTime*speed);

        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, -rotationLimitX, rotationLimitX);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

    }

}