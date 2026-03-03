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
        // Enable buttons here if using Unity UI
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, mask);
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            target = hit.collider.GetComponent<Enemy>();
        }
    }

    private void OnAttackButton()
    {
        // Use the enemy reference from the GameManager
        Attack(target);
    }

    private void OnBlockButton()
    {
        BlockAction();
    }
    public void BlockAction()
    {
        if (!canAct) return;
        if (target == null) return;
        blocking = true;
        EndTurn();

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
        // Remove listeners to avoid duplicate subscriptions next turn
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