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
 * be unique. Additionally, there are 7 spots you must modifiy when adding
 * fields.
 */
public class DataManager : MonoBehaviour
{
    // Constants
    const string DEFAULT_USERNAME      = "global";
    const int    INIT_DAY              = 1;
    const float  INIT_CASH             = 0f;
    const bool   DEFAULT_DAY_IN_ACTION = true;

    public string username    { get; set; }
    public int    day         { get; set; }
    public float  cash        { get; set; }
    public bool   dayInAction { get; set; }

    void Start()
    {
        username    = DEFAULT_USERNAME;
        day         = INIT_DAY;
        cash        = INIT_CASH;
        dayInAction = DEFAULT_DAY_IN_ACTION;
    }

    // CREATE and UPDATE
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        string dirPath = String.Format("{0}/{1}",
            Application.persistentDataPath, username);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        FileStream file = File.Create(dirPath + "/BakeryData.dat");

        SaveData data = new SaveData()
        {
            username    = username,
            day         = day,
            cash        = cash,
            dayInAction = dayInAction
        };

        bf.Serialize(file, data);
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

            username    = data.username;
            day         = data.day;
            cash        = data.cash;
            dayInAction = data.dayInAction;

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
            username    = DEFAULT_USERNAME;
            day         = INIT_DAY;
            cash        = INIT_CASH;
            dayInAction = DEFAULT_DAY_IN_ACTION;
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
            Application.persistentDataPath, username);
    }
}

[Serializable]
class SaveData
{
    public string username;
    public int    day;
    public float  cash;
    public bool   dayInAction;
}