using UnityEngine;

public class Boss : Enemy
{
    // Player attackTarget;
    // [SerializeField] GameObject targetArrow;

    private void Start()//-Liam
    {
        attackTarget = FindAnyObjectByType<Player>();
    }

    // RASMUS
    public override void StartTurn()
    {
        base.StartTurn();
        Player player = FindAnyObjectByType<Player>(); // letar efter spelaren i scenen

        if (player != null) // om spelaren inte är null.
        {
            
            
            int x = Random.Range(0, 100); // generar ett slumpmässigt tal mellan 0 och 100 för att bestämma bossens handling.

            if (health <= 121) // om bossens hälsa är mindre än eller lika med 121, utför en uppsättning handlingar baserat på det slumpmässiga talet.
            {
                if (x <= 50) // om det slumpmässiga talet är mindre än eller lika med 80, utför bossattack1.
                {
                    Bossattack1(player);
                    canAct = false;
                }
                else // om det slumpmässiga talet är större än 80
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 60) // om bossens hälsa är mindre än eller lika med 60, utför en annan uppsättning handlingar baserat på det slumpmässiga talet.
            {
                if (x <= 40) // om det slumpmässiga talet är mindre än eller lika med 40
                {
                    Bossattack1(player);
                    canAct = false;
                }
                else if (x <= 80) // om det slumpmässiga talet är mindre än eller lika med 80
                {
                    Bossattack2(player);
                    canAct = false;
                }
                else // om det slumpmässiga talet är större än 80
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 30) // om bossens hälsa är mindre än eller lika med 30, utför en tredje uppsättning handlingar baserat på det slumpmässiga talet.
            {
                if (x <= 20) // om det slumpmässiga talet är mindre än eller lika med 20
                {
                    Bossattack1(player);
                    canAct = false;
                }
                else if (x <= 60) // om det slumpmässiga talet är mindre än eller lika med 60
                {
                    Bossattack2(player);
                    canAct = false;
                }
                else if (x <= 80) // om det slumpmässiga talet är mindre än eller lika med 80
                {
                    Bossattack3(player);
                    canAct = false;
                }
                else // om det slumpmässiga talet är större än 80
                {
                    Block();
                    canAct = false;
                }
            }
        }
    }

    public void selectTarget()//Made the enemies buttons so that we can make everything in the Ui and scaleble with any screen-Liam
    {
        attackTarget.target = GetComponent<Boss>();

        print($"{attackTarget.target} is sellected");



    }
    public void Update()
    {
        if (attackTarget.target == GetComponent<Boss>())
        {
            targetArrow.SetActive(true);
        }
        else
        {
            targetArrow.SetActive(false);
        }


    }
}