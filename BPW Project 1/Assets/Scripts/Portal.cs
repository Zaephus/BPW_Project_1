using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour,IInteractable {

    private PlayerController player;

    public string nextLevel;

    public void Interact(PlayerController p) {
        LevelLoader.instance.LoadLevel(nextLevel);
    }

}