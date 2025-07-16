using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private Screen screen;
    private void Update()
    {
        
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Level 01");
        }
    }
}
