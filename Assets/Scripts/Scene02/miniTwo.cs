using UnityEngine;

public class miniTwo : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    //public GameObject enemy2;
    //public GameObject enemy3;    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null) {
            ChasePlayer();
        } */
    }

    void ChasePlayer() { // raycast
        // add slight speed to enemy & make their target the player
    }

    void CatchPlayer() {
        // ppayer los4
    }
}
