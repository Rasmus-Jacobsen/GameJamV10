using UnityEngine;
using UnityEngine.SceneManagement;
public class Menuscript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
