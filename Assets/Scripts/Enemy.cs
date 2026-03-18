using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Combatant
{
    // RASMUS
    public GameObject targetArrow;
    public Player attackTarget;
    bool istarget;

    private void Start()//-Liam
    {
        attackTarget = FindAnyObjectByType<Player>();
    }

    public override void StartTurn()
    {
        base.StartTurn();

        Player player = FindAnyObjectByType<Player>(); // letar efter spelaren i scenen
        print(player);
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

    public void SelectTarget()//Made the enemy's buttons so that we can make everything in the Ui and scaleble with any screen-Liam
    {
        attackTarget.target = GetComponent<Enemy>();

        print($"{attackTarget.target} is sellected");
        


    }
    public void Update()
    {
       if (attackTarget.target == GetComponent<Enemy>())
        {
            targetArrow.SetActive(true);
        }
        else
        {
            targetArrow.SetActive(false);
        }


    }
}

