using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public bool invertDirection = false; 
    public bool destroyOnEdge = false; 
    public bool movementType = false;
    private void FixedUpdate()
    {
        if(!movementType)
        {
            if (!invertDirection)
            {
                Vector2 pos = transform.position;
                pos.x += speed * Time.fixedDeltaTime;
                if (pos.x > 15)
                {
                    if (destroyOnEdge)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        pos.x = -15;
                    }
                }
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x -= speed * Time.fixedDeltaTime;
                if (pos.x < -15)
                {
                    if (destroyOnEdge)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        pos.x = 15;
                    }
                }
                transform.position = pos;
            }
        }
        else
        {
            if (!invertDirection)
            {
                Vector2 pos = transform.position;
                pos.x += speed * Time.fixedDeltaTime;
                pos.y += (speed * Time.fixedDeltaTime)*0.6f;
                if (pos.x > 15 || pos.y > 8.5)
                {
                    if (destroyOnEdge)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        pos.x = -15;
                        pos.y = -8.5f;
                    }
                }
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x -= speed * Time.fixedDeltaTime;
                pos.y -= (speed * Time.fixedDeltaTime) * 0.6f;
                if (pos.x < -15 || pos.y < -8.5)
                {
                    if (destroyOnEdge)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        pos.x = 15;
                        pos.y = 8.5f;
                    }
                }
                transform.position = pos;
            }
        }
    }
}
