using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOrdering : MonoBehaviour
{
    public float X1;
    public float Y1;
    public int Book; //책 오브젝트가 해당 위치에 있다면 카운트되게 하는 인수
    public bool ClearCheck;

    public GameObject ClearBook;
    public GameObject rb;
    Book trans;



  

    // Start is called before the first frame update
    void Start()
    {
        Book = 0;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    
    public void OnTriggerStay2D(Collider2D collider)
    {
        
        if (collider.CompareTag("P_stop"))
        {
            if(Book == 0)
            {
                Instantiate(collider.gameObject, new Vector3(X1, Y1, 0), Quaternion.identity);
                Destroy(collider.gameObject);
                

                Book = 1;
                //Debug.Log(Book);
                ClearBookCheck(collider);
            }
            //else
            //{
            //    Instantiate(collider.gameObject, new Vector3(X1, Y1, 0), Quaternion.identity);
            //    Destroy(collider.gameObject);

            //}
           //if(Book == 1)
           // {
           //     collider.gameObject.GetComponent<Book>();
           //     collider.transform.position = new Vector2(trans.trans.x,trans.trans.y);

           // }
        }

    


        //if (collider.transform.CompareTag("P_stop"))
        //{
        //    collider.transform.SetParent(transform);
        //    if (transform.childCount < 1)
        //    {
        //        collider.transform.SetParent(transform);
        //    }

        //}
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("P_move"))
        {
            Book=0;
            //Debug.Log(Book);

        }

    }
  
    private void ClearBookCheck(Collider2D collider)
    {
        if(collider.gameObject.name == ClearBook.name)
        {
            ClearCheck = true;
            Debug.Log(ClearCheck);
        }
        else if (collider.gameObject.name != ClearBook.name)
        {
            ClearCheck = false;
            Debug.Log(ClearCheck);
        }

    }
}