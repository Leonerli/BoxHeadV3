using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public float health = 500f;

    void Start()
    {
        health = 500f;
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
        //Destroy(gameObject);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
