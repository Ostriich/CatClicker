using UnityEngine;
using YG;

public class RewardedAd : MonoBehaviour
{
    private int rewardedId;

    [SerializeField] private AddAutoclick addAutoclick;
    [SerializeField] private AddClick addClick;

    public void RewardDoubleClick()
    {
        rewardedId = 1;
        ShowRewarded(1);
    }

    public void RewardDoubleAutoclick()
    {
        rewardedId = 2;
        ShowRewarded(2);
    }

    public void GetReward()
    {
        switch (rewardedId)
        {
            case 1:
                addClick.StartBoost();
                break;
            case 2:
                addAutoclick.StartBoost();
                break;
        }
    }

    private void ShowRewarded(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
