using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 * BakeryData
 * 
 * Description: CRUD operations for essential data for the bakery game's 
 * mechanics. Stored as a persisted .dat file in a binary format as a layer of 
 * security against user manipulation. By default it saves data to the "global"
 * user.
 * 
 * WARNING: This implementation relies on the fact that all usernames will
 * be unique. Additionally, there are 4 spots you must modifiy when adding
 * fields.
 */
public class DataManager : MonoBehaviour
{
    [SerializeField] BakeryManager bakeryManager;

    // CREATE and UPDATE
    public void SaveGame(SaveData saveData)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string dirPath = String.Format("{0}/{1}",
            Application.persistentDataPath, bakeryManager.username);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        FileStream file = File.Create(dirPath + "/BakeryData.dat");

        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game data saved!");
    }

    // READ
    public void LoadGame()
    {
        if (File.Exists(getDataFilePath()))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(getDataFilePath(), FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            bakeryManager.loadGame(data);

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    // DELETE
    public void DeleteData()
    {
        if (File.Exists(getDataFilePath()))
        {
            File.Delete(getDataFilePath());
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    /*
     * getDataFilePath
     * 
     * Description: Creates a path to the current user data file. Does NOT 
     * guarantee path exists.
     * 
     * return: (string) path to current user.
     */
    private string getDataFilePath()
    {
        return String.Format("{0}/{1}/BakeryData.dat",
            Application.persistentDataPath, bakeryManager.username);
    }
}

