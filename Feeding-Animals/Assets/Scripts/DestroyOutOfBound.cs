using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 25.0f;
    private float bellowBound = -5.0f;
    private float sideBound = 28.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bellowBound)
        {
            PlayerController.playerLives -= 1;
            Debug.Log("Lives = " + PlayerController.playerLives);

            Destroy(gameObject);
        }
        if (transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }
    }
}
