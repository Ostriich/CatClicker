
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)

        // Ваши сохранения
        public long Money = 0;
        public long StrengthClick = 1;
        public long StrengthAutoclick = 0;
        public int SelectedCat = 0;
        public bool Sound = false;

        //Upgrades
        public int[] UpgradesClicks = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public bool[] UpgradesCat = new bool[15] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            //openLevels[1] = true;
        }
    }
}
