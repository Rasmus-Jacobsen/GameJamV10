using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int attackPower = 20;
    private bool canAct = false;
    public Button attackButton, blockButton, restButton;

    public void StartTurn()
    {
        canAct = true;
        Debug.Log("Choose your action!");
        // Enable buttons here if using Unity UI
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
    }

    private void OnAttackButton()
    {
        // Use the enemy reference from the GameManager
        Attack(GameManager.Instance.enemy);
    }

    private void OnBlockButton()
    {
        BlockAction();
    }

    public void Attack(Enemy target)
    {
        if (!canAct) return;

        if (target == null) return;

        target.TakeDamage(attackPower);
        EndTurn();
    }

    public void BlockAction()
    {
        if (!canAct) return;

        // Implement blocking behavior here
        Debug.Log("Player blocks this turn.");
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
}