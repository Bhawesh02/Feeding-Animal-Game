using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHealthBar : MonoBehaviour
{
    public HealthBar healthBar;
    private int animalHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(animalHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        animalHealth -= 1;
        healthBar.SetHealth(animalHealth);
        if(animalHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
