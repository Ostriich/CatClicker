using UnityEngine;
using UnityEngine.UI;

public class CategoriesButtons : MonoBehaviour
{
    [SerializeField] private GameObject panelUpgradeCats;
    [SerializeField] private GameObject buttonCats, buttonClicks;

    private void Update()
    {
        if (panelUpgradeCats.activeSelf)
        {
            buttonCats.GetComponent<Button>().enabled = false;
            buttonCats.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            buttonClicks.GetComponent<Button>().enabled = true;
            buttonClicks.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            buttonClicks.GetComponent<Button>().enabled = false;
            buttonClicks.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            buttonCats.GetComponent<Button>().enabled = true;
            buttonCats.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
