using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpAbility",menuName = "Abilities/Jump")]
public class Jump : Ability {

    private PlayerController player;
    public float jumpHeight = 1;

    public override void Initialize(PlayerController player) {
        this.player = player;
    }

    public override void OnUpdate() {

        if(Input.GetButtonDown("Jump") && player.IsOnGround()) {
            player.velocity.y += Mathf.Sqrt(jumpHeight*-3*player.gravity);
        }
        
    }
    
}