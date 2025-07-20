using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace To_Doodles;

public static class TaskStorage
{
    // Pfad zur JSON-Datei, in der die Aufgaben gespeichert werden
    private static readonly string SaveFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ToDoodles", "tasks.json"
    );

    // Speichert die aktiven und abgeschlossenen Aufgaben in einer JSON-Datei so, dass man sie später wieder separat laden kann
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

    // Lädt die aktiven und abgeschlossenen Aufgaben aus der JSON-Datei
    public static void Load(out List<Task> tempActiveTasks, out List<Task> tempCompleteTasks)
    {
        // Temporäre Listen für die geladenen Aufgaben, da Listen in TaskManager private read-only sind
        tempActiveTasks = new List<Task>();
        tempCompleteTasks = new List<Task>();

        try
        {
            if (!File.Exists(SaveFilePath))
                return;

            string json = File.ReadAllText(SaveFilePath);
            var data = JsonSerializer.Deserialize<TaskData>(json);

            if (data?.Active != null) // Wenn vorhanden, fügt die aktiven Aufgaben zu Liste hinzu
                tempActiveTasks.AddRange(data.Active);

            if (data?.Complete != null) // Wenn vorhanden, fügt die abgeschlossenen Aufgaben zu Liste hinzu
                tempCompleteTasks.AddRange(data.Complete);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
        }
    }

    // Hilfsklasse für die Serialisierung der aktiven und abgeschlossenen Aufgaben
    private class TaskData
    {
        public List<Task>? Active { get; set; }
        public List<Task>? Complete { get; set; }
    }
}