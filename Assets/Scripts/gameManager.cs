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
        combatants[currentCombatantIndex].StartTurn();
    }

    /*  public void StartPlayerTurn()
      {
          CurrentState = GameState.PlayerTurn;
          player.StartTurn();
          Debug.Log("Player's Turn!");
      }

      public void StartEnemyTurn()
      {
          CurrentState = GameState.EnemyTurn;
         Enemy.FindAnyObjectByType<Enemy>().StartTurn();
          Debug.Log("Enemy's Turn!");
      }*/

    public void EndTurn()
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
            if (combatants[0].gameObject.tag == "Player")
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (combatants[0].gameObject.tag == "Enemy")
            {
                SceneManager.LoadScene(12);
            }
        currentCombatantIndex++;
        if (currentCombatantIndex >= combatants.Count)
        {
            currentCombatantIndex = 0;
        }
        print("Starting turn for " + combatants[currentCombatantIndex].gameObject.name);
        combatants[currentCombatantIndex].Invoke("StartTurn", 1);// .StartTurn();
        }

    }
}