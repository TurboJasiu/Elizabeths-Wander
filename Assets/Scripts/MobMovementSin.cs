using UnityEngine;

public class MobMovementSin : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 1.0f;
    public float frequency = 0.5f;
    public bool invert = false;
    public bool invertX = false;
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (!invert && !invertX)
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.x * frequency) * amplitude;
            pos.y = sin + sinCenterY;
            transform.position = pos;
        }
        else if(invert && !invertX)
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.x * frequency) * amplitude;
            pos.y = -(sin + sinCenterY);
            transform.position = pos;
        }
        else if(!invert && invertX)
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(-pos.x * frequency) * amplitude;
            pos.y = sin + sinCenterY;
            transform.position = pos;
        }
        else if(invert && invertX)
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(-pos.x * frequency) * amplitude;
            pos.y = -(sin + sinCenterY);
            transform.position = pos;
        }
    }
}
