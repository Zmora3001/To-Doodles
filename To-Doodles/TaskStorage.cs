using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace To_Doodles;

public static class TaskStorage
{
    private static readonly string SaveFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ToDoodles", "tasks.json"
    );

    public static void Save(List<Task> activeTasks, List<Task> completeTasks)
    {
        try
        {
            var data = new TaskData
            {
                Active = activeTasks,
                Complete = completeTasks
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            Directory.CreateDirectory(Path.GetDirectoryName(SaveFilePath)!);
            File.WriteAllText(SaveFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
        }
    }

    public static void Load(out List<Task> activeTasks, out List<Task> completeTasks)
    {
        activeTasks = new List<Task>();
        completeTasks = new List<Task>();

        try
        {
            if (!File.Exists(SaveFilePath))
                return;

            string json = File.ReadAllText(SaveFilePath);
            var data = JsonSerializer.Deserialize<TaskData>(json);

            if (data?.Active != null)
                activeTasks.AddRange(data.Active);

            if (data?.Complete != null)
                completeTasks.AddRange(data.Complete);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
        }
    }

    private class TaskData
    {
        public List<Task>? Active { get; set; }
        public List<Task>? Complete { get; set; }
    }
}