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
        maxHealth = combatant.health;
    }

    // Update is called once per frame
    void Update()
    {
        displayimage.sprite = healthSprites[ Mathf.RoundToInt((combatant.health/maxHealth)*healthSprites.Length)];
        
    }
}
