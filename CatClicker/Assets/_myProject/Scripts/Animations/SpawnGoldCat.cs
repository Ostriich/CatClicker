using UnityEngine;

public class SpawnGoldCat : MonoBehaviour
{
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private GameObject goldCat;
    [SerializeField] private float cooldown;

    private void Start()
    {
        Invoke("WakeUpCat", cooldown);
    }

    private void WakeUpCat()
    {
        goldCat.SetActive(true);
        goldCat.GetComponent<GoldCatBehaviour>().costCat = long.Parse((coinsCounter.BankSize * 0.2f).ToString());
        Invoke("WakeUpCat", cooldown);
    }
}
