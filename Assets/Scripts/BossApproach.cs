using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossApproach : MonoBehaviour
{
    public float speed = 2.5f;
    private void FixedUpdate()
    {
        if(transform.position.y > 5.5f)
        { 
            Vector2 pos = transform.position;
            pos.y -= speed * Time.fixedDeltaTime;
            transform.position = pos;
        }
        else
        {
            return;
        }
    }              
}
            
        

