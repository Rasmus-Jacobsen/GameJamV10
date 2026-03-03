using UnityEngine;

public class Enemy : Combatant
{
    public override void StartTurn()
    {
        // Simple AI: attack the player using Combatant.TakeDamage so blocking works
        Player player = GameManager.Instance.player;
        if (player != null)
        {
            player.TakeDamage(attackPower);
            Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");
        }
        
        

        GameManager.Instance.EndTurn();
    }

    public override void TakeDamage(int damage)
    {
        // Use the shared logic in Combatant (handles blocking, death)
        base.TakeDamage(damage);
        // Additional enemy-specific reactions can be added here
    }
}