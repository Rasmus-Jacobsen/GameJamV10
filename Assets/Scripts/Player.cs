using UnityEngine;
using UnityEngine.UI;

public class Player : Combatant
{
    // RASMUS

    public Button attackButton, blockButton, restButton, specialAttack;

    public LayerMask mask;
    public Enemy target;
    

    public override void StartTurn()
    {
        base.StartTurn();
        Debug.Log("Choose your action!");
        //Läger till ui listeners för knapparna när spelarens tur börjar
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
        restButton.onClick.AddListener(OnRestButton);
        specialAttack.onClick.AddListener(OnSpecialAttackButton);

    }


    protected override void OnEndTurn()
    {
        // tar bort listners när turen tar slut för att stoppa duplicering 
        attackButton.onClick.RemoveListener(OnAttackButton);
        blockButton.onClick.RemoveListener(OnBlockButton);
        restButton.onClick.RemoveListener(OnRestButton);
        specialAttack.onClick.RemoveListener(OnSpecialAttackButton);
    }

    public void OnSpecialAttackButton()
    {

        if (!canAct) return;

        if (energy < 3)
        {
            return;
        }

        else if (energy >= 3)
        {
            SpecialAttack(target);

            energy -= 3;
        }
    }

    public void OnAttackButton() // attackera target när man trycker på attack knappen.
    {
       
        Attack(target);
    }

    public void OnBlockButton() // blockera
    {
        if (!canAct) return; // stoppar spelaren från att agera om det inte är hans tur
        Block();
    }
   
    public void OnRestButton() // vila
    {
        if (!canAct) return; 
        Rest();
        
    }
  



}
