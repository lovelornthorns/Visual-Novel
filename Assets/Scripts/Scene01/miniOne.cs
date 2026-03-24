using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class miniOne : MonoBehaviour
{ // REPLACE SQUARES of the temp player/enemy
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

    void Start()
    {

        // loop while ALL health over 0, ends when EITHER health reaches 0/below (only display 0)
        // player turn; set buttons active then set false after one thing is pressed
        // enemy turn; buttons false and random choice made (can change to add more likely on a specific option based on health/power/shields)
        // change "doer" here

        while (playerHealth > 0 && enemyHealth > 0) {
            if (turn == 0) {
                doer = "Player";
                playerWarning.SetActive(false);
                playerButtons.SetActive(true);
            }
            else if (turn == 1) {
                doer = "Enemy";
                playerWarning.SetActive(false);
                playerButtons.SetActive(false);
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
        }
    }

    void Update()
    {
        playerHealthText.text = playerHealth + " / " + maxHealth;
        playerHealthbar.value = playerHealth/maxHealth;

        enemyHealthText.text = enemyHealth + " / " + maxHealth;
        enemyHealthbar.value = enemyHealth/maxHealth;
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
                    }
                } else {
                    enemyHealth = enemyHealth - 2;
                    turn = 1;
                }
            }
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
                    }
                } else {
                    playerHealth = playerHealth - 2;
                    turn = 0;
                }
            }
        }
    }

    public void PowerUp() {
        ; // required for Attack, +1
        if (doer == "Player") {
            playerPower = playerPower + 1;
            turn = 1;
        }
        else if (doer == "Enemy") {
            enemyPower = enemyPower + 1;
            turn = 0;
        }
    }

    public void Shield() {
        ; // shields + 1
        if (doer == "Player") {
            playerShield = playerShield + 1;
            turn = 1;
        }
        else if (doer == "Enemy") {
            enemyShield = enemyShield + 1;
            turn = 0;
        }
    }
}
