using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;


public class GameManager2 : MonoBehaviour
{
    static GameManager2 s_instance = null;
    public static GameManager2 Instance { get { if (s_instance == null) return null; return s_instance; } }

    public enum Puzzle
    {
        HiddenHandWriting = 10,
        ComputerPassword,
    }


    

    // Start is called before the first frame update

    //public string targetTag = "Clickable"; // 클릭 가능한 게임 오브젝트의 태그
    //public float moveSpeed = 5f; // 카메라 이동 속도

    //private Transform mainCameraTransform;
    //private bool isMovingCamera;

    private void Start()
    {
        //mainCameraTransform = Camera.main.transform;
        //isMovingCamera = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!EventSystem.current.IsPointerOverGameObject()){

        }

        void HandlePuzzleClick()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, transform.forward, 10f);
            if (rayHit.collider == null)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject hitGameObject = rayHit.collider.gameObject;

                //switch ((Puzzle)[(int)hitGameObject.LightSwitch - 10])
                //{

                //}
            }


        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //    if (hit.collider != null && hit.collider.CompareTag(targetTag))
        //    {
        //        isMovingCamera = true;
        //    }
        //}

        //if (isMovingCamera)
        //{
        //    Vector3 targetPosition = mainCameraTransform.position;
        //    targetPosition.x = transform.position.x;
        //    targetPosition.y = transform.position.y;
        //    mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        //    if (mainCameraTransform.position == targetPosition)
        //    {
        //        isMovingCamera = false;
        //    }
        //}
    }
}