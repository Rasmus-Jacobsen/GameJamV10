using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public class Entity
    {
        public int PlayerHP = 20;
       
        public Button attack;
        public bool playerTurn;
        public void Start()
        {
            if (attack != null)
            {
                attack.onClick.AddListener(PlayerAttack);
            }
        }

        
    }
}
