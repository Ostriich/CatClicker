using UnityEngine;
using UnityEngine.UI;

public class FullBank : MonoBehaviour
{
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private GameObject buttonCats;
    [SerializeField] private Text coinsValueText;

    [SerializeField] private float deltaTime;

    private bool isFull = false;

    private void Update()
    {
        if (coinsCounter.CoinsValue >= coinsCounter.BankSize)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
            buttonCats.transform.localScale = new Vector3(1, 1, 1);
            coinsValueText.color = Color.white;
        }     
    }

    // Animation
    private void FixedUpdate()
    {
        if (isFull)
        {
            buttonCats.transform.localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1.1f, 1.1f, 1), Mathf.PingPong(Time.time, 0.5f) / 0.5f);
            coinsValueText.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 0.5f) / 0.5f);
        }
    }
}
