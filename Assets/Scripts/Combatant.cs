using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int health = 80;
    public int attackPower = 20;
    public bool blocking;
    public int energy;
    public bool cooldown;
    public float cooldownTime = 2f;
    public bool canAct = false;
    public virtual void StartTurn()
    {
        canAct = true;

    }
    public virtual void TakeDamage(int damage)
    {
        if (blocking)
        {
            damage /= 2;
            Debug.Log($"{gameObject.name} is blocking! Damage reduced.");
        }
        health -= damage;

        if (health <= 0) Death();

    }

    
    protected virtual void OnEndTurn() { }

    public virtual void Attack(Combatant target)
    {

        blocking = false;
       print($"{gameObject.name} attacks {target.gameObject.name} for {attackPower} damage!");
        target.TakeDamage(attackPower);
        canAct = false;
        OnEndTurn();
        GameManager.Instance.EndTurn();

    }
    public virtual void Block()
    {
        canAct = false;
        blocking = true;
        print($"{gameObject.name} is blocking and will take reduced damage until their next turn!");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }

    public virtual void Death()
    {
        Debug.Log($"{gameObject.name} has been defeated!");

        Destroy(gameObject);

    }
    public void Rest()
    {
        canAct = false;
        blocking = false;
        energy++;
        Debug.Log($"{gameObject.name} rests and recovers energy. Current energy: {energy}");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }


    public virtual void skipturn()
    {
        canAct = false;
        blocking = false;
        Debug.Log($"{gameObject.name} skipped their turn.");
        energy++;
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void SpecialAttack(Combatant target)
    {
        canAct = false;
        blocking = false;
        Debug.Log($"{gameObject.name} performs a special attack!");
        target.TakeDamage(attackPower * 2);
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }

}