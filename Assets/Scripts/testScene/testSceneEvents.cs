using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // variables
    public GameObject fadeInScreen;
    public GameObject charTest;
    public GameObject npcTest;
    public GameObject textBox;
    [SerializeField] GameObject charName;
    
    [SerializeField] AudioSource audioTest;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

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
        // event 0
        yield return new WaitForSeconds(1);
        fadeInScreen.SetActive(false);
        charTest.SetActive(true);
        yield return new WaitForSeconds(1);

        // text function here
        mainTextObject.SetActive(true);
        textToSpeak = "here im talking like this";
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
        charName.GetComponent<TMPro.TMP_Text>().text = "npcTest";

        yield return new WaitForSeconds(1);
        npcTest.SetActive(true);
        nextButton.SetActive(false);
        textBox.SetActive(true);
        audioTest.Play();
        
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

    IEnumerator EventTwo() {
        charName.GetComponent<TMPro.TMP_Text>().text = "the end";
        textToSpeak = "we are done";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        textCreator.runTextPrint = true;
        eventPos = 1;
    }

    public void NextButton() {
        if (eventPos == 1) {
            StartCoroutine(EventOne());
        }
        else { // (eventPos == 2)
            StartCoroutine(EventTwo());
        }
    }
}
