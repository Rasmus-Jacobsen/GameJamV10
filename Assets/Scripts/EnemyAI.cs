using UnityEngine;

public class Enemy : Combatant
{
    // RASMUS

    public override void StartTurn()
    {
        base.StartTurn();
        
        Player player = FindAnyObjectByType<Player>(); // letar efter spelaren i scenen
        if (player != null && canAct) // om spelaren existerar och fienden kan agera
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
                else if (x > 55)
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

        }




    }


}