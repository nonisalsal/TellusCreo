using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraContol : MonoBehaviour
{
    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void backgroundmove()
    {

        Camera.main.transform.position = new Vector3(targetPosition.position.x, targetPosition.position.y, Camera.main.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
