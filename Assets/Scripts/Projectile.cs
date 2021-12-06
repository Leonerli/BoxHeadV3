using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Transform player;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           Debug.Log("Player detected");
           player = GameObject.Find("Player").transform;
           TargetPlayer target = player.transform.GetComponent<TargetPlayer>();
           if (target != null)
            {
                Debug.Log("player should take damage: " + damage);
                target.TakeDamage(damage);
            }
        
        }

        gameObject.SetActive(false);

    }
}
