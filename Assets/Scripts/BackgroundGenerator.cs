using UnityEngine;
using UnityEngine.UI;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundImages;
    [SerializeField] private Image backgroundTarget;

    void Start()
    {
        if (backgroundImages.Length == 0 || backgroundTarget == null)
        {
            Debug.LogWarning("RandomBackground: Missing images or target.");
            return;
        }

        int index = Random.Range(0, backgroundImages.Length);
        backgroundTarget.sprite = backgroundImages[index];
    }

}
