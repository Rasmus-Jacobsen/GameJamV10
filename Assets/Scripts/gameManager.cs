using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // RASMUS

    public static GameManager Instance { get; private set; }


    public List<Combatant> combatants = new List<Combatant>(); // En lista av all a fiender och spelare i scenen

    int currentCombatantIndex = 0;
    public Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentCombatantIndex = 0;
        combatants[currentCombatantIndex].StartTurn();
    }

    private void Update()
    {
        for (int i = 0; i < combatants.Count; i++)
        {
            if (combatants[i] == null)
            {
                combatants.RemoveAt(i); // om en combatant har dött så tas den bort från listan
            }
        }
        if (combatants.Count <= 1)
        {
            print("byter scen");
            if (combatants[0].gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // om det bara finns en combatant kvar och den är spelaren så laddas nästa scen

            }
            else if (combatants[0].gameObject.tag == "Enemy")
            {
                SceneManager.LoadScene(12); // om det bara finns en combatant kvar och den är en fiende så laddas scenen med index 12, som är en game over scen
            }
        }
    }

    public void EndTurn()
    {

        currentCombatantIndex++;
        if (currentCombatantIndex >= combatants.Count) 
        {
            currentCombatantIndex = 0;  // omsätter index till 0 när det når slutet av listan, så att det börjar om från början
        }

        combatants[currentCombatantIndex].Invoke("StartTurn", 1); // startar nästa combatants tur efter en kort cooldown


    }
}