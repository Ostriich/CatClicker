using UnityEngine;
using UnityEngine.UI;

public class CatUpgrades : MonoBehaviour
{
    // Economical static data
    private long[] costUpgrades = new long[15] { 0, 100, 1000, 8000, 75000, 500000, 3000000, 25000000, 200000000, 1500000000, 10000000000, 60000000000, 400000000000, 2500000000000, 30000000000000 };
    private long[] limits = new long[15] {100, 1000, 8000, 75000, 500000, 3000000, 25000000, 200000000, 1500000000, 10000000000, 60000000000, 400000000000, 2500000000000, 30000000000000, 1000000000000000000 };
    private string[] shortCost = new string[15] { "0", "100", "1K", "8K", "75K", "500K", "3M", "25M", "200M", "1,5B", "10B", "60B", "400B", "2,5T", "30T" };

    // Changable data
    public bool[] catIsBought = new bool[15] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    public int selectedCatImage = 0;

    // Game Objects
    [SerializeField] private GameObject[] buyButtons = new GameObject[15];
    [SerializeField] private Text[] costCatText = new Text[15];
    [SerializeField] private GameObject[] selectCatButton = new GameObject[15];

    [SerializeField] private Image[] catImages = new Image[15];
    [SerializeField] private GameObject[] catOnGlade = new GameObject[15];
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject restartButton;

    private void Start()
    {
        SetCosts();
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
                costCatText[k].color = new Color32(150, 150, 150, 255);
            }
            else
            {
                buyButtons[k].GetComponent<Button>().enabled = true;
                buyButtons[k].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                costCatText[k].color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void UpdateAll()
    {
        int maxBoughtCat = 0;

        for (int i = 0; i < buyButtons.Length; i++)
        {
            // Control activeself of buy buttons and select buttons
            buyButtons[i].SetActive(!catIsBought[i]);
            selectCatButton[i].SetActive(!(selectedCatImage == i) && catIsBought[i]);

            // Determine level of bankSize
            if (catIsBought[i]) { maxBoughtCat = i; }

            // Set active selected image of cat
            catOnGlade[i].SetActive(selectedCatImage == i);

            // Show or hide visual of CatImages
            if (catIsBought[i]) { catImages[i].color = new Color32(255, 255, 255, 255); }
            else { catImages[i].color = new Color32(0, 0, 0, 255); }
        }

        coinsCounter.BankSize = limits[maxBoughtCat];

        restartButton.SetActive(catIsBought[catIsBought.Length-1]);
    }

    public void BuyCat(int index)
    {
        audioSource.PlayOneShot(audioSource.clip);
        coinsCounter.CoinsValue -= costUpgrades[index];
        catIsBought[index] = true;
        selectedCatImage = index;
        UpdateAll();
    }

    public void SelectCatImage(int index)
    {
        selectedCatImage = index;
        UpdateAll();
    }

    private void SetCosts()
    {
        // Write short costs in buttons
        for (int j = 0; j < costCatText.Length; j++)
        {
            costCatText[j].text = shortCost[j];
        }
    }
}
