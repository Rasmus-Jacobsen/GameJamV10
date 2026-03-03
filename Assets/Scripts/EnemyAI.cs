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
                    player.TakeDamage(attackPower);
                }
                else if (x < 45 )
                {
                    blocking = true;
                }
                else if (x < 55)
                {
                    skipturn();
                }
            }
            if (health > 50)
            {
                if (x < 5)
                {
                    player.TakeDamage(attackPower);
                }
                else if (x < 45)
                {
                    //block
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