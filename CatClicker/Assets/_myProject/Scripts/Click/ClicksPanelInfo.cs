using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ClicksPanelInfo : MonoBehaviour
{
    [SerializeField] private TapTapPanelBehaviour tapTapPanelBehaviour;
    [SerializeField] private ClicksProcessing clicksProcessing;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private Text textClick, textAutoclick;
    [SerializeField] private AddAutoclick addAutoclick;
    [SerializeField] private AddClick addClick;
    [SerializeField] private LocalisationVariables localisationVariables;

    public long startStrengthPerClick, outStrengthPerClick;
    public long startStrengthPerSecond, outStrengthPerSecond;

    private string[] shortcutValue = new string[7] { "K", "M", "B", "T", "q", "Q", "s" };

    private void Update()
    {
        // Set start strength values
        outStrengthPerClick = startStrengthPerClick;
        outStrengthPerSecond = startStrengthPerSecond;

        // Multiplier strength if TapTap boost is active
        if (tapTapPanelBehaviour.BoostIsActive)
        {
            outStrengthPerClick *= 2;
            outStrengthPerSecond *= 2;
        }

        // Multiplier add boosts
        if (addAutoclick.addWorking) { outStrengthPerSecond *= 2; }
        if (addClick.addWorking) { outStrengthPerClick *= 2; }

        // Print finish strength
        if (YandexGame.lang == "tr")
        {
            textClick.text = localisationVariables.PerClick("tr") + ShortcutValue(outStrengthPerClick);
            textAutoclick.text = localisationVariables.PerSec("tr") + ShortcutValue(outStrengthPerSecond);
        }
        else
        {
            textClick.text = ShortcutValue(outStrengthPerClick) + localisationVariables.PerClick(YandexGame.lang);
            textAutoclick.text = ShortcutValue(outStrengthPerSecond) + localisationVariables.PerSec(YandexGame.lang);
        }

        // Send values in clicksProcessing
        clicksProcessing.StrengthClick = outStrengthPerClick;
        clicksProcessing.StrengthAutoclick = outStrengthPerSecond;

        clicksProcessing.StrengthClickCut = ShortcutValue(outStrengthPerClick);
        clicksProcessing.StrengthAutoclickCut = ShortcutValue(outStrengthPerSecond);
        
        // Change color in Info and in Processing
        if (startStrengthPerClick == outStrengthPerClick) 
        { 
            clicksProcessing.colorClick = Color.white;
            textClick.color = new Color32 (125, 63, 30, 255);
        }
        else 
        { 
            clicksProcessing.colorClick = Color.red;
            textClick.color = Color.red;
        }

        if (startStrengthPerSecond == outStrengthPerSecond) 
        { 
            clicksProcessing.colorAutoclick = Color.white;
            textAutoclick.color = new Color32(125, 63, 30, 255);
        }
        else 
        { 
            clicksProcessing.colorAutoclick = Color.red;
            textAutoclick.color = Color.red;
        }
    }

    // Write any value to correct view
    private string ShortcutValue(double value)
    {
        string result = "";

        for (int i = 0; i < shortcutValue.Length; i++)
        {
            if (value / 1000 < 1)
            {
                if (i == 0) { result = value.ToString(); break; }
                else { result = value.ToString() + shortcutValue[i - 1]; break; }
            }
            else { value = Math.Round(value / 1000f, 2); }
        }

        return result;
    }
}
