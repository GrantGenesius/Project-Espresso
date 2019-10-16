using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{


    //save and load general data here (timer, time passed, garden, etc)
    public static void SaveData_General(DB_General dbg) { 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/General_Time.esp";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData_General savedData_General = new SavedData_General(dbg);
        formatter.Serialize(stream, savedData_General);
        stream.Close();
    }

    public static SavedData_General LoadData_General()
    {
        string path = Application.persistentDataPath + "/General_Time.esp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData_General savedData_General = formatter.Deserialize(stream) as SavedData_General;
            stream.Close();

            return savedData_General;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    //save and load ingredient database (raw, processed, rare)
    public static void SaveData_Ingredients(DB_Ingredients dbi) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Inventory-Ingredients.esp";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData savedData = new SavedData(dbi);
        formatter.Serialize(stream, savedData);
        stream.Close();
    }

    public static SavedData LoadData_Ingredients() {
        string path = Application.persistentDataPath + "/Inventory-Ingredients.esp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData savedData = formatter.Deserialize(stream) as SavedData;
            stream.Close();

            return savedData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
