using BlazorApp.Model;
using System.Text.Json;

namespace BlazorApp.Data
{
    public class DataSet
    {
        private List<Person> data = null;

        public List<Person> GetData()
        {
            if (data == null)
            {
                var path = @"C:\Users\Administrator\source\repos\asp2\data2024.json";
                var jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Person>>(jsonString);
            }

            return data;
        }
    }
}
