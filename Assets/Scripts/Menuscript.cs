using UnityEngine;
using UnityEngine.SceneManagement;
public class Menuscript : MonoBehaviour
{

    [SerializeField] 
        GameObject credits, ingameMenu, map;




    // RASMUS

    public void PlayGame()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // laddar nästa scen 
    }
    public void ExitGame()
    {
        AudioManager.Instance.PlayButtonClick();
        Application.Quit(); // stänger ner applikationen(spelet)
    }
    public void Retry() 
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(0); 

    }
    public void OpenCredits()
    {
        AudioManager.Instance.PlayButtonClick();
        credits.SetActive(true);
    }
    public void CloseCredits()
    {
        AudioManager.Instance.PlayButtonClick();
        credits.SetActive(false);
    }

    public void OpenMap()
    {
        AudioManager.Instance.PlayButtonClick();
        map.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseMap()
    {
        AudioManager.Instance.PlayButtonClick();
        map.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenIngameMenu()
    {
        AudioManager.Instance.PlayButtonClick();
        ingameMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseIngameMenu()
    {
        AudioManager.Instance.PlayButtonClick();
        ingameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ButtonClickSound()
    {
        AudioManager.Instance.PlayButtonClick();
    }
}