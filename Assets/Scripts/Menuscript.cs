using UnityEngine;
using UnityEngine.SceneManagement;
public class Menuscript : MonoBehaviour
{

    [SerializeField] 
        GameObject credits, ingameMenu, map;


    // RASMUS

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // laddar nästa scen 
    }
    public void ExitGame()
    {
        Application.Quit(); // stänger ner applikationen(spelet)
    }
    public void Retry() 
    {
       SceneManager.LoadScene(0); 

    }
    public void OpenCredits()
    {
        credits.SetActive(true);
    }
    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void OpenMap()
    {
        map.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseMap()
    {
        map.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenIngameMenu()
    {
        ingameMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseIngameMenu()
    {
        ingameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}