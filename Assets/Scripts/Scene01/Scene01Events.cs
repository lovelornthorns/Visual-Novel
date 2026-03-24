using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Scene01Events : MonoBehaviour
{
    // MAIN
    public GameObject fadeInScreen;
    public GameObject fadeOutScreen;
    public GameObject charMain;
    // public GameObject npcTest;
    public GameObject textBox;
    [SerializeField] GameObject charName;
    [SerializeField] AudioSource audio;

    // TEXT
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

    // TRANSITIONING
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;

    void Update() {
        textLength = textCreator.charCount;
    }

    // start
    void Start()
    {
        StartCoroutine(EventStart());
    }

    IEnumerator EventStart() {
        StartCoroutine(AudioFading.FadeIn(audio, 2f));
        yield return new WaitForSeconds(1);
        fadeInScreen.SetActive(false);
        charMain.SetActive(true);
        yield return new WaitForSeconds(1);

        mainTextObject.SetActive(true);
        textToSpeak = "the first line i speak";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 1;
        
    }

    IEnumerator EventOne() {
        nextButton.SetActive(false);
    
        yield return new WaitForSeconds(1);
        charName.GetComponent<TMPro.TMP_Text>().text = "npcTest";
        // npcTest.SetActive(true);
        // textBox.SetActive(true);
        
        audio.Play();
        textToSpeak = "ok and i talk like this";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 2;
    }

    IEnumerator SceneTransition() {
        nextButton.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(AudioFading.FadeOut(audio, 2f));
        fadeOutScreen.SetActive(true);
        SceneManager.LoadScene(2);
    }

    public void NextButton() {
        if (eventPos == 1) {
            StartCoroutine(EventOne());
        }
        if (eventPos == 2) {
            StartCoroutine(SceneTransition());
        }
    }
}
