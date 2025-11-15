using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 100f;
    public GameObject playerPivot;
    public GameManager gameManager;

    void Start()
    {
        Debug.Assert(playerPivot != null);
        Debug.Assert(gameManager != null);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPivot.transform.Rotate(0f, 0f, -playerSpeed * Time.deltaTime);
            // Debug.Log("A has been pressed.");
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            playerPivot.transform.Rotate(0f, 0f, playerSpeed * Time.deltaTime);
            // Debug.Log("D has been pressed.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Player has collided!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("Player has collided with enemy!");
            gameManager.FailGame();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Collect"))
        {
            // Debug.Log("Player has collided with capsule!");
            gameManager.IncrementScore();
            Destroy(collision.gameObject);
        }
    }
}
