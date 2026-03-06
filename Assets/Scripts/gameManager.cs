using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    
    public List<Combatant> combatants = new List<Combatant>();
    int currentCombatantIndex = 0;
    public Player player;
    /*  public Enemy enemy;

      public enum GameState
      {
          PlayerTurn = 0,
          EnemyTurn = 1,
      }
      public GameState CurrentState;*/

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
                combatants.RemoveAt(i);
            }
        }
        if (combatants.Count <= 1)
        {
            print("byter scen");
            if (combatants[0].gameObject.tag == "Player")
            {
                print("Byt till victory");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else if (combatants[0].gameObject.tag == "Enemy")
            {
                print("byt till defeat");
                SceneManager.LoadScene(12);
            }
        }
    }

    public void EndTurn()
    {
     //  print("Ending turn for " + combatants[currentCombatantIndex].gameObject.name);
       


          currentCombatantIndex++;
        if (currentCombatantIndex >= combatants.Count)
        {
            currentCombatantIndex = 0;
        }
      //  print("Starting turn for " + combatants[currentCombatantIndex].gameObject.name);
            combatants[currentCombatantIndex].Invoke("StartTurn", 1);
        

    }
}