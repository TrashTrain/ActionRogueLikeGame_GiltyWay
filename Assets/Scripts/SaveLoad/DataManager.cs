using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    public float playStartTime;
    public float playTime;
    public int currentSlot;

    //Init for New Game
    public void InitPlayTime()
    {
        currentSlot = 0;
        playTime = 0;
        playStartTime = Time.time;
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playTime = 0;
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
            else
            {
                saveFiles.Add(null);
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
        UpdatePlayTime(currentSlot);
        
        PlayerController player = FindObjectOfType<PlayerController>();
        PlayerData playerData = new PlayerData(player.transform.position, player.maxhp, player.atk, player.def, player.speed, player.jumpPower);
        BasicPistol basicPistol = FindObjectOfType<BasicPistol>();
        PassiveSkillData passiveData = new PassiveSkillData(basicPistol.automaticBulletCnt, basicPistol.bulletSize);
        GameData gameData = new GameData(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, playerData, playTime, passiveData);

        //string json = JsonUtility.ToJson(gameData);
        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        SaveGameData(gameData, slot);
    }

    public void UpdatePlayTime(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"savefile_{slot}.json");
        
        if (File.Exists(path))
        {
            playTime = LoadGameData(path).PlayTime;
        }
        else
        {
            playTime = 0;
        }
        playTime += Time.time - playStartTime;
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
        ApplyPassiveData(gameData.PassiveSkillData);
        BGM.instance?.PlayBGM(gameData.SceneName);

        playStartTime = Time.time;
    }

    private void ApplyPassiveData(PassiveSkillData data)
    {
        BasicPistol passiveData = FindObjectOfType<BasicPistol>();
        if (passiveData == null) return;
        passiveData.automaticBulletCnt = data.automaticBulletCnt;
        passiveData.bulletSize = data.bulletSize;
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
        UIManager.instance.playerInfo.playerHpBar.InitPlayerHp(player.maxhp);
        player.atk = playerData.Atk;
        player.def = playerData.Def;
        player.speed = playerData.Speed;
        player.jumpPower = playerData.JumpPower;
    }
}
