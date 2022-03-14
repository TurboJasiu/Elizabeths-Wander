using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Attack[] types;
    public float speed = 5.0f;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;
    public static Player instance;
    public AudioSource src;
    public AudioClip fx;
    private void Start()
    {
        types = transform.GetComponentsInChildren<Attack>();
        foreach (Attack type in types)
        {
            type.isActive = true;
            if(type.attackLevelRequirement != 0)
            {
                type.gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        //sterowanie - przechwytywanie przyciskow
        moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        moveUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if(instance==null)
        {
            instance = this;
        }
    }
    
    private void FixedUpdate()
    {
        //ruch postaci
        Vector2 pos = transform.position;
        float moveAmount = speed * Time.fixedDeltaTime;
        if (speedUp)
        {
            moveAmount *= 2;
        }
        Vector2 move = Vector2.zero;
        if(moveUp)
        {
            move.y += moveAmount;
        }
        if(moveDown)
        {
            move.y -= moveAmount;
        }
        if(moveLeft)
        {
            move.x -= moveAmount;
        }
        if(moveRight)
        {
            move.x += moveAmount;
        }

        pos += move;
        
        if(pos.x < -13.75f)
        {
            pos.x = -13.75f;
        }
        if (pos.x > 13.75f)
        {
            pos.x = 13.75f;
        }
        if (pos.y < -7.3f)
        {
            pos.y = -7.3f;
        }
        if (pos.y > 7.3f)
        {
            pos.y = 7.3f;
        }
        transform.position = pos; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        if(projectile != null)
        {
            if(projectile.isEnemy)
            {
                Level.instance.LoseScore(10);
                Destroy(projectile.gameObject);
                src.PlayOneShot(fx);
            }
        }
        MobKilling kill = gameObject.GetComponent<MobKilling>(); 
        if(kill != null)
        {
            Destroy(gameObject);
            if(!kill.isBoss)
            { 
            Destroy(kill.gameObject);
            }
            Destroy(Level.instance.gameObject);
            SceneManager.LoadScene("Death");
        }
        if(Level.instance.score < 0)
        {
            Destroy(Level.instance.gameObject);
            SceneManager.LoadScene("Death");
        }
    }
    public void AddAttack()
    {
        foreach (Attack type in types)
        {
            if (type.attackLevelRequirement == BossHP.instance.bossKills)
            {
                type.gameObject.SetActive(true);
            }
        }
    }
}
