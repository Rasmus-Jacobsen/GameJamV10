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
            
        maxHealth = combatant.health;// sätt maxHealth till combatantens hälsa när spelet startar.
    }

    // Update is called once per frame
    void Update()
    {
        if (combatant == null || displayimage == null || healthSprites == null || healthSprites.Length == 0) return; // om combatant, displayimage eller healthSprites inte är korrekt inställda, returnera och gör inget.


        float ratio = Mathf.Clamp01((float)combatant.health / Mathf.Max(1f, maxHealth)); // beräkna hälsan som en ratio mellan 0 och 1, där maxHealth inte kan vara mindre än 1.


        int index = Mathf.RoundToInt(ratio * (healthSprites.Length - 1)); // beräkna indexet för healthSprites baserat på hälsan, där 0 är full hälsa och healthSprites.Length - 1 är ingen hälsa.
        index = Mathf.Clamp(index, 0, healthSprites.Length - 1); // säkerställ att indexet är inom giltiga gränser för healthSprites arrayen.

        displayimage.sprite = healthSprites[index]; // uppdatera displayimage med den korrekta sprite baserat på combatantens hälsa.
    }
}
