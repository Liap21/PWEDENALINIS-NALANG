using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button newGameButton;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        saveButton.onClick.AddListener(SaveGameOnClick);
        loadButton.onClick.AddListener(LoadGameOnClick);
        newGameButton.onClick.AddListener(NewGameOnClick);

        LoadGame(); // Load game data on start
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        ResetGameData();
        SceneManager.LoadScene(1);
    }

    private void ResetGameData()
    {
        // Reset all game data to default values
        this.gameData.maxHealth = 100;
        this.gameData.currentHealth = 100;
        this.gameData.playerPosX = 0;
        this.gameData.playerPosY = 0;
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        // If no data can be loaded, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }
        else
        {
            // Push the loaded data to all other scripts that need it 
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
        }
    }

    public void SaveGame()
    {
        // Pass the data to other scripts so they can update it 
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // Save the data to a file using the data handler
        dataHandler.Save(gameData);
    }

    // Method to be called when the save button is clicked
    private void SaveGameOnClick()
    {
        SaveGame();
        Debug.Log("Game saved.");
    }

    // Method to be called when the load button is clicked
    private void LoadGameOnClick()
    {
        LoadGame();
        Debug.Log("Game loaded.");
    }

    // Method to be called when the new game button is clicked
    private void NewGameOnClick()
    {
        NewGame();
        Debug.Log("New game started.");
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
