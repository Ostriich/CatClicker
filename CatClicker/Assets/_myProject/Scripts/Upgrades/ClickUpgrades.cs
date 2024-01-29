using UnityEngine;
using UnityEngine.UI;
using YG;

public class ClickUpgrades : MonoBehaviour
{
    // Economical static data
    private long[] costUpgrades = new long[12] { 20, 100, 1500, 10000, 100000, 1000000, 15000000, 150000000, 10000000000, 100000000000, 1000000000000, 10000000000000};
    private long[] growthStrength = new long[12] { 1, 1, 25, 50, 2000, 5000, 300000, 600000, 200000000, 400000000, 20000000000, 40000000000 };
    private string[] shortGrowth = new string[12] { "1", "1", "25", "50", "2K", "5K", "300K", "600K", "200M", "400M", "20B", "40B" };

    // Changable data
    public int[] countBoughtUpgrades = new int[12];

    // Game Objects
    [SerializeField] private GameObject[] buyButtons = new GameObject[12];
    [SerializeField] private Text[] growthText = new Text[12];
    [SerializeField] private Text[] costUpgradeText = new Text[12];
    [SerializeField] private Text[] countUpgradesText = new Text[12];

    [SerializeField] private Image[] upgradeImages = new Image[12];
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private ClicksPanelInfo clicksPanelInfo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private LocalisationVariables localisationVariables;

    private void Start()
    {
        UpdateAll();
    }

    private void Update()
    {
        // Update enable and view of buy buttons
        for (int k = 0; k < buyButtons.Length; k++)
        {
            if (coinsCounter.CoinsValue < costUpgrades[k])
            {
                buyButtons[k].GetComponent<Button>().enabled = false;
                buyButtons[k].GetComponent<Image>().color = new Color32(150, 150, 150, 255);
                costUpgradeText[k].color = new Color32(150, 150, 150, 255);
            }
            else
            {
                buyButtons[k].GetComponent<Button>().enabled = true;
                buyButtons[k].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                costUpgradeText[k].color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void UpdateAll()
    {
        for (int i = 0; i < buyButtons.Length; i++)
        {
            // Set count of bought upgrades
            countUpgradesText[i].text = "x" + countBoughtUpgrades[i].ToString();
            if (countBoughtUpgrades[i] > 0) { upgradeImages[i].color = new Color32(255, 255, 255, 255); }
            else { upgradeImages[i].color = new Color32(0, 0, 0, 255); }

            // Set limit for buy upgrades in 100 times
            if (countBoughtUpgrades[i] == 100) { buyButtons[i].SetActive(false); }

            // Set info growth
            if (countBoughtUpgrades[i] == 0) 
            {
                if (YandexGame.lang == "tr")
                {
                    if (i % 2 == 0) { growthText[i].text = localisationVariables.PerSec("tr") + "+ ???"; }
                    if (i % 2 == 1) { growthText[i].text = localisationVariables.PerClick("tr") + "+ ???"; }
                }
                else
                {
                    if (i % 2 == 0) { growthText[i].text = "+ ???" + localisationVariables.PerSec(YandexGame.lang); }
                    if (i % 2 == 1) { growthText[i].text = "+ ???" + localisationVariables.PerClick(YandexGame.lang); }
                }
            }
            else
            {
                if (YandexGame.lang == "tr")
                {
                    if (i % 2 == 0) { growthText[i].text = localisationVariables.PerSec("tr") + "+ " + shortGrowth[i]; }
                    if (i % 2 == 1) { growthText[i].text = localisationVariables.PerClick("tr") + "+ " + shortGrowth[i]; }
                }
                else
                {
                    if (i % 2 == 0) { growthText[i].text = "+ " + shortGrowth[i] + localisationVariables.PerSec(YandexGame.lang); }
                    if (i % 2 == 1) { growthText[i].text = "+ " + shortGrowth[i] + localisationVariables.PerClick(YandexGame.lang); }
                }
            }
        }
    }

    public void BuyCat(int index)
    {
        audioSource.PlayOneShot(audioSource.clip);
        coinsCounter.CoinsValue -= costUpgrades[index];
        if (index % 2 == 0) { clicksPanelInfo.startStrengthPerSecond += growthStrength[index]; }
        if (index % 2 == 1) { clicksPanelInfo.startStrengthPerClick += growthStrength[index]; }
        countBoughtUpgrades[index]++;
        UpdateAll();
    }
}
