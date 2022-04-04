using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SprintAbility",menuName = "Abilities/Sprint")]
public class Sprint : Ability {

    private PlayerController player;
    public float addedSpeed = 3;
    private float sprintSpeed;

    public override void Initialize(PlayerController player) {
        this.player = player;
        sprintSpeed = player.speed + addedSpeed;
    }

    public override void OnUpdate() {

        if(Input.GetAxis("Vertical") > 0) {

            if(Input.GetButtonDown("Sprint")) {
                player.playerSpeed = sprintSpeed;
            }
            if(Input.GetButtonUp("Sprint")) {
                player.playerSpeed = player.speed;
            }

        }

    }

}