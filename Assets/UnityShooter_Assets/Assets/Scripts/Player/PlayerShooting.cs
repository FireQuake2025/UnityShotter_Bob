using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShoot = 20;
    public int damageBoost;
    public float timeBetweenBullets = .15f;
    public float range = 100;
    public GameObject boostPack;
    public bool pickUp = false;
    public Mesh boostDes;
    public int ammo;
    public int maxAmmo = 10;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI gunTypeText;

    private float currentFiringTime;
    private Ray shootRay;
    private RaycastHit hitShoot;
    private int shootableMask;
    private ParticleSystem gunParticals;
    private LineRenderer gunLine;
    private AudioSource gunAudio;
    private Light gunLight;
    

    private void Awake()
    {
        gunTypeText.text = "Pistol";
        ammo = maxAmmo;
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticals = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }
    private void Update()
    {
        
        if (0 <= ammo)
        {
            currentFiringTime += Time.deltaTime;
            ammoText.text = "Ammo: " + (ammo);
            if (Input.GetButtonDown("Fire1") && currentFiringTime >= timeBetweenBullets && PauseGame.isPaused != true)
            {
                Shoot();
                ammo--;      
            }
            if (currentFiringTime >= timeBetweenBullets)
            {
                DisableEffect();
            }

        }
    }
    void Shoot()
    {
        currentFiringTime = 0;
        gunAudio.Play();
        gunLight.enabled = true;
        gunParticals.Stop();
        gunParticals.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out hitShoot, range, shootableMask))
        {
            EnemyHealth enemyHealth = hitShoot.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damagePerShoot, hitShoot.point);
            }
            gunLine.SetPosition(1,hitShoot.point);
        }
        else
        {
            gunLine.SetPosition(1,shootRay.origin = shootRay.direction * range);
        }
    }

    public void DisableEffect()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DamageBoost"))
        {
            Debug.Log("Hello");
            Destroy(other.gameObject);
            damagePerShoot += damageBoost;
            StartCoroutine(Timer(10));
        }
        if (other.CompareTag("Ammo"))
        {
            Debug.Log("Hello");
            Destroy(other.gameObject);
            ammo = maxAmmo;
        }
        if (other.CompareTag("Pistol"))
        {
            gunTypeText.text = "Pistol"; 
            maxAmmo = 10;
            ammo = maxAmmo;
        }
        if (other.CompareTag("Ak"))
        {
            gunTypeText.text = "AK";
            damagePerShoot = 10;
            maxAmmo = 30;
            ammo = maxAmmo;
        }
        if (other.CompareTag("Shotgun"))
        {
            gunTypeText.text = "Shotgun";
            damagePerShoot = 50;
            maxAmmo = 4;
            ammo = maxAmmo;
        }
    }


    IEnumerator Timer(float boostDuration)
    {
        yield return new WaitForSeconds(boostDuration);
        damagePerShoot = damagePerShoot * 2;
        Debug.Log("Finish Damage Boost");
    }
}
