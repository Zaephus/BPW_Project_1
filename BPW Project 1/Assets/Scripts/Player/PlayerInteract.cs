using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour {

    public PlayerController player;

    private IInteractable interactable;

    private bool canInteract = false;

    public TMP_Text interactText;

    public void Start() {}

    public void Update() {

        if(canInteract) {
            interactText.enabled = true;

            if(Input.GetButtonDown("Interact")) {
                interactable.Interact(player);
                canInteract = false;
            }
        }
        else {
            interactText.enabled = false;
        }

    }

    public void OnTriggerEnter(Collider other) {

        if(other.GetComponent<IInteractable>() != null) {
            canInteract = true;
            interactable = other.GetComponent<IInteractable>();
        }

    }

    public void OnTriggerExit(Collider other) {
        canInteract = false;
    }
}