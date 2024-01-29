using UnityEngine;
using UnityEngine.UI;

public class TapTapPanelBehaviour : MonoBehaviour
{
    [SerializeField] private Image slider;
    [SerializeField] private GameObject fireEffect;

    public bool BoostIsActive = false;

    private bool fixedState = false;
    private float timer = 0;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    private void Update()
    {
        // Decrease slider value without fixed state of slider
        if (!fixedState && slider.fillAmount > 0 && timer < 2) { slider.fillAmount -= 0.0002f; }
        if (!fixedState && slider.fillAmount > 0 && timer >= 2) { slider.fillAmount -= 0.001f; }

        // Fixes the scale for a time when the maximum value is reached
        if (slider.fillAmount > 0.99)
        {
            slider.fillAmount = 1;
            fixedState = true;
        }

        // Resets the fixed state of slider after 1 seconds of inactivation of the player
        if (timer >= 1 && fixedState) 
        { 
            slider.fillAmount = 0.99f;
            fixedState = false;
        }

        // Enabling boost mode
        BoostIsActive = slider.fillAmount >= 0.75;

        // Change components that depend on boost mode
        if (BoostIsActive)
        {
            slider.color = new Color32(255, 50, 50, 255); // Light red
            fireEffect.SetActive(true);
        }
        else
        {
            slider.color = new Color32(50, 255, 255, 255); // Light blue
            fireEffect.SetActive(false);
        }
    }

    // Called when processing a touch from a "ClickOnScreen".
    public void GetClick()
    {
        timer = 0;
        slider.fillAmount += 0.015f;
    }
}
