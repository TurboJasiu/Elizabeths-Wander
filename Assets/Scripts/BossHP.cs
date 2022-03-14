using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int bossHP = 100;
    public int bossKills = 0;
    public static BossHP instance;
    private void Update()
    {
        instance = this;
    }
    public void BossDamage()
    {
        bossHP--;
        if(bossHP<=0)
        {
            Destroy(gameObject);
            Level.instance.startNextLevel = true;
            bossKills++;
            Player.instance.AddAttack();
        }
    }
}
