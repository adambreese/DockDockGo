using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotationSpeed = 75f;
    private float moveSpeed = 15f;
    private SpawnManager spawnManager;
    private GameManager gameManager;
    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotation:
        
        if (Input.GetKey(KeyCode.Q))
        {
          transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        
        //Movement:

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Station"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.GameOver(); 
        }

    }
}
