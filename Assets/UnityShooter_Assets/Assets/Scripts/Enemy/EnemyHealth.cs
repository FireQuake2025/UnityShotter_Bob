using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public  class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sink = 2.5f;
    public int score = 10;
    public AudioClip deathClip;
    public GameObject[] enemeyDrop;
    public VariableDeclaration[] copy;
    


    Animator animator;
    AudioSource enemyAudio;
    ParticleSystem hit;
    CapsuleCollider capsuleColillider;
    public bool isDead;
    bool isSinking;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hit = GetComponentInChildren<ParticleSystem>();
        capsuleColillider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sink * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead) return;
        enemyAudio.Play();
        currentHealth -= amount;
        hit.transform.position = hitPoint;
        hit.Play();

        if (currentHealth <= 0)
        {
            Death();
            
        }
        void Death()
        {
            isDead = true;
            animator.SetTrigger("Dead");
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
            int drop = Random.Range(0, 4);
            var copy = Instantiate(enemeyDrop[drop], transform.position, transform.rotation);
            Instantiate(copy, transform.position, transform.rotation);
        }
    }

        public void StartSinking()
    {
        
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += score;
        ScoreManager.Instance.ShowScore();
        Destroy(gameObject, 2f);

    }

    
}
