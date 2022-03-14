using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    private float baseSpeed = 10.0f;
    public Vector2 velocity;
    public float speedModifier=0.0f;
    public bool isEnemy = false;
    public bool invertDirection = false;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        velocity = direction * (baseSpeed + speedModifier);
    }

    private void FixedUpdate()
    {
        if(!invertDirection)
        {
            Vector2 pos = transform.position;
            pos += velocity * Time.fixedDeltaTime;
            transform.position = pos;
        }
        else
        {
            Vector2 pos = transform.position;
            pos -= velocity * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }
}

