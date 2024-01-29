using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public long CoinsValue, BankSize;

    [SerializeField] private Text coinsText;
    [SerializeField] private Image fullnessBank;

    private string[] shortcutCoins = new string[7] {"K", "M", "B", "T", "q", "Q", "s" };

    private void Update()
    {
        if (CoinsValue > BankSize) { CoinsValue = BankSize; }

        coinsText.text = SetCoinsText();
        fullnessBank.fillAmount = (float)CoinsValue / BankSize;
    }

    // Update coinsText with shortcut rules
    private string SetCoinsText()
    {
        double coins = CoinsValue;
        double bank = BankSize;

        string result = "";

        // Write current coins to correct view
        for (int i = 0; i < shortcutCoins.Length; i++)
        {
            if (coins / 1000 < 1) 
            {
                if (i == 0) { result = coins.ToString() + " / "; break; }
                else { result = coins.ToString() + shortcutCoins[i - 1] + " / "; break; }
            }
            else { coins = Math.Round(coins / 1000f, 2); }
        }

        // Write size of bank to correct view
        for (int j = 0; j < shortcutCoins.Length; j++)
        {
            if (bank / 1000 < 1)
            {
                if (j == 0) { result += bank.ToString(); break; }
                else { result += bank.ToString() + shortcutCoins[j - 1]; break; }
            }
            else { bank = Math.Round(bank / 1000f, 2); }
        }
        
        return result;
    }
}
