using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject startButton;
    public GameObject startScreen;
    public GameObject quitButton;
    public GameObject fadeOutScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startScreen.SetActive(true);
        startButton.SetActive(true);
    }

    // Update is called once per frame
    public void StartGame() {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart() {
        
        fadeOutScreen.SetActive(true);
        /* startScreen.SetActive(false);
        startButton.SetActive(false); */
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
