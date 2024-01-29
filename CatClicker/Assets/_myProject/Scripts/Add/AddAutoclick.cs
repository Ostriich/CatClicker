using UnityEngine;
using UnityEngine.UI;
using YG;

public class AddAutoclick : MonoBehaviour
{
    [SerializeField] private Image imageButton;
    [SerializeField] private Button button;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject colorEffect;
    [SerializeField] private LocalisationVariables localisationVariables;

    [SerializeField] private float timeReload;

    public bool addWorking = false;

    private float timer;
    private bool addIsReady = true, addReloading = false;

    // Count time
    private void FixedUpdate()
    {
        if (addReloading) { timer += Time.deltaTime; }
        if (addWorking) { timer -= Time.deltaTime; }
    }

    private void Update()
    {
        // State button of ready to boost
        if (addIsReady)
        {
            imageButton.color = new Color32(255, 255, 255, 255);
            imageButton.fillAmount = 1;
            button.enabled = true;
            animator.enabled = true;
        }

        // State button in boost
        if (addWorking)
        {
            imageButton.fillAmount = timer / timeReload;
            colorEffect.SetActive(true);
            if (timer <= 0)
            {
                timer = 0;
                addWorking = false;
                addReloading = true;
            }
        }

        // State button on reloading boost
        if (addReloading)
        {
            imageButton.color = new Color32(255, 255, 255, 50);
            imageButton.fillAmount = timer / timeReload;
            colorEffect.SetActive(false);
            if (timer >= timeReload)
            {
                timer = timeReload;
                addReloading = false;
                addIsReady = true;
            }
        }
    }

    public void StartBoost()
    {
        transform.localScale = new Vector3(1, 1, 1);
        addIsReady = false;
        addWorking = true;
        button.enabled = false;
        animator.enabled = false;
        timer = timeReload;
    }

    public void SendTypeToPanel(AddSurePanel addSurePanel)
    {
        addSurePanel.addType = "Autolick";
        addSurePanel.descriptionString = localisationVariables.DescriptionAutoclickAd(YandexGame.lang);
    }
}
