using UnityEngine;

public class Enemy : Combatant
{
    public override void StartTurn()
    {
        
        Player player = GameManager.Instance.player;
        if (player != null)
        {
            
            int x = Random.Range(0, 60);
            if (health <= 50)
            {
                if (x < 5)
                {
                    blocking = false;
                    player.TakeDamage(attackPower);
                    Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");
                    
                }
                else if (x < 45 )
                {
                    blocking = true;
                    Debug.Log($"{gameObject.name} is blocking!");
                }
                else if (x < 55)
                {
                    blocking = false;
                    skipturn();
                    Debug.Log($"{gameObject.name} skipped the turn!");
                }
            }
            if (health > 50)
            {
                if (x < 5)
                {
                    blocking = false;
                    player.TakeDamage(attackPower);
                    Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");
                }
                else if (x < 45)
                {
                    blocking = true;
                    Debug.Log($"{gameObject.name} is blocking!");
                }
            }
          
            Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");
        }
        
        

        GameManager.Instance.EndTurn();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}