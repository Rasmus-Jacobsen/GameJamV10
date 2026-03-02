using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 80;
    public int attackPower = 15;

    public void StartTurn()
    {
        // Simple AI: always attack
        Player player = GameManager.Instance.player;
        player.health -= attackPower;
        Debug.Log($"Enemy attacked! Player health: {player.health}");
        GameManager.Instance.EndTurn();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Enemy takes {damage} damage, HP left: {health}");
        if (health <= 0) Debug.Log("Enemy defeated!");
       
    }
    public void Death()
    {
            Debug.Log("Enemy has been defeated!");
            // Add death animation or effects here
            Destroy(gameObject);
    }
}