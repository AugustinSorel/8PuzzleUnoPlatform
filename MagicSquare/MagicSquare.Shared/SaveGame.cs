using Windows.Storage;

namespace MagicSquare
{
    class SaveGame
    {
        public SaveGame(int[] arrayOfRandomIntegers, string timeAsString)
        {
            string content = string.Empty;
            foreach (var item in arrayOfRandomIntegers)
                content += item.ToString() + ",";
            content += timeAsString;

            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["gameSaved"] = content;
        }

    }
}
