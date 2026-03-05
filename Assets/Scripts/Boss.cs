using UnityEngine;

public class Boss : Combatant
{


    public override void StartTurn()
    {
        base.StartTurn();
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            Bossstats();
            
            int x = Random.Range(0, 100);
            if (health <= 121)
            {
                if (x <= 80)
                {
                    bossattack1(player);
                    canAct = false;
                }
                else
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 60 )
            {
                if (x <= 40)
                {
                    bossattack1(player);
                    canAct = false;
                }
                else if (x <= 80)
                {
                    bossattack2(player);
                    canAct = false;
                }
                else
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 30 )
            {
                if (x <= 20)
                {
                    bossattack1(player);
                    canAct = false;
                }
                else if (x <= 60)
                {
                    bossattack2(player);
                    canAct = false;
                }
                else if (x <= 80)
                {
                    bossattack3(player);
                    canAct = false;
                }
                else
                {
                    Block();
                    canAct = false;
                }
            }
        }
    }
}