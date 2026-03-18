using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
//Liam
public class EnemyHoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] bool isPlayer;
    [SerializeField] bool isBoss;
    [SerializeField] private Player playerStats;
    [SerializeField] private Enemy enemyStats;
    [SerializeField] private Boss bossStats;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isPlayer && !isBoss)
        {
            if (enemyStats == null) return;

            TooltipController.Instance?.Show($"HP: {enemyStats.health} / {enemyStats.maxHp}");
        }
        else if (isPlayer)
        {
            if (playerStats == null) return;

            TooltipController.Instance?.Show($"HP {playerStats.health} / {playerStats.maxHp}");
        }
        else if (isBoss)
        {
            TooltipController.Instance?.Show($"HP {bossStats.health} / {bossStats.maxHp}");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipController.Instance?.Hide();
    }
}
