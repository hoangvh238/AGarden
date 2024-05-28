using UnityEngine.SceneManagement;
using UnityEngine;

public class ManageButtom : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
