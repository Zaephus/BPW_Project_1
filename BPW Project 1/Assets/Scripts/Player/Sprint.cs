using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SprintAbility",menuName = "Abilities/Sprint")]
public class Sprint : Ability {

    private PlayerController player;
    public float addedSpeed = 3;

    public override void Initialize(PlayerController player) {
        this.player = player;
    }

    public override void OnUpdate() {

        if(Input.GetKey("w")) {

            if(Input.GetButtonDown("Sprint")) {
                player.speed += addedSpeed;
            }
            if(Input.GetButtonUp("Sprint")) {
                player.speed -= addedSpeed;
            }

        }

    }

}