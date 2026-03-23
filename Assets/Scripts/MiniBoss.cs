using UnityEngine;

public class MiniBoss : Enemy
{
    private void Start()
    {
        attackTarget = FindAnyObjectByType<Player>();
    }

   
    public override void StartTurn()
    {
        base.StartTurn();
        Player player = FindAnyObjectByType<Player>(); 

        if (player != null) 
        {


            int x = Random.Range(0, 100); 

            if (health <= 119) 
            {
                if (x <= 63) 
                {
                    miniBossattack(player);
                    canAct = false;
                }
                else 
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 80) 
            {
                if (x <= 40)
                {
                    miniBossattack(player);
                    canAct = false;
                }
                else if (x <= 80)
                {
                    miniBossHeal();
                    canAct = false;
                }
                else if (x <= 0)
                {
                    miniBossattack2(player);
                }
                else
                {
                    Block();
                    canAct = false;
                }
            }
            if (health <= 50) 
            {
                if (x <= 20) 
                {
                    miniBossattack(player);
                    canAct = false;
                }
                else if (x <= 90) 
                {
                    miniBossattack2(player);
                }
                else 
                {
                    miniBossHeal();
                    canAct = false;
                }
            }
        }
    }

    public void selectTargetMiniboss()
    {
        attackTarget.target = GetComponent<MiniBoss>();

        print($"{attackTarget.target} is sellected");



    }
    public void Update()
    {
        if (attackTarget.target == GetComponent<MiniBoss>())
        {
            targetArrow.SetActive(true);
        }
        else
        {
            targetArrow.SetActive(false);
        }


    }
}

