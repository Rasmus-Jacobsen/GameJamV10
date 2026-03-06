using UnityEngine;
using UnityEngine.UI;

public class Player : Combatant
{
    
    public Button attackButton, blockButton, restButton, specialAttack;



    public LayerMask mask;
    Enemy target;

    public override void StartTurn()
    {
        base.StartTurn();
        Debug.Log("Choose your action!");

        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
        restButton.onClick.AddListener(OnRestButton);
        specialAttack.onClick.AddListener(OnSpecialAttackButton);

    }


    protected override void OnEndTurn()
    {
        // remove UI listeners to avoid duplicate invocations next turn
        attackButton.onClick.RemoveListener(OnAttackButton);
        blockButton.onClick.RemoveListener(OnBlockButton);
        restButton.onClick.RemoveListener(OnRestButton);
        specialAttack.onClick.RemoveListener(OnSpecialAttackButton);
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

        if (!canAct) return;

        if (energy < 1)
        {
            return;
        }

        else if (energy >= 1)
        {
            SpecialAttack(target);


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
        Block();
    }
   
    public void OnRestButton()
    {
        if (!canAct) return;
        Rest();
        
    }
  



}
