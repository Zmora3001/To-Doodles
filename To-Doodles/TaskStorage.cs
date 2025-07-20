using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public static void Save(ObservableCollection<Task> activeTasks, ObservableCollection<Task> completeTasks)
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
    public static void Load(out ObservableCollection<Task> tempActiveTasks, out ObservableCollection<Task> tempCompleteTasks)
    {
        // Temporäre Listen für die geladenen Aufgaben, da Listen in TaskManager private read-only sind
        tempActiveTasks = new ObservableCollection<Task>();
        tempCompleteTasks = new ObservableCollection<Task>();

        try
        {
            if (!File.Exists(SaveFilePath))
                return;

            string json = File.ReadAllText(SaveFilePath);
            var data = JsonSerializer.Deserialize<TaskData>(json);

            if (data?.Active != null) // Wenn vorhanden, fügt die aktiven Aufgaben zu Liste hinzu
                foreach (var task in data.Active)
                    tempActiveTasks.Add(task);

            if (data?.Complete != null) // Wenn vorhanden, fügt die abgeschlossenen Aufgaben zu Liste hinzu
                foreach (var task in data.Complete)
                    tempCompleteTasks.Add(task);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
        }
    }

    // Hilfsklasse für die Serialisierung der aktiven und abgeschlossenen Aufgaben
    private class TaskData
    {
        public ObservableCollection<Task>? Active { get; set; }
        public ObservableCollection<Task>? Complete { get; set; }
    }
}