using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

    public PlayerController player;

    public Slider healthSlider;
    public TMP_Text healthText;

    public void Start() {

        healthSlider.maxValue = player.maxHealth;

    }

    public void Update() {

        healthSlider.value = player.Health;
        healthText.text = $"{player.Health}";
        
    }

}