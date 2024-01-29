using UnityEngine;

public class LocalisationVariables : MonoBehaviour
{
    public string PerSec(string language)
    {
        switch (language)
        {
            case "ru":
                return " в сек.";
            case "en":
                return " per sec.";
            case "tr":
                return "Saniyede ";
        }

        return " в сек.";
    }


    public string PerClick(string language)
    {
        switch (language)
        {
            case "ru":
                return " за клик";
            case "en":
                return " for click";
            case "tr":
                return "Tıklama için ";
        }

        return " за клик";
    }

    public string AdvertisingIn(string language)
    {
        switch (language)
        {
            case "ru":
                return "Реклама через ";
            case "en":
                return "Advertising in ";
            case "tr":
                return " reklam";
        }

        return "Реклама через ";
    }

    public string DescriptionClickAd(string language)
    {
        switch (language)
        {
            case "ru":
                return "Хочешь получить минуту удвоенных кликов за просмотр рекламы?";
            case "en":
                return "Do you want to get a minute of double clicks for viewing an ad?";
            case "tr":
                return "Bir reklamı görüntülemek için bir dakikalık çift tıklama almak ister misiniz?";
        }

        return "Хочешь получить минуту удвоенных кликов за просмотр рекламы?";
    }

    public string DescriptionAutoclickAd(string language)
    {
        switch (language)
        {
            case "ru":
                return "Хочешь получить минуту удвоенных автокликов за просмотр рекламы?";
            case "en":
                return "Do you want to get a minute of double autoclicks for viewing an ad?";
            case "tr":
                return "Reklamları görüntülemek için bir dakikalık çift otomatik tıklama almak ister misiniz?";
        }

        return "Хочешь получить минуту удвоенных автокликов за просмотр рекламы?";
    }
}
