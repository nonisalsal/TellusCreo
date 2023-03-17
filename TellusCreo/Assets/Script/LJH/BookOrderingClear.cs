using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOrderingClear : MonoBehaviour
{

    BookOrdering ClearBook1;
    BookOrdering ClearBook2;
    BookOrdering ClearBook3;
    BookOrdering ClearBook4;
    BookOrdering ClearBook5;
    BookOrdering ClearBook6;
    BookOrdering ClearBook7;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        //gameObject.SetActive(false);
        ClearBook1 = GameObject.Find("BookOrdering1").GetComponent<BookOrdering>();
        ClearBook2 = GameObject.Find("BookOrdering2").GetComponent<BookOrdering>();
        ClearBook3 = GameObject.Find("BookOrdering3").GetComponent<BookOrdering>();
        ClearBook4 = GameObject.Find("BookOrdering4").GetComponent<BookOrdering>();
        ClearBook5 = GameObject.Find("BookOrdering5").GetComponent<BookOrdering>();
        ClearBook6 = GameObject.Find("BookOrdering6").GetComponent<BookOrdering>();



        // Update is called once per frame

    }
        void Update()
    {
        
    }

    private void BookPuzzleClear()
    {
        if (ClearBook1.ClearCheck == true && ClearBook2.ClearCheck == true &&
            ClearBook3.ClearCheck == true && ClearBook4.ClearCheck == true && 
            ClearBook5.ClearCheck == true && ClearBook6.ClearCheck == true 
           )
        {
            //gameObject.SetActive(true);
            Debug.Log(555555);
        }

    }
}
