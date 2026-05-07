using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class miniOne : MonoBehaviour
{ 
    // player
    public Slider playerHealthbar;
    public TMP_Text playerHealthText;
    public float playerHealth;
    public float playerShield;
    public float playerPower;
    public TMP_Text playerShieldNum;
    public TMP_Text playerPowerNum;
    public GameObject playerButtons;
    // public GameObject playerWarning; // i dont need this because i can just change the action text ??

    // enemy
    public Slider enemyHealthbar;
    public TMP_Text enemyHealthText;
    public float enemyHealth;
    public float enemyShield;
    public float enemyPower;
    public float endam;
    public TMP_Text enemyShieldNum;
    public TMP_Text enemyPowerNum;
    public int enemyChoice;

    // general
    public float maxHealth;
    public string doer = "Player";
    public TMP_Text actionMade;
    public TMP_Text actionTurn;
    // public float start = 0;
    // public bool BothLive = true;
    // public float wait = 0;
    public GameObject mainScreen;
    public GameObject loseScreen;
    public GameObject winScreen;

    void Start() // zoom into the computer screen while fading into this ; enemy start w 5 shield we start w 1, maxhealth = 15
    {
        mainScreen.SetActive(true);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);

        playerHealth = 15;
        playerShield = 1;
        playerPower = 0;
        enemyHealth = 15;
        enemyShield = 3;
        enemyPower = 0;
        maxHealth = 15;

        // loop while ALL health over 0, ends when EITHER health reaches 0/below (only display 0)
        // player turn; set buttons active then set false after one thing is pressed
        // enemy turn; buttons false and random choice made (can change to add more likely on a specific option based on health/power/shields)
        // change "doer" here

        /* start = player turn
        player turn just activates buttons
        press button = deactivate buttons & starts enemy turn  (coroutine to disply player action?)
        enemy turn = coroutine with built in wait periods
        end of enemy turn = player turn
        repeat (not while loop or update func)
        keep health in update function + time.timescale(0f) ? to stop it from continuing loop maybe
        */
    }

    void Update()
    {
        // health 
        playerHealthText.text = playerHealth + " / " + maxHealth;
        playerHealthbar.value = playerHealth/maxHealth;

        enemyHealthText.text = enemyHealth + " / " + maxHealth;
        enemyHealthbar.value = enemyHealth/maxHealth;

        // shield & power num
        playerPowerNum.text = playerPower + "";
        playerShieldNum.text = playerShield + "";

        enemyPowerNum.text = enemyPower + "";
        enemyShieldNum.text = enemyShield + "";

        actionTurn.text = doer + "'s Turn";

        if (enemyHealth <= 0) { // player win msg & animation
            enemyHealth = 0; // next scene load + explosion animation (forest)
            StartCoroutine(Win());
        } else if (playerHealth <= 0) { // player lopse msg
            playerHealth = 0;
            StartCoroutine(Lose());
            // play lose msg + set back to start so redo scene like reload scene ?
        }
    }

    public void PlayerTurn() {
        doer = "Player";
        playerButtons.SetActive(true);
    }

    IEnumerator EnemyTurn() {
        doer = "Enemy";
        playerButtons.SetActive(false);
        yield return new WaitForSeconds(2f);
        enemyChoice = Random.Range(1, 4);
        if (enemyChoice == 1) {
            PowerUp();
        } else if (enemyChoice == 2) {
            Shield();
        } else if (enemyChoice == 3) {
            Attack();
        }
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    public void Attack() {
        ; // change amount of health changed based on shield level; check for required power before actually allowing action otherwise display warning
        if (doer == "Player") {
            if (playerPower <= 0) { // not allowed to attack, display warning
                actionMade.text = "No power! Can't attack enemy!";
            } else if (playerPower > 0) { // get rid of shield first then health with it representing in the variables too 
                if (enemyShield > 0) {
                    enemyShield = enemyShield - 2;
                    if (enemyShield < 0) {
                        enemyShield = 0;
                        enemyHealth = enemyHealth -1;
                        actionMade.text = "You attacked! Got rid of shields and did 1 damage.";
                    } else {
                        actionMade.text = "You attacked! Decreased shields.";
                    }
                } else {
                    enemyHealth = enemyHealth - 2;
                    actionMade.text = "You attacked! Did 2 damage.";
                }
                playerPower = playerPower - 1;
                StartCoroutine(EnemyTurn());
        }
            }
        else if (doer == "Enemy") {
            if (enemyPower <= 0) {
                enemyChoice = Random.Range(1, 3);
                if (enemyChoice == 1) {
                    PowerUp();
                } else if (enemyChoice == 2) {
                    Shield();
                }
            } else if (enemyPower > 0) {
                if (playerShield > 0) {
                    endam = Random.Range(1, 3);
                    playerShield = playerShield - endam;
                    if (playerShield < 0) {
                        playerShield = 0;
                        playerHealth = playerHealth - 1;
                        actionMade.text = "Enemy attacked! Got rid of your shields and did 1 damage.";
                    } else {
                        actionMade.text = "Enemy attacked! Decreased your shields.";
                    }
                } else {
                    if(endam == 2){
                        playerHealth = playerHealth - 2;
                        actionMade.text = "Enemy attacked! Did 2 damage.";
                    }
                    else if(endam == 1){
                        playerHealth = playerHealth - 1;
                        actionMade.text = "Enemy attacked! Did 1 damage.";
                    }
                }
            }
        }
    }

    public void PowerUp() {
        ; // required for Attack, +1
        if (doer == "Player") {
            playerPower = playerPower + 1;
            actionMade.text = "You powered up!";
            StartCoroutine(EnemyTurn());
        }
        else if (doer == "Enemy") {
            enemyPower = enemyPower + 1;
            actionMade.text = "Enemy powered up!";
        }
    }

    public void Shield() {
        ; // shields + 1
        if (doer == "Player") {
            playerShield = playerShield + 1;
            actionMade.text = "You shielded!";
            StartCoroutine(EnemyTurn());
        }
        else if (doer == "Enemy") {
            enemyShield = enemyShield + 1;
            actionMade.text = "Enemy shielded!";
        }
    }

    IEnumerator ActionReport() {
        playerButtons.SetActive(false);
        yield return new WaitForSeconds(10f);
    }

    IEnumerator Win() {
        mainScreen.SetActive(false);
        winScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Lose() {
        mainScreen.SetActive(false);
        loseScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

    public void Replay() {
        SceneManager.LoadScene(2);
    }

    public void Restart(){
        SceneManager.LoadScene(1);
    }

}
