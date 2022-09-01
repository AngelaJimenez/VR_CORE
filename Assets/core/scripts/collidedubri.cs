using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidedubri : MonoBehaviour
{
public Animator animateelement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown("space"))
        {
        animateelement.Rebind();
        animateelement.Update(0f);
        //animateelement.SetBool("isFalling", false);
        }
    }
    void OnTriggerEnter()
    {
        foreach (Camera c in Camera.allCameras)
        {
            if ( c.gameObject.name == "2dCamera" && c.gameObject.activeSelf)
            {
            animateelement.Play("Falling");    
            break;

            }
            
        }
    }
}
