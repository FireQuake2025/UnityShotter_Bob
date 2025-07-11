using System.Collections;
using UnityEngine;

public class DamageBoost : MonoBehaviour
{
    PlayerShooting bullet;
    public GameObject boost;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageBoost"))
        {
            bullet.damagePerShoot += bullet.damageBoost;
            StartCoroutine(Timer(10));
        }
    }

    IEnumerator Timer(float boostDuration)
    {
        yield return new WaitForSeconds(boostDuration);
        bullet.damagePerShoot = 20;
        Debug.Log("Finish Damage Boost");
        yield return new WaitForSeconds(boostDuration);
        
    }
}
