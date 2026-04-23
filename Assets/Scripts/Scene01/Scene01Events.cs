using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene01Events : MonoBehaviour
{
    // MAIN
    public GameObject fadeInScreen;
    public GameObject fadeOutScreen;
    public GameObject charMain;
    [SerializeField] Texture2D[] charMainSprites;
    // public GameObject npcTest;
    public GameObject textBox;
    [SerializeField] GameObject charName;
    [SerializeField] AudioSource audio;
    public GameObject computerBG;

    // TEXT
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

    // TRANSITIONING
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;

    // TEMP
    [SerializeField] GameObject MESSAGE;

    void Update() {
        textLength = textCreator.charCount;
    }

    // start
    void Start()
    {
        MESSAGE.SetActive(false);
        fadeInScreen.SetActive(true);
        StartCoroutine(EventStart());
    }

    IEnumerator EventStart() {
        nextButton.SetActive(false);
        StartCoroutine(AudioFading.FadeIn(audio, 2f));
        yield return new WaitForSeconds(1);
        fadeInScreen.SetActive(false);
        charMain.SetActive(false);
        // yield return new WaitForSeconds(1);

        mainTextObject.SetActive(true);
        textToSpeak = "(rustling sound, thump)"; // make actions italicized
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(2f);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "\"Ugh...\""; // make actions italicized
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

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you fall out of bed)"; // make actions italicized
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

    IEnumerator EventTwo() {
        nextButton.SetActive(false);

        charMain.SetActive(true);
        charMain.GetComponent<RawImage>().texture = charMainSprites[7];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Sunlight?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you check the clock on your bedside table)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 3;
    }

    IEnumerator EventThree() {
        nextButton.SetActive(false);

        charMain.GetComponent<RawImage>().texture = charMainSprites[4];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Wooo! I finally got to sleep in today!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[12];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Usually, my kitty wakes me up earlier, but... where is she?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 4;
    }

    IEnumerator EventFour() {
        nextButton.SetActive(false);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you look at your computer monitor, noticing it's on)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "I could've sworn I didn't leave this on...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 5;
    }

    IEnumerator EventFive() {
        nextButton.SetActive(false);

        charMain.SetActive(false);
        computerBG.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you try to turn the pc off, which doesn't work)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Huh... Weird...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you hear a faint meow coming from the computer)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "?! Kitty?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 6;
    }

    IEnumerator SceneTransition() {
        nextButton.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(AudioFading.FadeOut(audio, 2f));
        fadeOutScreen.SetActive(true);
        MESSAGE.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void NextButton() {
        if (eventPos == 1) {
            StartCoroutine(EventOne());
        }
        if (eventPos == 2) {
            StartCoroutine(EventTwo());
        }
        if (eventPos == 3) {
            StartCoroutine(EventThree());
        }
        if (eventPos == 4) {
            StartCoroutine(EventFour());
        }
        if (eventPos == 5) {
            StartCoroutine(EventFive());
        }
        if (eventPos == 6) {
            StartCoroutine(SceneTransition());
        }
    }

    /* public void EarlyClick() { // make it so that clicking on screen makes all the text pop up at once inistead of the rolling thing ???
        textCreator.charCount
    } */
}
