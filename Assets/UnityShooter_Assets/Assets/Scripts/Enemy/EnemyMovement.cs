using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform trapPos;
    public GameObject trap;
    private Transform player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private NavMeshAgent nav;
    
    public int trapNum = 3;
    EnemyManager enemyManager;


    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        player = EnemyManager.playerChar.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();

    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trap"))
        {
            Debug.Log("Traped");
            nav.Stop();
            DestroyObject(this);
        }
    }

    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.health > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }

        if (trapNum >= 0)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log(trapNum);
                Instantiate(trap, player.position, Quaternion.identity);
                trapNum--;
            }
        }
        
        
    }
}
