using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public void Update() {

        if (Input.GetKeyDown("escape")) {
            Application.Quit();
        }

    }
    
}