using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed=18f;
    public Camera main;
    public float defaultFovChange =50000;
    void Start() {
 main.fieldOfView= 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f )
        {
            main.fieldOfView = main.fieldOfView -(Input.GetAxis("Mouse ScrollWheel")*defaultFovChange);
            
        }
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.up * y;

        move.y = 0;
        controller.Move( move*speed*Time.deltaTime);        
        
    }
}
