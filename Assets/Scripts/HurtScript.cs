using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// Liam
public class HurtScript : MonoBehaviour
{
    [Header("Shake")]
    public float shakeDuration = 0.15f;
    public float attackShakeDuration = 0.25f;
    public float attackShakeMagnitude = 10f;
    public float shakeMagnitude = 10f; // pixels

    [Header("Flash")]
    public Color hurtColor = Color.red;
    public Color defenceColor = Color.blue;
    public Color specialAttackColor = Color.yellow;

    private RectTransform rectTransform;
    private Image image;
    private Vector2 originalPosition;
    private Color originalColor;

    private bool isHurting;
    private bool isAttacking;
    private bool isSpecialAttacking;
    private bool isDefending;

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

    public void AttackAnim()
    {
        if (!isAttacking)
            StartCoroutine(AttackCoroutine());
    }
    public void DefendingAnim()
    {
        if (!isDefending)
            StartCoroutine(DefenceCoroutine());
    }
    public void SpecialAttackAnim()
    {
        if (!isSpecialAttacking)
            StartCoroutine(SpecialAttackCoroutine());

    }

    IEnumerator HurtCoroutine()
    {
        isHurting = true;

        image.color = hurtColor;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * attackShakeMagnitude;
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

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        float elapsed = 0f;

        while (elapsed < attackShakeDuration)
        {
            float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;
            new WaitForSeconds(0.1f);
            rectTransform.anchoredPosition = originalPosition + new Vector2(0f, offsetY);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset
        rectTransform.anchoredPosition = originalPosition;

        isAttacking = false;
    }

    IEnumerator DefenceCoroutine()
    {
        isDefending = true;

        image.color = defenceColor;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset
        image.color = originalColor;

        isDefending = false;
    }

    IEnumerator SpecialAttackCoroutine()
    {
        isSpecialAttacking = true;

        image.color = specialAttackColor;

        float elapsed = 0f;

        while (elapsed < attackShakeDuration)
        {
            float offsetY = Random.Range(-1f, 1f) * attackShakeMagnitude;
            new WaitForSeconds(0.1f);
            rectTransform.anchoredPosition = originalPosition + new Vector2(0f, offsetY);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset
        rectTransform.anchoredPosition = originalPosition;
        image.color = originalColor;

        isSpecialAttacking = false;
    }
}