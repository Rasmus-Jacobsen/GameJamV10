using UnityEngine;

public class Enemy : Combatant
{
    public override void StartTurn()
    {
        base.StartTurn();
        
        Player player = FindAnyObjectByType<Player>();
        if (player != null && canAct)
        {

            int x = Random.Range(0, 60);
            if (health <= 50)
            {
                if (x <= 5)
                {

                    Attack(player);
                    canAct = false;
                }
                else if (x <= 50)
                {
                    Block();
                    canAct = false;

                }
                else if (x <= 55)
                {
                    skipturn();
                    canAct = false;
                }
                else
                {
                    Attack(player);
                    canAct = false;
                }

            }
            if (health > 50)
            {
                if (x < 5)
                {

                    Attack(player);
                    canAct = false;

                }
                else if (x < 45)
                {
                    Block();
                    canAct = false;
                }
                else
                {
                    Attack(player);
                    canAct = false;
                }


            }

            Debug.Log($"{gameObject.name} attacked! Player health: {player.health}");


        }




    }


}