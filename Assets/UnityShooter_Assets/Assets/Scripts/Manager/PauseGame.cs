using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuUi;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Pause()
    {
        menuUi.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnPause()
    {
        menuUi.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }


    public void QuitGame()
    {
        SceneManager.LoadScene("Intro");
        Debug.Log("Quiting Game...");
    }


}
