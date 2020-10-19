using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToUpgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
