using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float speed = 22.0f;
    private float xRange = 20.0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Left-Right Boundary
        if(Mathf.Abs(transform.position.x) > xRange)
        {
            float leftOrRight = transform.position.x / (Mathf.Abs(transform.position.x));
            transform.position = new Vector3(xRange * leftOrRight, transform.position.y, transform.position.z);
        }
        
        //Move left-right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Fire Projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Fire
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }
}
