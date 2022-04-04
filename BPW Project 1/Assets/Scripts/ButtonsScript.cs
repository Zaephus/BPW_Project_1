using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour {

    public void MainMenu() {
        LevelLoader.instance.LoadLevel("MainMenuScene");
    }

    public void ExitGame() {
        Application.Quit();
    }

}