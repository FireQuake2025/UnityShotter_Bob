using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public float spawnTime = 3;
    public Transform[] spawnPoints;
    public static GameObject playerChar;
    private float waveTime = 10;


    
    public void Awake()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Timer()); 
    }

    public void Update()
    {
        
    }

    


    public void Spawn(int spawnEnemy, int spawnCount)
    {
        if (playerHealth.health <= 0)
        {
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy[spawnEnemy], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }

   
    // this is messy but dont know how else to do this
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Spawn(0, 3);
        yield return new WaitForSeconds(waveTime);
        Spawn(1, 3);
        yield return new WaitForSeconds(waveTime);
        Spawn(2, 1);
        yield return new WaitForSeconds(waveTime);
        Spawn(1, 3);
        Spawn(2, 1);
        yield return new WaitForSeconds(waveTime);
        Spawn(0, 5);
        Spawn(1, 3);
        yield return new WaitForSeconds(waveTime);
        Spawn(1, 3);
        Spawn(2, 2);
        yield return new WaitForSeconds(waveTime);
        Spawn(0, 4);
        Spawn(1, 2);
        Spawn(2, 1);
        yield return new WaitForSeconds(waveTime);
        Spawn(0, 7);
        Spawn(1, 5);
        yield return new WaitForSeconds(waveTime);
        Spawn(2, 5);
        yield return new WaitForSeconds(waveTime);
        Spawn(1, 5);
        Spawn(0, 10); 
        yield return new WaitForSeconds(waveTime);
        Spawn(0, 10);
        Spawn(1, 6);
        Spawn(2, 3);
    }


}
