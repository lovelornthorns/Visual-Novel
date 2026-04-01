using UnityEngine;

public class pausing : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject pauseScreen;
    public GameObject pause;
    public GameObject unpause;
    public GameObject quit;
    public AudioSource pauseMusic;
    public AudioSource sceneMusic;

    public void pauseClick() {
        pause.SetActive(false);
        mainScreen.SetActive(false);
        // sceneMusic.Pause();
        // pauseMusic.Play();
        pauseScreen.SetActive(true);
        unpause.SetActive(true);
        quit.SetActive(true);
        
        Time.timeScale = 0f;
    }

    public void unpauseClick() {
        pause.SetActive(true);
        mainScreen.SetActive(true);
        sceneMusic.Play();
        pauseMusic.Pause();
        pauseScreen.SetActive(false);
        unpause.SetActive(false);
        quit.SetActive(false);
        
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
