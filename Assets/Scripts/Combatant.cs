using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int health = 80;
    public int attackPower = 20;
    public bool blocking;
    public int energy;
    public virtual void StartTurn()
    {

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

    public virtual void Attack(Combatant target)
    {
        blocking = false;
        Debug.Log($"{gameObject.name} attacks {target.gameObject.name} for {attackPower} damage!");
        target.TakeDamage(attackPower);
        GameManager.Instance.EndTurn();
    }
    public virtual void Block()
    {
        blocking = true;
        Debug.Log($"{gameObject.name} is blocking this turn!");
        GameManager.Instance.EndTurn();
    }
   
    public void Death()
    {
        Debug.Log($"{gameObject.name} has been defeated!");

        Destroy(gameObject);
      
    }
   public void Rest()
    {
        blocking = false;
        energy++;
        Debug.Log($"{gameObject.name} rests and recovers energy. Current energy: {energy}");
        GameManager.Instance.EndTurn();
    }


    public virtual void skipturn()
    {
        blocking |= false;
        Debug.Log($"{gameObject.name} skipped their turn.");
        energy++;
        GameManager.Instance.EndTurn();
    }
    public virtual void SpecialAttack(int damage)
    {
        damage = 5;
        damage += attackPower;
        health -= damage;
        if (health <= 0) Death();
    }

}