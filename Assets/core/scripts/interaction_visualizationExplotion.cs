using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction_visualizationExplotion : MonoBehaviour
{
    private Renderer myModel;
    private Color color;
    public ParticleSystem particles;
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
            if ( c.gameObject.name == "Main Camera" && c.gameObject.activeSelf  && particles.gameObject.activeSelf)
            {

            color.a=0.6f;
            myModel.material.color=color;
            break;

            }
            else if((c.gameObject.name == "2dCamera" && c.gameObject.activeSelf)|| !particles.gameObject.activeSelf){
            color.a=0;
            myModel.material.color=color;
             break;
            }
        }
        

    }
}
