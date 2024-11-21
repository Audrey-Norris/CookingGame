using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class SavingSystem : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    [SerializeField] private List<IDataPersistance> dataPersistanceObjects;

    public FileDataManager dataManager;


    private void Start()
    {
        dataManager = new FileDataManager(Application.persistentDataPath, fileName);
        dataPersistanceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    } 

    public bool CheckData()
    {
        dataManager = new FileDataManager(Application.persistentDataPath, fileName);
        gameData = dataManager.Load();
        string currentScene = SceneManager.GetActiveScene().name;
        if (gameData == null)
        {
            return false;
        }
        return true;
    }

    public void SaveGame()
    {
        //Pass the data to other scripts so they can update it
        //Save that data to a file using the data handler
        foreach (IDataPersistance obj in dataPersistanceObjects)
        {
            obj.SaveData(ref gameData);
        }
        dataManager.Save(gameData);
    }
    public void LoadGame() {
        dataManager = new FileDataManager(Application.persistentDataPath, fileName);
        gameData = dataManager.Load();
        //If no data can be loaded initialize to a new game
        string currentScene = SceneManager.GetActiveScene().name;
        if (gameData == null && currentScene == "SetupScene") {
            Debug.Log("No data was found, making new Save.");
            NewGame();
        }

        foreach (IDataPersistance obj in dataPersistanceObjects) {
            obj.LoadData(gameData);
        }
    }

    public void NewGame()
    {
        gameData = new GameData();
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }

}