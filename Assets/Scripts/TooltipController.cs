using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

// Liam
public class TooltipController : MonoBehaviour
{
    public static TooltipController Instance { get; private set; }

    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text tooltipsText;

    [SerializeField] private Vector2 offset = new Vector2(0, 24f);
    [SerializeField] private Vector2 padding = new Vector2(8f, 8f);

    private RectTransform tooltipRect;
    private RectTransform canvasRect;
    private bool isVisible;

    private void Awake()
    {
        Instance = this;
        tooltipRect = tooltipsText.rectTransform;
        canvasRect = canvas.transform as RectTransform;
        Hide();
    }
    private void Update()
    {
        if (isVisible)
            FollowMouseClamped();
    }

    public void Show(string text)
    {
        tooltipsText.text = text;

        tooltipsText.ForceMeshUpdate();

        tooltipsText.gameObject.SetActive(true);
        isVisible = true;

        FollowMouseClamped();
    }

    public void Hide()
    {
        tooltipsText.gameObject.SetActive(false);
        isVisible=false;
    }

    private void FollowMouseClamped()
    {
        Camera cam = canvas.renderMode == RenderMode.ScreenSpaceOverlay?null : canvas.worldCamera;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out Vector2 localPoint);

        //wanted position over the mouse cursor
        Vector2 pos = localPoint + offset;

        // clamp so that the tooltip stays fully visible inside canvas rect
        Vector2 size = tooltipRect.rect.size;
        Vector2 pivot = tooltipRect.pivot; 

        // Calculate how far the tooltip extends from its pivot
        float left = size.x * pivot.x;
        float right = size.x * (1f -pivot.x);
        float botton = size.y * pivot.y;
        float top = size.y * (1f -pivot.y);

        Rect cr = canvasRect.rect;

        pos.x = Mathf.Clamp(pos.x, cr.xMin + left + padding.x, cr.xMax -right - padding.x);
        pos.y = Mathf.Clamp(pos.y, cr.yMin + botton + padding.y, cr.yMax -top - padding.y);

        tooltipRect.localPosition = pos;


    }

}
