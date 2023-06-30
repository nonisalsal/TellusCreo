using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetryClear : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject stove;
    //public GameObject Stove1;
    Trophy can;
    SymmetrySlot can1;
    Clock clear3;
    basket clear4;
    sand clear5;
    lyingbook clear6;
   

    private void Awake()
    {
       //gameObject.SetActive(false);
       can = GameObject.Find("trophyslot").GetComponent<Trophy>();
       can1 = GameObject.Find("bottleslot").GetComponent<SymmetrySlot>();
        clear3 = GameObject.Find("clockslot").GetComponent<Clock>();
        clear4 = GameObject.Find("basketslot").GetComponent<basket>();
        clear5 = GameObject.Find("sandslot").GetComponent<sand>();
        clear6 = GameObject.Find("lyingbook").GetComponent<lyingbook>();

    }
    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(can1.check);
        //Debug.Log(can.check1);
        SymmetryClear1();
    }
    private void SymmetryClear1()
    {
        if(can1.check == true && can.check1 == true && clear3.check3 == true && clear4.check4 == true && clear5.check5 == true && clear6.check6 == true)
        {
            //gameObject.SetActive(true);
            Debug.Log(555555);
        }


        //if (stove.GetComponent<Trophy>().check1 == true && Stove1.GetComponent<SymmetrySlot>().check == true)
        //{
        //    gameObject.SetActive(true);
        //    Debug.Log(555555);
        //}
    }
   
}
