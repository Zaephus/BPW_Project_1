using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPickup : MonoBehaviour,IInteractable {

    private PlayerController player;

    public Ability abilityToAdd;
    public Ability abiltityToSubract;

    public void Interact(PlayerController p) {

        for(int i = 0; i < p.abilities.Count; i++) {
            if(p.abilities[i] == abilityToAdd || p.abilities[i] == abiltityToSubract) {
                p.abilities.RemoveAt(i);
            }
        }
        p.abilities.Add(abilityToAdd);
        abilityToAdd.Initialize(p);

        Destroy(this.gameObject);

    }

}