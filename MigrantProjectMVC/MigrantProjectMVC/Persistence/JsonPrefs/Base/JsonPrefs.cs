using System.Text.Json;

namespace MigrantProjectMVC.Models.JsonPrefs.Base
{
    public class JsonPrefs<T>
    {
        private string _filePath;
        private JsonSerializerOptions _jsonOptions;
        public JsonPrefs(string filePath)
        {
            _filePath = filePath;
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.WriteIndented = true;
            
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        public T LoadFromJson()
        {
            using (var fileStream = new FileStream(_filePath, FileMode.Open))
            {
                try
                {
                    return JsonSerializer.Deserialize<T>(fileStream, _jsonOptions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Activator.CreateInstance<T>();
                }
            }
        }

        public bool SaveToJson(T model)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(model, _jsonOptions);
                File.WriteAllText(_filePath, jsonData);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"error when try to save model: {typeof(T).Name}, error: {exception.Message}");
                return false;
            }
        }
    }
}
