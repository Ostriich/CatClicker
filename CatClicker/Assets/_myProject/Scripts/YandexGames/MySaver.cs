using UnityEngine;
using YG;

public class MySaver : MonoBehaviour
{
	// Variables

	[SerializeField] private CoinsCounter coinsCounter;
	[SerializeField] private ClicksPanelInfo clicksPanelInfo;
	[SerializeField] private ClickUpgrades clickUpgrades;
	[SerializeField] private CatUpgrades catUpgrades;
	[SerializeField] private SoundControl soundControl;

	// Подписываемся на событие GetDataEvent в OnEnable
	private void OnEnable() => YandexGame.GetDataEvent += GetData;

	// Отписываемся от события GetDataEvent в OnDisable
	private void OnDisable() => YandexGame.GetDataEvent -= GetData;

	private void Awake()
	{
		// Проверяем запустился ли плагин
		if (YandexGame.SDKEnabled == true)
		{
			// Если запустился, то запускаем Ваш метод
			GetData();

			// Если плагин еще не прогрузился, то метод не запуститься в методе Start,
			// но он запустится при вызове события GetDataEvent, после прогрузки плагина
		}
	}

    private void Start()
    {
		Invoke("SaveAllData", 5);
    }

    // Ваш метод, который будет запускаться в старте
    public void GetData()
	{
		coinsCounter.CoinsValue = YandexGame.savesData.Money;

		clicksPanelInfo.startStrengthPerClick = YandexGame.savesData.StrengthClick;
		clicksPanelInfo.startStrengthPerSecond = YandexGame.savesData.StrengthAutoclick;

		clickUpgrades.countBoughtUpgrades = YandexGame.savesData.UpgradesClicks;
		clickUpgrades.UpdateAll();

		catUpgrades.catIsBought = YandexGame.savesData.UpgradesCat;
		catUpgrades.selectedCatImage = YandexGame.savesData.SelectedCat;
		catUpgrades.UpdateAll();

		soundControl.SoundOff = YandexGame.savesData.Sound;
		soundControl.UpdateSound();
	}

	public void ResetSaves()
    {
		YandexGame.ResetSaveProgress();
		YandexGame.SaveProgress();
    }

	public void SaveAllData()
    {
		YandexGame.savesData.Money = coinsCounter.CoinsValue;

		YandexGame.savesData.StrengthClick = clicksPanelInfo.startStrengthPerClick;
		YandexGame.savesData.StrengthAutoclick = clicksPanelInfo.startStrengthPerSecond;

		YandexGame.savesData.UpgradesClicks = clickUpgrades.countBoughtUpgrades;

		YandexGame.savesData.UpgradesCat = catUpgrades.catIsBought;
		YandexGame.savesData.SelectedCat = catUpgrades.selectedCatImage;

		YandexGame.savesData.Sound = soundControl.SoundOff;
		YandexGame.SaveProgress();

		Invoke("SaveAllData", 1);
	}
}
