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
    public GameObject charSide;
    [SerializeField] Texture2D[] charMainSprites;
    // public GameObject npcTest;
    public GameObject textBox;
    [SerializeField] GameObject charName;
    [SerializeField] AudioSource audio;
    public GameObject computerBG;
    public GameObject SThallBG;
    public GameObject STliftBG;
    public GameObject STbridgeBG;
    public GameObject STviewscreenBG;
    public GameObject STtransporterBG;

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

        mainTextObject.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        mainTextObject.SetActive(true);

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

    IEnumerator EventSix() {
        fadeInScreen.SetActive(true);
        nextButton.SetActive(false);

        charMain.SetActive(false);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(OWW!!!)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you land on your but. hard. your vision is a blurry.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "ugh.... where am i?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "kitty?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 7;
    }

    IEnumerator EventSeven() {
        fadeInScreen.SetActive(true);
        nextButton.SetActive(false);

        charMain.SetActive(false);

        mainTextObject.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);
        mainTextObject.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "!!! Kitty!!!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 8;

    }

    IEnumerator EventEight() {
        fadeInScreen.SetActive(true);
        nextButton.SetActive(false);

        charMain.SetActive(false);
        computerBG.SetActive(true);

        mainTextObject.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        mainTextObject.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "(oh...)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);
        mainTextObject.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "it's just a pile of tribbles.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 9;

    }

    IEnumerator EventNine() {
        nextButton.SetActive(false);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "wait.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "tribbles?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "am i...???";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 10;
    }

    IEnumerator EventTen() {
        nextButton.SetActive(false);

        charMain.SetActive(false);

        mainTextObject.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "???";
        textToSpeak = "Officer!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(true);
        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "!!!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(false);
        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you stand at attention. your legs shake a little.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "???";
        textToSpeak = "It's all hands on deck! What are you doing standing around?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 11;
    }

    IEnumerator EventEleven() {
        nextButton.SetActive(false);

        charMain.SetActive(true);

        mainTextObject.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Captain Kirk???";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(true);
        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "!!!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(false);
        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(scratch that, it was the floor shaking. the ship shakes violently.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "???";
        textToSpeak = "Captain. We must make it to the bridge immediately.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 12;
    }

    IEnumerator EventTwelve() {
        nextButton.SetActive(false);

        charMain.SetActive(true);

        mainTextObject.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Mister Spock???";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(true);
        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "Is this really Star Trek???";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(false);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Kirk";
        textToSpeak = "Star...? I don't recognize you. And why aren't you in uniform?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Kirk";
        textToSpeak = "And your clothes are...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Spock";
        textToSpeak = "Captain, this person seems to be in early to mid 21st century clothing.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Spock";
        textToSpeak = "So unless they're a history fanatic...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 13;
    }

    IEnumerator EventThirteen() {
        nextButton.SetActive(false);

        charSide.SetActive(false);
        charMain.SetActive(true);

        mainTextObject.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 14;
    }

    IEnumerator EventFourteen() {
        nextButton.SetActive(false);

        charSide.SetActive(false);
        charMain.SetActive(true);

        mainTextObject.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "!!!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(false);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(the ship jerks again.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Spock";
        textToSpeak = "Captain, it is imperative that we report to the bridge immediately.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charSide.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Kirk";
        textToSpeak = "That's right, time is of the essence, Mr. Spock.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "!!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.SetActive(false);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you follow.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 15;
    }

    IEnumerator EventFifteen() {
        fadeInScreen.SetActive(true);
        nextButton.SetActive(false);

        charMain.SetActive(true);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "(...)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "(Why is the ship in danger anyway?)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charName.GetComponent<TMPro.TMP_Text>().text = " ";
        textToSpeak = "(you land on your but. hard. your vision is a blurry.)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "ugh.... where am i?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        charMain.GetComponent<RawImage>().texture = charMainSprites[9];
        charMain.SetActive(true);

        charName.GetComponent<TMPro.TMP_Text>().text = "You";
        textToSpeak = "kitty?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 7;
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
