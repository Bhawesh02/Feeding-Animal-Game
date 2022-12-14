using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed = 22.0f;
    private float xRange = 20.0f;
    private float zRangeTop = 10.0f;
    private float zRangeBottom = 0;
    private float projectionDistFromPlayer = 1.5f;
    public static int playerLives = 5;
    public static int playerScore = 0;
    public GameObject projectilePrefab;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(playerLives);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives == 0)
        {
            Debug.Log("Game Over");
        }

        healthBar.SetHealth(playerLives);
        healthBar.transform.position = new Vector3(transform.position.x + 0.09f, transform.position.y + 3.655f, transform.position.z + -0.5f);
        // Left-Right Boundary
        if (Mathf.Abs(transform.position.x) > xRange)
        {
            float leftOrRight = transform.position.x / (Mathf.Abs(transform.position.x));
            transform.position = new Vector3(xRange * leftOrRight, transform.position.y, transform.position.z);
        }
        
        //top-Bottom Boundary
        if(transform.position.z > zRangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
        }
        if (transform.position.z < zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBottom);
        }

        //Move left-right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Move top-bottom
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //Fire Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 projectilePos = new Vector3(transform.position.x, transform.position.y, transform.position.z + projectionDistFromPlayer);
            //Fire
            Instantiate(projectilePrefab, projectilePos , projectilePrefab.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerLives -= 1;
    }
}
