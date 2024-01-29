using UnityEngine;

public class GoldCatBehaviour : MonoBehaviour
{
    public long costCat = 0;

    [SerializeField] private CoinsCounter coinsCounter;

    private float lifeTimer;

    public void GetClick()
    {
        coinsCounter.CoinsValue += costCat;

        lifeTimer = 0;

        // Restart Animation
        GetComponent<Animator>().enabled = false;
        GetComponent<Animator>().enabled = true;

        // Start inactive Cat
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (lifeTimer >= 12)
        {
            lifeTimer = 0;

            // Restart Animation
            GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().enabled = true;

            // Start inactive Cat
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        lifeTimer += Time.deltaTime;
    }
}
