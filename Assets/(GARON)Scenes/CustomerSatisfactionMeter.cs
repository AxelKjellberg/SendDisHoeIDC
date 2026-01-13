using UnityEngine;
using UnityEngine.UI;

// Customer satisfaction meter for Unity UI
// - Assign a radial Image to `fillImage` (Image Type = Filled, Fill Method = Radial360)
// - Assign a Gradient to control color by value
// - Assign a Text to `percentageText` (or replace with TMP if desired)
// - Optionally assign star Images to `starImages` to show discrete stars

public class CustomerSatisfactionMeter : MonoBehaviour
{
    [Range(0, 100)]
    public int value = 75;

    [Header("UI Bindings")]
    public Image fillImage;
    public Text percentageText;
    public Image[] starImages;

    [Header("Appearance")]
    public Gradient colorGradient;

    void Start()
    {
        UpdateVisuals();
    }

    // Set the meter to a specific value (0-100)
    public void SetValue(int newValue)
    {
        value = Mathf.Clamp(newValue, 0, 100);
        UpdateVisuals();
    }

    // Add (or subtract) a delta to the current value
    public void AddValue(int delta)
    {
        SetValue(value + delta);
    }

    // Update UI elements to reflect `value`
    public void UpdateVisuals()
    {
        float t = value / 100f;

        if (fillImage != null)
        {
            fillImage.fillAmount = t;
            if (colorGradient != null)
                fillImage.color = colorGradient.Evaluate(t);
        }

        if (percentageText != null)
            percentageText.text = value + "%";

        if (starImages != null && starImages.Length > 0)
        {
            int starsOn = Mathf.RoundToInt(t * starImages.Length);
            for (int i = 0; i < starImages.Length; i++)
            {
                if (starImages[i] != null)
                    starImages[i].enabled = (i < starsOn);
            }
        }
    }
}
