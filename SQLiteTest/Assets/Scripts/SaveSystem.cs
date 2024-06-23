using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveSystem : MonoBehaviour
{
    private static SaveSystem _instance;
    [SerializeField] private string folderPath;
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        folderPath = Path.Combine(Application.dataPath, "SaveDataFolder");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("Create a SaveDataFolder");
        }
        else
        {
            Debug.Log("Already having a SaveDataFolder");
        }
    }
    public static void SaveDataWithInstanceJson<T>(T sender)
    {
        _instance.SaveDataWithJson(sender);
    }
    public static T LoadDataWithInstanceJson<T>(T sender)
    {
        return _instance.LoadDataWithJson(sender);
    }
    private void SaveDataWithJson<T>(T sender)
    {
        string saveData = JsonUtility.ToJson(sender);
        string saveDataPath = Path.Combine(folderPath, typeof(T).Name);
        
        File.WriteAllText(saveDataPath,saveData);
        Debug.Log("Save successful");
    }
    private T LoadDataWithJson<T>(T sender)
    {
        string dataPath = Path.Combine(folderPath, typeof(T).Name);
        string loadDataPath = File.ReadAllText(dataPath);
        
        T readData = JsonUtility.FromJson<T>(loadDataPath);
        Debug.Log("Load successful");
        return readData;
    }
}
