using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
public class changeExplotion : MonoBehaviour
{

    
    public GameObject explotion;
   
    public Material Material_active;
    public Material Material_desactive;
    
    private bool changeDoor = true;
    // Start is called before the first frame update
    void Start()
    {
        explotion.SetActive(changeDoor);
        

    }
    void OnMouseDown()
    {
        changeDoor = !changeDoor;
        explotion.SetActive(changeDoor);
        if(changeDoor){
        this.gameObject.GetComponent<MeshRenderer>().material = Material_active;
        }
        else{
        this.gameObject.GetComponent<MeshRenderer>().material = Material_desactive;
            
        }
    }
    // Update is called once per frame
    
}
