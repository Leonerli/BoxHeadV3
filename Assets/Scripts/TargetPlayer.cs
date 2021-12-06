using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPlayer : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;

    public GameObject healthBarUI;
    public Slider slider;
    public Transform cam;
    public Text diedisplay;

    void Start()
    {
        health = 50f;
        maxHealth = health;
        slider.value = CalculateHealth();
        diedisplay.text = "";
    }

    void Update()
    {
        slider.value = CalculateHealth();
        
        healthBarUI.transform.LookAt(cam);
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("new health:" + health);
        if (health <= 0f)
        {
            Debug.Log("I die now :(");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");
        diedisplay.text = "GAME OVER!";
        //Destroy(gameObject);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
