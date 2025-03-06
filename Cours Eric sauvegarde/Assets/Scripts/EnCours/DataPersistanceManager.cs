using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager SINGLETON { get; private set; }
    public GameData data;
    private List<IDataPersistence> dataPersistenceObject;

    private void Awake()
    {
        if (SINGLETON != null)
        {
            Destroy(this.gameObject);
            Debug.LogError("Trying to instantiate an other DataPersistanceManager SINGLETON");
        }
        else
        {
            SINGLETON = this; 
        }
    }

    private void Start()
    {
        this.dataPersistenceObject = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        data = new GameData();
    }
    
    public void LoadGame()
    {
        //Load les datas du JSON et les mettre au format GameData
        if (data == null)
        {
            Debug.Log("No data found. Creating default data");
            NewGame();
        }
        
        foreach (IDataPersistence item in dataPersistenceObject )
        {
            item.LoadData(data);
        }
        
        Debug.Log("Loaded data | Death count = " + data.DeathCount);
    }

    public void SaveGame()
    {
        foreach (IDataPersistence item in dataPersistenceObject )
        {
            item.SaveData(ref data);
        }
        Debug.Log("Data saved | Death count = " + data.DeathCount);
        
        //On convertit les GameDatas en JSON via le dataHandler
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> findAllDataPersistence = 
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(findAllDataPersistence);
    }


}