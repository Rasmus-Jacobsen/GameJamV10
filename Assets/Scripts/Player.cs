using UnityEngine;
using UnityEngine.UI;

public class Player : Combatant
{
    private bool canAct = false;
    public Button attackButton, blockButton, restButton, specialAttack;
   


    public LayerMask mask;
    Enemy target;
    
    public override void StartTurn()
    {
        canAct = true;
        Debug.Log("Choose your action!");
        
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
        restButton.onClick.AddListener(OnRestButton);
        specialAttack.onClick.AddListener(OnSpecialAttackButton);

    }

    private void Update()
    {
        //slecting target with mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapPoint(worldPoint, mask);
            if (col != null)
            {
                target = col.GetComponent<Enemy>();
            }
        }
    }
    public void OnSpecialAttackButton()
    {
        cooldown = true;

       
        if (!canAct) return;

        if (energy < 1)
        {
            
        }
        
        else if (energy > 1) 
        {
            energy--;
           

        }
    }

    public void OnAttackButton()
    {
        // Use the selected target
        Attack(target);
    }

    public void OnBlockButton()
    {
        if (!canAct) return;
        BlockAction();
    }
    public void BlockAction()
    {
        if (!canAct) return;
        blocking = true;
        EndTurn();

    }
    public void OnRestButton()
    {
        if (!canAct) return;
        Rest();
    }
    public void Attack(Enemy target)
    {
        if (!canAct) return;

        if (target == null) return;

        target.TakeDamage(attackPower);

        EndTurn();
    }

   

    private void EndTurn()
    {
        canAct = false;
        
        attackButton.onClick.RemoveListener(OnAttackButton);
        blockButton.onClick.RemoveListener(OnBlockButton);
        restButton.onClick.RemoveListener(OnRestButton);
        specialAttack.onClick.RemoveListener(OnSpecialAttackButton);
        GameManager.Instance.EndTurn();
    }
   
}
