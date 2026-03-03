using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int health = 80;
    public int attackPower = 2;
    public bool blocking;
    
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
    public void Death()
    {
        Debug.Log($"{gameObject.name} has been defeated!");

        Destroy(gameObject);
    }
   
}
