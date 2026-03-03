using UnityEngine;
using UnityEngine.UI;

public class Player : Combatant
{
    private bool canAct = false;
    public Button attackButton, blockButton, restButton;


    public LayerMask mask;
    Enemy target;

    public override void StartTurn()
    {
        canAct = true;
        Debug.Log("Choose your action!");
        
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
        restButton.onClick.AddListener(OnRestButton);
    }

    private void Update()
    {
        // Correct hit detection: use OverlapPoint to pick objects under the mouse
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

    private void OnAttackButton()
    {
        // Use the selected target
        Attack(target);
    }

    private void OnBlockButton()
    {
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
        GameManager.Instance.EndTurn();
    }
    public void Death()
    {
        Debug.Log("Enemy has been defeated!");

        Destroy(gameObject);
    }
}