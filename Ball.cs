using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float force;
    public bool inPlay;
    public Transform player;
    public Transform explosion;
    public Transform powerUp;
    public GameManager gameManager;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver){
            return;
        }

    // Starting position.
        if (!inPlay)
        {
            transform.position = player.position;
        }

    // Start game.
        if (Input.GetButtonDown ("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce (Vector2.up * force);
        }
    }

    // If ball fall down the screen - game over.
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag ("OutOfScene"))
        {
            Debug.Log("GameOver");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.UpdateLives (-1);
        }
    } 

    // Destroy brick by collision with them and add explosion participle. 
    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag ("Brick"))
        {
            Brick brickScript = other.gameObject.GetComponent<Brick>(); 

            if(brickScript.hitsToBreak > 1){
                brickScript.BreakBrick();
                
            } else {

                int randChance = Random.Range(1, 101);

                if (randChance < 10) {
                Instantiate(powerUp, other.transform.position, other.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);

                Destroy (newExplosion.gameObject, 2.5f);

                gameManager.UpdateScore(brickScript.points);

                gameManager.UpdateNumberOfBricks();

                Destroy (other.gameObject);

            }

            audio.Play();
        }
    }
}
