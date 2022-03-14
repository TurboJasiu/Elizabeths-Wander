using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float boundaryLeft = -6f;
    public float boundaryRight = 6f;
    bool bounce = true;
    private void FixedUpdate()
    {
        if (transform.position.y <= 5.5f)
        {
            if(bounce)
            {
                Vector2 pos = transform.position;
                pos.x += speed * Time.fixedDeltaTime;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x -= speed * Time.fixedDeltaTime;
                transform.position = pos;
            }
        }
        if(transform.position.x >= boundaryRight)
        {
            bounce = false;
        }
        if (transform.position.x <= boundaryLeft)
        {
            bounce = true;
        }
    }
}
