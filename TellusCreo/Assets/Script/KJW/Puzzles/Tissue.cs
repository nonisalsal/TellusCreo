using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Tissue : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    float forceMultiplier = 6f;
    float torqueMultiplier = 1f;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(); // 랜덤 색상을 생성하는 메서드를 사용
    }

    public void PullTissue(bool order)
    {

        rigidbody2d.simulated = true;
        rigidbody2d.gravityScale = 0.8f;
       this.GetComponent<SpriteRenderer>().sortingOrder = 1;
        float dir = order ? 1f : -1f;

        Vector2 force = new Vector2(dir, 1f) * forceMultiplier;
        float torque = dir * torqueMultiplier;

        rigidbody2d.AddForce(force, ForceMode2D.Impulse);
        rigidbody2d.AddTorque(torque, ForceMode2D.Impulse);

        Destroy(gameObject, 0.8f);
      
    }

 
    
}
