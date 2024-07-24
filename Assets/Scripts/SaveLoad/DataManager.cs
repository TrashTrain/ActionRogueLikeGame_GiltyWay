using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public List<string> GetSaveFiles()
    {
        List<string> saveFiles = new List<string>();
        string path = Application.persistentDataPath;

        for (int i = 1; i <= 3; i++)
        {
            string filePath = Path.Combine(path, $"savefile_{i}.json");
            if (File.Exists(filePath))
            {
                saveFiles.Add(filePath);
            }
        }

        return saveFiles;
    }
    
    public void SaveGameData(GameData gameData, int slot)
    {
        string json = JsonUtility.ToJson(gameData);
        string path = Path.Combine(Application.persistentDataPath, $"savefile_{slot}.json");
        File.WriteAllText(path, json);
    }
    
    public void SaveGame(int slot)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        PlayerData playerData = new PlayerData(player.transform.position, player.maxhp, player.atk, player.def, player.speed, player.jumpPower);
        GameData gameData = new GameData(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, playerData);

        //string json = JsonUtility.ToJson(gameData);
        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        SaveGameData(gameData, slot);
    }

    public GameData LoadGameData(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }

        return null;
    }
    
    public async UniTask LoadGame(string filePath)
    {
        //string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        //GameData gameData = JsonUtility.FromJson<GameData>(json);
        
        GameData gameData = LoadGameData(filePath);
        
        if (gameData == null)
        {
            Debug.LogError("Load Fail : gameData is null");
            return;
        }
        
        //await SceneLoader.LoadScene(gameData.SceneName);
        await SceneManager.LoadSceneAsync(gameData.SceneName);
        ApplyPlayerData(gameData.PlayerData);
    }
    
    private void ApplyPlayerData(PlayerData playerData)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError($"{this.gameObject} : player is not found");
            return;
        }

        player.transform.position = playerData.Pos;
        player.maxhp = playerData.MaxHp;
        player.atk = playerData.Atk;
        player.def = playerData.Def;
        player.speed = playerData.Speed;
        player.jumpPower = playerData.JumpPower;
    }
}
