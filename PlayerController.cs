using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 8.0f;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver){
            return;
        }

        Movement(); 
        Boundry();
    }

    //method to contol our player
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    
    // player can't go out of the scene
    void Boundry()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y);
        }
    } 

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("ExtraLive")) {
        gameManager.UpdateLives(1);
        Destroy(other.gameObject);
        }
    }
}
