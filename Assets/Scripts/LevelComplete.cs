using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    void Update()
    {
        if ( Input.GetKey("r") )
        {
            FindObjectOfType<GameManager>().Restart();
        }

        if ( Input.GetKey(KeyCode.Return) )
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
