using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    //save and load record data here (drinks unlocked, spinCount, coupons made, etc)
    public static void SaveData_Record(DB_Records dbr) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/General_Records.esp";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData_Records savedData_Records = new SavedData_Records(dbr);
        formatter.Serialize(stream, savedData_Records);
        stream.Close();
    }

    public static SavedData_Records LoadData_Records() {
        string path = Application.persistentDataPath + "/General_Records.esp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData_Records savedData_Records = formatter.Deserialize(stream) as SavedData_Records;
            stream.Close();

            return savedData_Records;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //save and load garden data here (plantType, growthStage, moisturizeCD)
    public static void SaveData_Garden(DB_Garden dbga)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/General_Garden.esp";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData_Garden savedData_Garden = new SavedData_Garden(dbga);
        formatter.Serialize(stream, savedData_Garden);
        stream.Close();
    }

    public static SavedData_Garden LoadData_Garden()
    {
        string path = Application.persistentDataPath + "/General_Garden.esp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData_Garden savedData_Garden = formatter.Deserialize(stream) as SavedData_Garden;
            stream.Close();

            return savedData_Garden;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    //save and load general data here (timer, time passed, date, etc)
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
