using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour,IInteractable {

    private PlayerController player;

    public int healAmount = 20;

    public void Interact(PlayerController p) {
        p.Heal(healAmount);
        Destroy(this.gameObject);
    }
    
}
