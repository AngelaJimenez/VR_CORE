    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.VFX ;
 using UnityEngine.UI;
public class InteractiveGUIXR : MonoBehaviour
{
    // Visual objects
    private GameObject temp;

    public GameObject[] Prefabs;
    
    
    private List<GameObject> gameObjects ;
    private GameObject actualObject;
    // Variables

    private Color tempColor;

    private Color focusColor = new Color(1.0f, 0.64f, 0.0f);
    private Color targetColor = new Color(1.0f, 0f, 0.0f);

    private Vector3 objectangles;
    private Vector3 objectsize;
    


    public GameObject playerPosition;
    // Start is called before the first frame update
    void Start()
    {

        gameObjects = new List<GameObject>();
        gameObjects.Add(playerPosition);
    }
    
    void Update()
    {
    }


    public void instantiateelement(string element)
    {
        int number= Int32.Parse(element);
        Vector3 top = new Vector3(playerPosition.transform.forward.x * 2+ playerPosition.transform.position.x,2,playerPosition.transform.forward.z * 2+ playerPosition.transform.position.z);
        GameObject newObject = Instantiate(Prefabs[number], top, Quaternion.Euler(-90, 0, 0));
        // newObject.AddComponent<XRGrabInteractable>();
        newObject.name = newObject.name + "-" + gameObjects.Count ;

        temp = newObject;
        gameObjects.Add(temp);
        if(temp.GetComponent<Renderer>()!=null && temp.GetComponent<VisualEffect>()==null )
        {
            tempColor = temp.GetComponent<Renderer>().material.color;

        }
        actualObject = newObject;
        
      
        
    }
    
  



}

