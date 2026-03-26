using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class miniOne : MonoBehaviour
{ 
    // player
    public Slider playerHealthbar;
    public TMP_Text playerHealthText;
    public float playerHealth = 7;
    public float playerShield = 0;
    public float playerPower = 0;
    public GameObject playerButtons;
    public GameObject playerWarning;

    // enemy
    public Slider enemyHealthbar;
    public TMP_Text enemyHealthText;
    public float enemyHealth = 7;
    public float enemyShield = 0;
    public float enemyPower = 0;
    public int enemyChoice;

    // general
    public float maxHealth = 7;
    public string doer = "Player";
    public float turn = 0;
    public TMP_Text actionMade;
    public float start = 0;
    // public float wait = 0;

    void Start()
    {

        // loop while ALL health over 0, ends when EITHER health reaches 0/below (only display 0)
        // player turn; set buttons active then set false after one thing is pressed
        // enemy turn; buttons false and random choice made (can change to add more likely on a specific option based on health/power/shields)
        // change "doer" here

        
    }

    void Update()
    {
        playerHealthText.text = playerHealth + " / " + maxHealth;
        playerHealthbar.value = playerHealth/maxHealth;

        enemyHealthText.text = enemyHealth + " / " + maxHealth;
        enemyHealthbar.value = enemyHealth/maxHealth;

        Debug.Log(turn);
        Debug.Log(doer);

        if (start == 0) {
            start = 1;
            TurnChoice();
        } else {
            // StartCoroutine(ActionReport());
        }
        
        if (enemyHealth <= 0) { // player win msg & animation
            enemyHealth = 0; // next scene load
        } else if (playerHealth <= 0) { // player lopse msg
            playerHealth = 0;
            // play lose msg + set back to start so redo scene
        }

        /* if (playerHealth > 0 && enemyHealth > 0) {
            if (turn == 0) {
                doer = "Player";
                playerWarning.SetActive(false);
                playerButtons.SetActive(true);
                // actionMade.text = "";
            }
            else if (turn == 1) {
                doer = "Enemy";
                playerWarning.SetActive(false);
                playerButtons.SetActive(false);
                // actionMade.text = "";
                enemyChoice = Random.Range(1, 4);
                if (enemyChoice == 1) {
                    PowerUp();
                } else if (enemyChoice == 2) {
                    Shield();
                } else if (enemyChoice == 3) {
                    Attack();
                }
            }
        }
        if (enemyHealth <= 0) { // player win msg & animation
            enemyHealth = 0; // next scene load
        } else if (playerHealth <= 0) { // player lopse msg
            playerHealth = 0;
            // play lose msg + set back to start so redo scene
        } */
    }

    public void TurnChoice() {
        if (start > 0) {
            StartCoroutine(ActionReport());
        }
        if (playerHealth > 0 && enemyHealth > 0) {
            if (turn == 0) {
                doer = "Player";
                playerWarning.SetActive(false);
                playerButtons.SetActive(true);
                // actionMade.text = "";
            }
            else if (turn == 1) {
                doer = "Enemy";
                playerWarning.SetActive(false);
                playerButtons.SetActive(false);
                // actionMade.text = "";
                enemyChoice = Random.Range(1, 4);
                if (enemyChoice == 1) {
                    PowerUp();
                } else if (enemyChoice == 2) {
                    Shield();
                } else if (enemyChoice == 3) {
                    Attack();
                }
            }
        }
        
    }

    public void Attack() {
        ; // change amount of health changed based on shield level; check for required power before actually allowing action otherwise display warning
        if (doer == "Player") {
            if (playerPower <= 0) { // not allowed to attack, display warning
                playerWarning.SetActive(true);
            } else if (playerPower > 0) { // get rid of shield first then health with it representing in the variables too 
                if (enemyShield > 0) {
                    enemyShield = enemyShield - 2;
                    if (enemyShield < 0) {
                        enemyShield = 0;
                        enemyHealth = enemyHealth -1;
                        actionMade.text = "You attacked! Got rid of shields and did 1 damage.";
                    } else {
                        actionMade.text = "You attacked! Got rid of shields.";
                    }
                } else {
                    enemyHealth = enemyHealth - 2;
                    actionMade.text = "You attacked! Did 2 damage.";
                }
            }
            turn = 1;
        }
        else if (doer == "Enemy") {
            if (enemyPower <= 0) {
                enemyChoice = Random.Range(1, 3);
            } else if (enemyPower > 0) {
                if (playerShield > 0) {
                    playerShield = playerShield - 2;
                    if (playerShield < 0) {
                        playerShield = 0;
                        playerHealth = playerHealth - 1;
                        actionMade.text = "Enemy attacked! Got rid of your shields and did 1 damage.";
                    } else {
                        actionMade.text = "Enemy attacked! Got rid of your shields.";
                    }
                } else {
                    playerHealth = playerHealth - 2;
                    actionMade.text = "Enemy attacked! Did 2 damage.";
                }
            }
            turn = 0;
        }
        TurnChoice();
    }

    public void PowerUp() {
        ; // required for Attack, +1
        if (doer == "Player") {
            playerPower = playerPower + 1;
            actionMade.text = "You powered up!";
            turn = 1;
        }
        else if (doer == "Enemy") {
            enemyPower = enemyPower + 1;
            actionMade.text = "Enemy powered up!";
            turn = 0;
        }
        TurnChoice();
    }

    public void Shield() {
        ; // shields + 1
        if (doer == "Player") {
            playerShield = playerShield + 1;
            actionMade.text = "You shielded!";
            turn = 1;
        }
        else if (doer == "Enemy") {
            enemyShield = enemyShield + 1;
            actionMade.text = "Enemy shielded!";
            turn = 0;
        }
        TurnChoice();
    }

    IEnumerator ActionReport() {
        // what player/enemy did
        playerWarning.SetActive(false);
        playerButtons.SetActive(false);
        yield return new WaitForSeconds(10f);
    }

}
