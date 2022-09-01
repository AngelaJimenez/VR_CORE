using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed=12f;
    public GameObject flag;
    public GameObject main;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        Vector3 characterPosition = new Vector3(controller.gameObject.transform.position.x,1, controller.gameObject.transform.position.z);
        flag.transform.position = characterPosition;
        main.gameObject.transform.position = new Vector3(controller.transform.position.x,main.gameObject.transform.position.y,controller.transform.position.z);

        move.y = 0;
        controller.Move( move*speed*Time.deltaTime);        
        
    }
}
