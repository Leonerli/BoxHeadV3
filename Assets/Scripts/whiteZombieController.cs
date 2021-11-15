
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class whiteZombieController
    : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    public float damage;
    public float countdown = 1.0f;

    float stopwatch = 0.0f;
    

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange)
        {
            
            AttackPlayer();
        }
    }
    private void Patroling()
    {
        stopwatch = 0;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        stopwatch = 0;
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 targetposition = new Vector3(player.position.x, 0.0f, player.position.z);

        transform.LookAt(targetposition);

        //Debug.Log("pos1");

        //IEnumerator ExecuteAfterTime(float time)
        stopwatch += Time.deltaTime;
        if(stopwatch >= countdown)
        {
            // yield return new WaitForSeconds(countdown);
            stopwatch = 0;
            // Code to execute after the delay
            //Debug.Log("yes...");

            if (!alreadyAttacked)
            {
                //Vector3 off = (0.0, 1.0, 0.0);
                ///Attack code heretransform.position +
                //Rigidbody rb = Instantiate(projectile, off, Quaternion.identity).GetComponent<Rigidbody>();
                // rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
                //rb.AddForce(transform.up * 1f, ForceMode.Impulse);
                ///End of attack code
                ///

                Target target = player.transform.GetComponent<Target>();

                


                //Debug.Log("test1");
                if (playerInAttackRange)
                {
                    //Debug.Log("test2");
                    if (target != null)
                    {
                        target.TakeDamage(damage);
                    }
                }

                

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

