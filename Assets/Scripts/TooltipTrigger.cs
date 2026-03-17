using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


// Liam
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    [SerializeField] private string tooltipText;

    public void OnPointerEnter(PointerEventData eventData)
        => TooltipController.Instance?.Show(tooltipText);
    

    public void OnPointerExit(PointerEventData eventData)
        => TooltipController.Instance?.Hide();
    
}