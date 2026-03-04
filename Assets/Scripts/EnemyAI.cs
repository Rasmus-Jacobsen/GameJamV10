using UnityEngine;

public class Enemy : Combatant
{
    public override void StartTurn()
    {
        
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            
            int x = Random.Range(0, 60);
            if (health <= 50)
            {
                if (x <= 5)
                {

                    Attack(player);
                    
                }
                else if (x <= 50)
                {
                    Block();

                    
                }
                else if (x <= 55)
                {
                    skipturn();
                    
                }
                else
                {
                    Attack(player);

                }

            }
            if (health > 50)
            {
                if (x < 5)
                {
                    
                    Attack(player);

                    
                }
                else if (x < 45)
                {
                    Block();

                }
                else
                {
                    Attack(player);
                }

                
            }
          
            Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");

            
        }
       



    }


}