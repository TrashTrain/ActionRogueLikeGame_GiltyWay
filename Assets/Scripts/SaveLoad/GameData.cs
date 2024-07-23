using UnityEngine;

[System.Serializable]
public class GameData
{
    // [SerializeField] private string sceneName;
    // [SerializeField] private PlayerData playerData;
    //
    // public string SceneName => sceneName;
    // public PlayerData PlayerData => playerData;
    
    public string SceneName;
    public PlayerData PlayerData;

    public GameData(string sceneName, PlayerData playerData)
    {
        this.SceneName = sceneName;
        this.PlayerData = playerData;
    }
}

[System.Serializable]
public class PlayerData
{
    // private Vector2 pos;
    // private float maxHp;
    // private float atk;
    // private float def;
    // private float speed ;
    // private float jumpPower ;
    //
    // public Vector2 Pos => pos;
    // public float MaxHp => maxHp;
    // public float Atk => atk;
    // public float Def => def;
    // public float Speed => speed;
    // public float JumpPower => jumpPower;

    
    public Vector2 Pos;
    public float MaxHp;
    public float Atk;
    public float Def;
    public float Speed;
    public float JumpPower;
    
    public PlayerData(Vector2 pos, float maxHp, float atk, float def, float speed, float jumpPower)
    {
        this.Pos = pos;
        this.MaxHp = maxHp;
        this.Atk = atk;
        this.Def = def;
        this.Speed = speed;
        this.JumpPower = jumpPower;
    }
}