using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSystem : MonoBehaviour {
    public Text highscore;
    public GameObject tutorialPanel;

    void Start() {
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Return))
            StartGame();
        if (Input.GetKeyUp(KeyCode.Escape))
            ExitGame();
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Tutorial() {
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
    }
}
