using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CraftsWebApplication.Models;

namespace CraftsWebApplication.Core.Helpers
{
    public static class JsonFileConverter
    {
        public static IEnumerable<Product> GetContent(string fileName)
        {
            using (var jsonFileReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<Product>>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive  = true
                    });
            }
        }

        public static void WriteContent(string fileName, List<Product> products)
        {
            using (var outputStream = File.OpenWrite(fileName))
            {
                JsonSerializer.Serialize<List<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }
}
