using UnityEngine;
using UnityEngine.UI;
using YG;

public class InstertitialAdd : MonoBehaviour
{
    [SerializeField] private GameObject PanelAdd;
    [SerializeField] private Text textOnPanel;
    [SerializeField] private FullscreenAd fullscreenAd;
    [SerializeField] private LocalisationVariables localisationVariables;
    
    [SerializeField] private float cooldownAdd;
    private float smallTimer;

    private void Start()
    {
        Invoke("OpenPanel", cooldownAdd);
    }

    private void OpenPanel()
    {
        PanelAdd.SetActive(true);
    }

    private void ShowAdd()
    {
        fullscreenAd.ShowFullscreen();
        Invoke("OpenPanel", cooldownAdd);
    }

    private void FixedUpdate()
    {
        if (PanelAdd.activeSelf) { smallTimer += Time.deltaTime; }
    }

    private void Update()
    {
        if (YandexGame.lang != "tr") { textOnPanel.text = localisationVariables.AdvertisingIn(YandexGame.lang); }
        else { textOnPanel.text = ""; }

        switch (smallTimer)
        {
            case < 0.33f:
                textOnPanel.text += "3.";
                break;
            case < 0.66f:
                textOnPanel.text += "3..";
                break;
            case < 1f:
                textOnPanel.text += "3...";
                break;
            case < 1.33f:
                textOnPanel.text += "2.";
                break;
            case < 1.66f:
                textOnPanel.text += "2..";
                break;
            case < 2f:
                textOnPanel.text += "2...";
                break;
            case < 2.33f:
                textOnPanel.text += "1.";
                break;
            case < 2.66f:
                textOnPanel.text += "1..";
                break;
            case < 3f:
                textOnPanel.text += "1...";
                break;
            case >= 3:
                ShowAdd();
                smallTimer = 0;
                PanelAdd.SetActive(false);
                break;
        }

        if (YandexGame.lang == "tr") { textOnPanel.text += localisationVariables.AdvertisingIn("tr"); }
    }
}
