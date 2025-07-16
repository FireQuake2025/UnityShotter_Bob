using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth health;
    public float restartDelay = 5f;

    private Animator animator;
    private float restartTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health.health <= 0)
        {
            animator.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("Level 01");
            }
        }
    }
}
