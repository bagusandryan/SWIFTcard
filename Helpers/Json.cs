using System;
using Newtonsoft.Json;

namespace SWIFTcard.Helpers
{
	public static class Json
	{
        public static void Write(string path, object objectToWrite)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, objectToWrite);
            }
        }
    }
}

