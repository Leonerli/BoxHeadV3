using UnityEngine;

public class gun_wichtcam : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f;

    public Camera fpsCam;

    public GameObject muzzle;

    public ParticleSystem muzzleFlash;

    void Start()
    {
        //muzzle.active = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
        else
        {
            if (muzzle.active)
            {
                muzzle.SetActive(false);
            }
            
        }
    }

    void shoot()
    {
        muzzleFlash.Play();

        muzzle.SetActive(true);



        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target =  hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }


}
