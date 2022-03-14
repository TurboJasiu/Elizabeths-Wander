using UnityEngine;

public class Attack : MonoBehaviour
{
    public Projectile projectile;
    Vector2 direction;
    public bool autoShoot = true;
    public float shootIntervalSeconds = 0.33f; 
    public float shootDelaySeconds = 0.0f;
    float shootTimer = 0.0f;
    float delayTimer = 0.0f;
    float playerShootTimer = 0.0f;
    float playerShootIntervalSeconds = 1.5f;
    const float playerShootIntervalBase = 1.5f;
    public bool isActive = false;
    public bool isPlayer = false;
    int score = 0;
    int tempScore = 0;
    public int attackLevelRequirement = 0;
    public AudioSource fxSRC;
    public AudioClip shot;



    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        if(autoShoot && !isPlayer) 
        { 
            if(delayTimer >= shootDelaySeconds)
            {
                if(shootTimer>=shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
        if (autoShoot && isPlayer)
        {
                if (playerShootTimer >= playerShootIntervalSeconds)
                { 
                    Shoot();
                    playerShootTimer = 0;
                    ShootSound();
                }
                else
                {
                    playerShootTimer += Time.deltaTime;
                }
        }
        if (score != tempScore)
        {
            tempScore = score;
            playerShootingSpeed();
        }
        if (Level.instance != null)
        {
            score = Level.instance.score;
        }
        direction = (transform.localRotation * Vector2.up).normalized;
    }
    public void Shoot()
    {   
        GameObject go = Instantiate(projectile.gameObject, transform.position, Quaternion.identity);
        Projectile goProjectile = go.GetComponent<Projectile>();
        goProjectile.direction = direction;
    }
    private void playerShootingSpeed()
    {
        if (playerShootIntervalSeconds >= 0.5f)
        {
            playerShootIntervalSeconds = playerShootIntervalBase;
            playerShootIntervalSeconds -= Level.instance.score / 500.0f;
        }
    }
    public void ShootSound()
    {
        fxSRC.PlayOneShot(shot);
    }
}
