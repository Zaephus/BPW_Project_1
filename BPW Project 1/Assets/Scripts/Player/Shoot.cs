using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootAbility",menuName = "Abilities/Shoot")]
public class Shoot : Ability {

    private PlayerController player;
    public GameObject bulletPrefab;

    public override void Initialize(PlayerController player) {
        this.player = player;
    }

    public override void OnUpdate() {

        if(Input.GetButtonDown("Shoot")) {

            GameObject bullet = Instantiate(bulletPrefab,player.gunPos.position,Quaternion.identity) as GameObject;
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),player.playerInteractCollider);

            Quaternion q = Quaternion.FromToRotation(Vector3.forward,player.playerCamera.transform.forward);
            bullet.transform.rotation = q * bullet.transform.rotation; 

        }

    }

}