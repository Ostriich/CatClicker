using TMPro;
using UnityEngine;

public class ClicksProcessing : MonoBehaviour
{
    [SerializeField] private CoinsCounter coinsCounter;

    [SerializeField] private GameObject clickSpirit;
    [SerializeField] private GameObject centerImage;

    public long StrengthClick, StrengthAutoclick;
    public string StrengthClickCut, StrengthAutoclickCut;
    public Color32 colorClick, colorAutoclick;

    // Start events after get click or autoclick
    public void GetClick(string typeOfClick)
    {
        if (typeOfClick == "Click") { coinsCounter.CoinsValue += StrengthClick; }
        if (typeOfClick == "Autoclick") { coinsCounter.CoinsValue += StrengthAutoclick; }
        SpawnClickSpirit(typeOfClick);
    }

    // Spawn image that shows click value
    private void SpawnClickSpirit(string typeOfClick)
    {
        // Set key parameters
        string value = "";
        Color32 color = new Color32(255, 255, 255, 255);

        if (typeOfClick == "Click") 
        { 
            value = StrengthClickCut;
            color = colorClick;
        }
        if (typeOfClick == "Autoclick") 
        { 
            value = StrengthAutoclickCut;
            color = colorAutoclick;
        }

        // Determine the point of spawn
        int angle = Random.Range(0, 359);
        float radius = Random.Range(10, 40);
        radius /= 10;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Spawn the clickSpirit
        GameObject clickText = Instantiate(clickSpirit, new Vector3(x + centerImage.transform.position.x, y + centerImage.transform.position.y, -0.5f), Quaternion.identity);
        clickText.GetComponent<TextMeshPro>().text = value;
        clickText.GetComponent<TextMeshPro>().color = color;
    }
}
