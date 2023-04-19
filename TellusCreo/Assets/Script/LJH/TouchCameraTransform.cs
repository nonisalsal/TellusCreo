using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraTransform : MonoBehaviour
{
    public class ChangeCameraPosition : MonoBehaviour
    {

        public Camera mainCamera;
        public Vector3 newCameraPosition;

        private void OnMouseDown()
        {
            mainCamera.transform.position = newCameraPosition;
        }
    }
}