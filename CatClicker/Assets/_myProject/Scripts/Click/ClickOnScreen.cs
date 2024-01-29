using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnScreen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TapTapPanelBehaviour tapTapPanelBehaviour;
    [SerializeField] private ClicksProcessing clicksProcessing;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private RectTransform catContainer;
    [SerializeField] private int multiplierAnimation = 0;
    [SerializeField] AudioSource audioSourse;
    [SerializeField] private ClicksPanelInfo clicksPanelInfo;

    private float timer;

    // Processing a click on the screen
    public void OnPointerClick(PointerEventData eventData)
    {
        if (coinsCounter.CoinsValue < coinsCounter.BankSize)
        {
            AnimateCatAfterClick();
            tapTapPanelBehaviour.GetClick();
            clicksProcessing.GetClick("Click");
            audioSourse.PlayOneShot(audioSourse.clip);
        }
    }

    private void FixedUpdate()
    {
        // Call autoclick
        if (coinsCounter.CoinsValue < coinsCounter.BankSize) { timer += Time.deltaTime; }

        if (timer >= 1)
        {
            timer = 0;
            if (clicksPanelInfo.startStrengthPerSecond > 0) { clicksProcessing.GetClick("Autoclick"); }
        }

        // Animation cat Image after click on the screen
        if (catContainer.localScale.x > 1) { catContainer.localScale = new Vector3(1, 1, 1); multiplierAnimation = 0; }
        if (catContainer.localScale.x < 0.9) { multiplierAnimation = 1; }
        if (multiplierAnimation != 0) { catContainer.localScale += new Vector3(0.05f * multiplierAnimation, 0.05f * multiplierAnimation, 0); }
    }

    // Launch the animation
    private void AnimateCatAfterClick()
    {
        multiplierAnimation = -1;
    }
}
