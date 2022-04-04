using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuckShotAbility",menuName = "Abilities/BuckShot")]
public class BuckShot : Ability {

    private PlayerController player;
    public GameObject bulletPrefab;

    public override void Initialize(PlayerController player) {
        this.player = player;
    }

    public override void OnUpdate() {

        if(Input.GetButtonDown("Shoot")) {

            Debug.Log("Shoot");

            for(int i = -1; i <= 1; i++) {
                GameObject bullet = Instantiate(bulletPrefab,player.gunPos.position,Quaternion.identity) as GameObject;
                Physics.IgnoreCollision(bullet.GetComponent<Collider>(),player.playerInteractCollider);

                Vector3 bulletVector = player.playerCamera.transform.forward;
                bulletVector.x += i*0.05f;

                Quaternion q = Quaternion.FromToRotation(Vector3.forward,bulletVector);
                bullet.transform.rotation = q * bullet.transform.rotation; 
            }
        
        }

    }

}