using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    #region Singleton
    public static LevelLoader instance;

    void Awake() {
        
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
    #endregion

    public float transitionTime = 1f;

    public void LoadLevel(string levelName) {
        if(levelName == "GameEndScene") {
            Cursor.lockState = CursorLockMode.None;
        }
        StartCoroutine(LoadNamedLevel(levelName));
    }

    public IEnumerator LoadNamedLevel(string levelName) {

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
        
    }

    public void StartGame() {
        Cursor.lockState = CursorLockMode.Locked;
        LoadLevel("LevelZeroScene");
    }

    public void LoadGameOver() {
        Cursor.lockState = CursorLockMode.None;
        LoadLevel("GameOverScene");
    }

}