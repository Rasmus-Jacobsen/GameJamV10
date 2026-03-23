using UnityEngine;

public class Combatant : MonoBehaviour
{
    // RASMUS

    public int maxHp;
    public int health = 80;
    public int attackPower = 20;
    public bool blocking;
    public int energy;
    public bool cooldown;
    public float cooldownTime = 2f;
    public bool canAct = false;
    public int specialattackpower = 40;

    protected virtual void Awake()
    {
        if (CompareTag("Enemy"))
        {
            GameManager.Instance.combatants.Add(this);
        }
    }

    public virtual void StartTurn()
    {
        canAct = true;

    }
    public virtual void TakeDamage(int damage) // fucntion som utförs när man tar skada 
    {
        if (blocking) // om man blockar 
        {
            damage /= 2; // dela skada med 2
            Debug.Log($"{gameObject.name} is blocking! Damage reduced.");
        }

        GetComponent<HurtScript>().Hurt();

        health -= damage; 

        if (health <= 0) // om hälsan är mindre än eller lika med 0 så dör man
        {
            Death();
        }

    }

    
    protected virtual void OnEndTurn() { }

    public virtual void Attack(Combatant target) // fucntion för bas attack för både spelare och fiende
    {

        blocking = false; // block avstängd när man attackerar
        print($"{gameObject.name} attacks {target.gameObject.name} for {attackPower} damage!");
        energy++;
        target.TakeDamage(attackPower); // utför attacken på target
        canAct = false; // sätter så att man inte kan agera mer under samma tur
        OnEndTurn();
        GameManager.Instance.EndTurn(); // avslutar turen när functionen är genomförd

    }
    public virtual void Block() // funktuion för att blocka för både spelare och fiende
    {
        canAct = false;
        blocking = true; // sätter så block är sant 
        energy++;
        print($"{gameObject.name} is blocking and will take reduced damage until their next turn!");
        OnEndTurn();
        GameManager.Instance.EndTurn(); // avslutar turen när functionen är genomförd
    }

    public virtual void Death()
    {
        Debug.Log($"{gameObject.name} has been defeated!");

        print(gameObject.name);
        GameManager.Instance.EndSceneLoader(gameObject);

        Destroy(gameObject);
        OnEndTurn();
        GameManager.Instance.EndTurn(); // avslutar turen när functionen är genomförd

    }
    public void Rest() // function för att vila och ge spelaren energi
    {
        canAct = false;
        blocking = false;
        energy += 2; // ökar energin med 1 mer än vanligt
        Debug.Log($"{gameObject.name} rests and recovers energy. Current energy: {energy}");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }


    public virtual void Skipturn() // samma som rest men för fienden 
    {
        canAct = false;
        blocking = false;
        Debug.Log($"{gameObject.name} skipped their turn.");
        energy++;
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void SpecialAttack(Combatant target) // special attack functuon för både spelare och fiende.
    {
        target.TakeDamage(specialattackpower); // utför special attacken på target
        
        canAct = false;
        blocking = false;
        Debug.Log($"{gameObject.name} special attacks  {target.gameObject.name} for {specialattackpower} damage");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void Bossattack1(Combatant target) // boss attack numer 1, för bossen som gör mer skada än en vanlig attack
    {
        canAct = false;
        blocking = false;
        target.TakeDamage(specialattackpower + 10); // bestämmer att boss attacken gör 10 mer skada än en vanlig attack
        Debug.Log($"{gameObject.name} attacks {target.gameObject.name} for {attackPower + 10} damage!");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void Bossattack2(Combatant target)
    {
        canAct = false;
        blocking = false;
        target.TakeDamage(specialattackpower + 20); // bestämmer att boss attacken gör 20 mer skada än en vanlig attack
        Debug.Log($"{gameObject.name} performs a devastating strike on {target.gameObject.name} for {attackPower + 20} damage!");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void Bossattack3(Combatant target)
    {
        canAct = false;
        blocking = false;
        target.TakeDamage(specialattackpower); // bestämmer att boss attacken gör 30 mer skada än en vanlig attack
        Debug.Log($"{gameObject.name} performs an special attack on {target.gameObject.name} for {attackPower + 30} damage!");
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void miniBossattack(Combatant target) 
    {
        canAct = false;
        blocking = false;
        target.TakeDamage(attackPower + 5);
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void miniBossHeal()
    {
        canAct = false;
        blocking = false;
        health += 20; 
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }
    public virtual void miniBossattack2(Combatant target)
    {
        canAct = false;
        blocking = false;
        target.TakeDamage(specialattackpower + 10);
        OnEndTurn();
        GameManager.Instance.EndTurn();
    }

}