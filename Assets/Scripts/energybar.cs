using UnityEngine;
using UnityEngine.UI;

// Sprite-based energy bar (Option A)
public class energybar : MonoBehaviour
{
    public Combatant combatant;
    public int maxEnergy = 4;
    public Sprite[] energySprites;
    public Image displayImage;

    void Start()
    {
        if (combatant != null && maxEnergy <= 0)
            maxEnergy = Mathf.Max(1, combatant.energy);

        Refresh();
    }   

    void Update()
    {
        
        Refresh();
    }

    
    public void Refresh()
    {
        if (combatant == null || displayImage == null || energySprites == null || energySprites.Length == 0)
            return;

        float ratio = Mathf.Clamp01((float)combatant.energy / Mathf.Max(1, maxEnergy));
        int index = Mathf.RoundToInt(ratio * (energySprites.Length - 1));
        index = Mathf.Clamp(index, 0, energySprites.Length - 1);
        displayImage.sprite = energySprites[index];
    }
}
