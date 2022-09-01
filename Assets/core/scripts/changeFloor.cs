using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
public class changeFloor : MonoBehaviour
{

    public GameObject floor;
    public GameObject floor_dubri;
   
    public Material Material_Open;
    public Material Material_Close;
    
    private bool changeDoor = true;
    // Start is called before the first frame update
    void Start()
    {
        floor.SetActive(changeDoor);
        floor_dubri.SetActive(!changeDoor);
        

    }
    void OnMouseDown()
    {
        changeDoor = !changeDoor;
        floor.SetActive(changeDoor);
        floor_dubri.SetActive(!changeDoor);
        if(changeDoor){
        this.gameObject.GetComponent<MeshRenderer>().material = Material_Open;
        }
        else{
        this.gameObject.GetComponent<MeshRenderer>().material = Material_Close;
            
        }
    }
    // Update is called once per frame
    
}
