using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField] private string sceneName;
    [SerializeField] private PlayerData playerData;

    public string SceneName => sceneName;
    public PlayerData PlayerData => playerData;

    public GameData(string sceneName, PlayerData playerData)
    {
        this.sceneName = sceneName;
        this.playerData = playerData;
    }
}

[System.Serializable]
public class PlayerData
{
    private Vector2 pos;
    private float maxHp;
    private float atk;
    private float def;
    private float speed ;
    private float jumpPower ;

    public Vector2 Pos => pos;
    public float MaxHp => maxHp;
    public float Atk => atk;
    public float Def => def;
    public float Speed => speed;
    public float JumpPower => jumpPower;

    public PlayerData(Vector2 pos, float maxHp, float atk, float def, float speed, float jumpPower)
    {
        this.pos = pos;
        this.maxHp = maxHp;
        this.atk = atk;
        this.def = def;
        this.speed = speed;
        this.jumpPower = jumpPower;
    }
}