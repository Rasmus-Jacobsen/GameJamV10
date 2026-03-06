using UnityEngine;
using UnityEngine.SceneManagement;
public class Menuscript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // laddar nästa scen 
    }
    public void ExitGame()
    {
        Application.Quit(); // stänger ner applikationen(spelet)
    }
}
