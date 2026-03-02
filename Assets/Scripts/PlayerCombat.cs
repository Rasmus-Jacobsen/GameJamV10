using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public int playerHp = 50;
    public int Attack1 = 10;
    public Button attack1;
    private EnemyCombat selectedEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack1.onClick.AddListener(PlayerAttack);
        attack1.interactable = false;
    }
    public void PlayerAttack()
    {

    }
   public void SelectEnemy()
    {
        
    }
}
