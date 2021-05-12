using Windows.Storage;

namespace MagicSquare
{
    class LoadGame
    {
        private string timeString;
        private int[] arrayOfRandomIntegers;

        public LoadGame()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            string content = localSettings.Values["gameSaved"] as string;

            string[] t = content.Split(',');
            arrayOfRandomIntegers = new int[9];

            for (int i = 0; i < 9; i++)
                arrayOfRandomIntegers[i] = int.Parse(t[i]);

            timeString = t[t.Length - 1];
        }

        internal string GetTimeString()
        {
            return timeString;
        }

        internal int[] GetArray()
        {
            return arrayOfRandomIntegers;
        }

    }
}
