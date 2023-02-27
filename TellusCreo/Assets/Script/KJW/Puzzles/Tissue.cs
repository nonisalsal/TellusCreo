using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tissue : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    float forceMultiplier = 6f;
    float torqueMultiplier = 1f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    public void PullTissue(bool order)
    {

        rigidbody2D.simulated = true;
        rigidbody2D.gravityScale = 0.8f;
       this.GetComponent<SpriteRenderer>().sortingOrder = 1;
        float dir = order ? 1f : -1f;

        Vector2 force = new Vector2(dir, 1f) * forceMultiplier;
        float torque = dir * torqueMultiplier;

        rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        rigidbody2D.AddTorque(torque, ForceMode2D.Impulse);

        Destroy(gameObject, 0.8f);
      
    }

}
