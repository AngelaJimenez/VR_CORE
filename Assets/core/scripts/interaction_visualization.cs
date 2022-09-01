using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_visualization : MonoBehaviour
{
    private Renderer myModel;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        myModel = GetComponent<Renderer>();
        color = myModel.material.color;
        color.a=0.6f;
        myModel.material.color=color;

        } 
     

    // Update is called once per frame
    void Update()
    {
        
        foreach (Camera c in Camera.allCameras)
        {
            if ( c.gameObject.name == "Main Camera" && c.gameObject.activeSelf)
            {

            color.a=0.6f;
            myModel.material.color=color;
            break;

            }
            else if(c.gameObject.name == "2dCamera" && c.gameObject.activeSelf  ){
            color.a=0;
            myModel.material.color=color;
             break;
            }
        }
        

    }
}
