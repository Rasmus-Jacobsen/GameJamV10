using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
//Liam
public class EnemyHoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] bool isPlayer;
    [SerializeField] private Player playerStats;
    [SerializeField] private Enemy enemyStats;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isPlayer)
        {
            if (enemyStats == null) return;

            TooltipController.Instance?.Show($"HP: {enemyStats.health} / {enemyStats.maxHp}");
        }
        else if (isPlayer)
        {
            if (playerStats == null) return;

            TooltipController.Instance?.Show($"HP {playerStats.health} / {playerStats.maxHp}");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipController.Instance?.Hide();
    }
}
