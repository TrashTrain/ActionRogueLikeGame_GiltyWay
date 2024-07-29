
public class PassiveSkillData
{
    private int automaticBulletCnt = 0;
    private float bulletSize = 1.0f;
    public static PassiveSkillData instance = new ();
    public int AutomaticBulletCnt
    {
        get { return automaticBulletCnt; }

        set{ automaticBulletCnt = value; }
    }

    public float BulletSize
    {
        get { return bulletSize; }
        set { bulletSize = value; }
    }


}
