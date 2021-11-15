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
           Target target = player.transform.GetComponent<Target>();
           if (target != null)
            {
                target.TakeDamage(damage);
            }
        
        }

        Destroy(gameObject);

    }
}
