using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPoint : MonoBehaviour
{
    public bool Clear = false;
    private Image image;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }
    
    // Update is called once per frame
     

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TextFolder"))
        {
            if (collision.gameObject.GetComponent<TextFolder>().state == true)
            {
                
                Debug.Log("Clear");
                Clear = true;
                if (Clear == true)
                {
                    image.color = Color.yellow;
                }
            }
        }
    }
    
}
