using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxHealth(int heal)
    {
        Debug.Log("Set max health");
        health.maxValue = heal;
        health.value = heal;
    }
    public void SetHealth(int heal)
    {
        health.value = heal;
    }
}
