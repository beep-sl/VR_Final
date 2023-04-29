using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public float health;

    public LayerMask whatIsGround, whatIsPlayer;

    // Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        Debug.Log("Awake1()");
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Awake()");
    }

    private void Update() {
        //kwalkPointSet = false;
        Debug.Log("Update()");
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) {
            Debug.Log("Patrolling()");
            Patrolling();
        }

        if (playerInSightRange && !playerInAttackRange) {
            Debug.Log("chase()");
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange) {
            Debug.Log("attack()");
            AttackPlayer();
        }
    }

    private void Patrolling() {
        Debug.Log("called Patrolling()");
        if (!walkPointSet) {

            SearchWalkPoint();
        }

        if (walkPointSet) {
            Debug.Log("Walk point:" + walkPoint);
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() {
        Debug.Log("SearchWalkPoint()");
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //Debug.Log(walkPoint);
        walkPointSet = true;
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet = false;
            Debug.Log("walkpoint true");
        } else {
            Debug.Log("walkpoint sad");
        }
    }

    private void ChasePlayer() {
        Debug.Log("ChasePlayer()");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer() {
        Debug.Log("AttackPlayer()");
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked) {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(270, 0, 0))).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 8f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        Debug.Log("ResetAttack()");
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage) {
        Debug.Log("TakeDamage()");
        health -= damage;

        if (health <= 0) {
            Invoke(nameof(DestroyEnemy), .5f);
        }
    }

    private void DestroyEnemy() {
        Debug.Log("DestroyEnemy()");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Debug.Log("Gizmos()");
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
