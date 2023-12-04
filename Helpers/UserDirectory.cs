using System;
using SWIFTcard.Models;

namespace SWIFTcard.Helpers
{
	public static class UserDirectory
	{
        public static string GetAppDataDirectory()
        {
            string dir = Path.Combine(FileSystem.Current.AppDataDirectory, "data");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GetDeckDirectory(Deck deck)
        {
            string dir = Path.Combine(GetAppDataDirectory(), deck.Id);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}

