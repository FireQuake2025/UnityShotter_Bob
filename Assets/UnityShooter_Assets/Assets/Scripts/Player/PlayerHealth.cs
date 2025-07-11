using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int health;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashspeed = 5.0f;
    public Color flashColor = new Color(1, 0, 0,  .1f);
    public int healthAdd = 10;

    Animator animator;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    public bool isDead;
    public bool damaged;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        health = startingHealth;
    }

    private void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void TakeDamage (int amount)
    {
        damaged= true;
        health -= amount;
        healthSlider.value = health;
        playerAudio.Play();
        if (health <= 0 && !isDead)
        {
            Death();
        }

}

    private void Death()
    {
        isDead = true;
        playerShooting.DisableEffect();
        animator.SetTrigger("Die");
        playerAudio.Play();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Code");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPack"))
        {
            if(health < startingHealth)
            {
                Destroy(other.gameObject);
                health += healthAdd;
                healthSlider.value += healthAdd;
            }
            
        }
    }
}
