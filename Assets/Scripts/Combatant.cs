using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int health = 80;
    public int attackPower = 15;

    public virtual void StartTurn()
    {
    }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Enemy takes {damage} damage, HP left: {health}");
        if (health <= 0) Debug.Log("Enemy defeated!");

    }
    public void Death()
    {
        Debug.Log("Enemy has been defeated!");

        Destroy(gameObject);
    }
}
