using UnityEngine;
using UnityEngine.UI;

public class AddSurePanel : MonoBehaviour
{
    public string addType;
    public string descriptionString;

    [SerializeField] private Text descriptionText;
    [SerializeField] private RewardedAd rewardedAd;

    // Change message to player
    private void Update()
    {
        if (gameObject.activeSelf) { descriptionText.text = descriptionString; }
    }

    public void ShowAdd()
    {
        if (addType == "Click") { rewardedAd.RewardDoubleClick(); }
        if (addType == "Autolick") { rewardedAd.RewardDoubleAutoclick(); }
    }
}
