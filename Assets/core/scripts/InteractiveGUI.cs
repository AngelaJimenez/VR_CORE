    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.VFX ;
 using UnityEngine.UI;
public class InteractiveGUI : MonoBehaviour
{
    // Visual objects
    private GameObject temp;

    public GameObject[] Prefabs;
    public Button element_destroy;
    public Slider rotation_slider;
    public Slider trigger_slider_z;
    public Slider trigger_slider_x;
    
    public GameObject element_selected;
    public GameObject image_selected;
    
    private List<GameObject> gameObjects ;
    private GameObject actualObject;
    // Variables

    private Color tempColor;

    private Color focusColor = new Color(1.0f, 0.64f, 0.0f);
    private Color targetColor = new Color(1.0f, 0f, 0.0f);

    private Vector3 tempClicked;
    private float current_Size_X;
    private float current_Size_Z;
    private float currentY;
    private Vector3 objectangles;
    private Vector3 objectsize;
    

    public Camera main;
    public GameObject camera2d;

    public GameObject deselect;
    public GameObject playerPosition;
    private CharacterController controler;

    public GameObject[] desableOnFirstView;
    public GameObject[] desableOnTopView;

    private CharacterController controlerCamera;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = image_selected.GetComponent<RectTransform>();

        gameObjects = new List<GameObject>();
        hideelements();
        controler = camera2d.GetComponent<CharacterController>();
        gameObjects.Add(playerPosition);
        foreach (GameObject el in desableOnFirstView){
                el.SetActive(!main.gameObject.activeSelf);
            }
        foreach (GameObject el in desableOnTopView){
                el.SetActive(main.gameObject.activeSelf);
            }
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            main.gameObject.SetActive(!main.gameObject.activeSelf);
            camera2d.gameObject.SetActive(!camera2d.gameObject.activeSelf);
            deselect.SetActive(main.gameObject.activeSelf);

            foreach (GameObject el in desableOnFirstView){
                el.SetActive(!main.gameObject.activeSelf);
            }
            foreach (GameObject el in desableOnTopView){
                el.SetActive(main.gameObject.activeSelf);
            }
            Cursor.lockState = CursorLockMode.None;
            if (!main.gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked; 
                actualObject =null;
                hideelements();               
            }
            main.fieldOfView= 10;

        }
        if (main.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000))
                {
                    
                    tempClicked = hit.point;
                    
                    if (!hit.transform.gameObject.name.Contains("Plane") &&!hit.transform.gameObject.CompareTag("school") )
                    {

                        temp = hit.transform.gameObject;
                        
                        
                        actualObject = temp;
                        if (temp.GetComponent<Renderer>() != null && temp.GetComponent<VisualEffect>() == null)
                        {
                            tempColor = temp.GetComponent<Renderer>().material.color;
                            temp.GetComponent<Renderer>().material.color = focusColor;

                        }

                        
                        objectangles = actualObject.transform.rotation.eulerAngles;
                        objectsize = actualObject.transform.localScale;
                        current_Size_X = objectsize.x;
                        current_Size_Z = objectsize.z;
                        trigger_slider_z.value = current_Size_Z;
                        trigger_slider_x.value = current_Size_X;
                        
                        currentY = objectangles.y;
                        rotation_slider.value = currentY;

                    }
                    else
                    {
                        temp = null;
                    }
                }
            }
            

            if (Input.GetMouseButtonUp(0) && temp != null)
            {
                if (temp.GetComponent<Renderer>() != null && temp.GetComponent<VisualEffect>() == null)
                {
                    temp.GetComponent<Renderer>().material.color = tempColor;
                }
            }
            if (actualObject != null)
            {
                hideelements();
                showelements();
                actualObject.transform.rotation = Quaternion.Euler(objectangles.x, currentY, objectangles.z);
                actualObject.transform.localScale = new Vector3(current_Size_X,objectsize.y,current_Size_Z);
            }
            else{
                hideelements();
            }
        }

    }


    public void instantiateelement(string element)
    {
        Debug.Log("Se está INSTANCIANDO");
        int number= Int32.Parse(element);
        Vector3 pos = new Vector3(playerPosition.transform.position.x+2, 0,playerPosition.transform.position.z);
        GameObject newObject = Instantiate(Prefabs[number], pos, Quaternion.Euler(-90, 0, 0));
        newObject.AddComponent<DragObject>();
        newObject.name = newObject.name + "-" + gameObjects.Count ;

        temp = newObject;
        gameObjects.Add(temp);
        if(temp.GetComponent<Renderer>()!=null && temp.GetComponent<VisualEffect>()==null )
        {
            tempColor = temp.GetComponent<Renderer>().material.color;

        }
        actualObject = newObject;
        
      
        currentY  = 0;
        objectsize =newObject.transform.localScale;
        current_Size_X= objectsize.x;
        current_Size_Z= objectsize.z;
        
    }
    
    public void export()
    {
        Debug.Log("There are "+gameObjects.Count+" elements in the list");
        
    }
    public void destroyelement()
    {
            
        Destroy(actualObject);
        gameObjects.Remove(actualObject);
        actualObject =null;
        hideelements();
    }

    public void hideelements()
    {
        element_selected.SetActive(false);
        rotation_slider.gameObject.SetActive(false);
        trigger_slider_x.gameObject.SetActive(false);
        trigger_slider_z.gameObject.SetActive(false);

        element_destroy.gameObject.SetActive(false);
    }
    public void showelements()
    {

        if(actualObject.CompareTag("door"))
        {
        }
        else if(actualObject.CompareTag("collider"))
        {
        element_selected.SetActive(true);
        trigger_slider_x.gameObject.SetActive(true);
        trigger_slider_z.gameObject.SetActive(true);
        rotation_slider.gameObject.SetActive(true);
        rt.sizeDelta = new Vector2(400,350 );
        Vector3 posImg = new Vector3(image_selected.transform.localPosition.x, -110,image_selected.transform.localPosition.z);

        image_selected.gameObject.transform.localPosition = posImg; 
        }
        else
        {
        element_selected.SetActive(true);
        element_destroy.gameObject.SetActive(true);
        rotation_slider.gameObject.SetActive(true);
        rt.sizeDelta = new Vector2(400,270 );
        Vector3 posImg = new Vector3(image_selected.transform.localPosition.x,0,image_selected.transform.localPosition.z);

        image_selected.gameObject.transform.localPosition = posImg; 

        }
    }
    public void modifyslider()
    {
        if(actualObject!=null){
        objectangles = actualObject.transform.rotation.eulerAngles;
            
        currentY =rotation_slider.value;
        
        }
    }
    public void modifyslider_z()
    {
        if(actualObject!=null){
        objectsize = actualObject.transform.localScale;
            
        current_Size_Z =trigger_slider_z.value;
        
        }
    }
    public void modifyslider_x()
    {
        if(actualObject!=null){
        objectsize = actualObject.transform.localScale;
            
        current_Size_X =trigger_slider_x.value;
        
        }
    }

}

