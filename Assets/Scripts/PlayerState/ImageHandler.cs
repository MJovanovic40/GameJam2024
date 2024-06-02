using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{

    [SerializeField] private Image[] healthImages;
    [SerializeField] private Image[] staminaImages;
    [SerializeField] private Image[] focusImages;
    
    public void UpdateHealthBar(int value)
    {
        float segmentSize = 100f/healthImages.Length;
        int index = Mathf.RoundToInt(value/segmentSize);
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = false;
            staminaImages[i].enabled = false;
        }
        healthImages[healthImages.Length - index].enabled = true;
        staminaImages[staminaImages.Length - index].enabled = true;

    }

    public void UpdateFocusBar(int value)
    {
        float segmentSize = 100f / focusImages.Length;
        int index = Mathf.RoundToInt(value / segmentSize);
        for (int i = 0; i < focusImages.Length; i++)
        {
            focusImages[i].enabled = false;
        }
        focusImages[focusImages.Length - index].enabled = true;
    }
}
