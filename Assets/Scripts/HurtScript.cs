using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// Liam
public class HurtScript : MonoBehaviour
{
    [Header("Shake")]
    public float shakeDuration = 0.15f;
    public float shakeMagnitude = 10f; // pixels

    [Header("Flash")]
    public Color hurtColor = Color.red;

    private RectTransform rectTransform;
    private Image image;
    private Vector2 originalPosition;
    private Color originalColor;
    private bool isHurting;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        originalPosition = rectTransform.anchoredPosition;
        originalColor = image.color;
    }

    public void Hurt()
    {
        if (!isHurting)
            StartCoroutine(HurtCoroutine());
    }

    IEnumerator HurtCoroutine()
    {
        isHurting = true;

        image.color = hurtColor;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
            new WaitForSeconds(0.01f);
            rectTransform.anchoredPosition = originalPosition + new Vector2(offsetX, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset
        rectTransform.anchoredPosition = originalPosition;
        image.color = originalColor;

        isHurting = false;
    }
}