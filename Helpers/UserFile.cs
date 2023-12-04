using System;
using SWIFTcard.Models;

namespace SWIFTcard.Helpers
{
    public static class UserFile
    {
        public static string GetDecksJson()
        {
            string file = Path.Combine(UserDirectory.GetAppDataDirectory(), "decks.json");
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            return file;
        }

        public static string GetCardsJson(Deck deck)
        {
            string file = Path.Combine(UserDirectory.GetDeckDirectory(deck), "cards.json");
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            return file;
        }

        public static async Task CopyFileFromAppPackageToAppDataDirectory(string appPackageFileName, string targetDirectory)
        {
            // Open the source file
            using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(appPackageFileName);

            // Create an output filename
            string targetFile = Path.Combine(targetDirectory, appPackageFileName);

            // Copy the file to the AppDataDirectory
            using FileStream outputStream = File.Create(targetFile);
            await inputStream.CopyToAsync(outputStream);
        }

    }
}

