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
        //Läger till ui listeners för knapparna när spelarens tur börjar
        attackButton.onClick.AddListener(OnAttackButton);
        blockButton.onClick.AddListener(OnBlockButton);
        restButton.onClick.AddListener(OnRestButton);
        specialAttack.onClick.AddListener(OnSpecialAttackButton);

    }


    protected override void OnEndTurn()
    {
        // tar bort listners när turen r slut för att stoppa duplicering 
        attackButton.onClick.RemoveListener(OnAttackButton);
        blockButton.onClick.RemoveListener(OnBlockButton);
        restButton.onClick.RemoveListener(OnRestButton);
        specialAttack.onClick.RemoveListener(OnSpecialAttackButton);
    }

    private void Update()
    {
        //genom att skicka ut en raycast när man trycker på mus knappen så definerar man en target för när man ska attackera
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
