using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player player;
    public Enemy enemy;

    public List<MonoBehaviour> combatants = new List<MonoBehaviour>();
    int currentCombatantIndex = 0;
    public enum GameState
    {
        PlayerTurn = 0,
        EnemyTurn = 1
    }
    public GameState CurrentState;

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
        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        CurrentState = GameState.PlayerTurn;
        player.StartTurn();
        Debug.Log("Player's Turn!");
    }

    public void StartEnemyTurn()
    {
        CurrentState = GameState.EnemyTurn;
        enemy.StartTurn();
        Debug.Log("Enemy's Turn!");
    }

    public void EndTurn()
    {
        if (CurrentState == GameState.PlayerTurn)
        {
            StartEnemyTurn();
        }
        else if (CurrentState == GameState.EnemyTurn)
        {
            StartPlayerTurn();
        }
    }
}