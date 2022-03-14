using UnityEngine;

public class MobKilling : MonoBehaviour
{
    public AudioSource fxSrc;
    public AudioClip hitFx;
    bool canBeKilled = false;
    public bool isBoss = false;
    public int scoreValue = 10;
    
    private void Update()
    {
        if (transform.position.x > -14 && transform.position.x < 14 && transform.position.y <8) 
        {
            canBeKilled = true;
            Attack[] types = transform.GetComponentsInChildren<Attack>();
            foreach (Attack type in types)
            {
                type.isActive = true;
            }
        }
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        if (projectile != null)
        {
            if (!projectile.isEnemy && !isBoss && canBeKilled) 
            {
                Destroy(gameObject);
                Destroy(projectile.gameObject);
                Level.instance.AddScore(scoreValue);
                fxSrc.PlayOneShot(hitFx);
            }
            if(!projectile.isEnemy && isBoss && canBeKilled)
            {
                BossHP.instance.BossDamage();
                Destroy(projectile.gameObject);
                fxSrc.PlayOneShot(hitFx);
            }
        }
    }
}
