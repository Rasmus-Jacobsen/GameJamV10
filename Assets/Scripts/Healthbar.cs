using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Combatant combatant;
    public float maxHealth;
    public Sprite[] healthSprites;
    public Image displayimage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (combatant != null)
            maxHealth = combatant.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (combatant == null || displayimage == null || healthSprites == null || healthSprites.Length == 0) return;

        // safe normalized health between0 and1
        float ratio = Mathf.Clamp01((float)combatant.health / Mathf.Max(1f, maxHealth));

        // compute index in range [0, healthSprites.Length-1]
        int index = Mathf.RoundToInt(ratio * (healthSprites.Length - 1));
        index = Mathf.Clamp(index, 0, healthSprites.Length - 1);

        displayimage.sprite = healthSprites[index];
    }
}
