using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
public class doorOpen : MonoBehaviour
{

    public GameObject door;
    public Vector3 finalPosition;
    public Vector3 finalAngles;
    
    private Vector3 firstPosition;
    private Vector3 firstAngles;
    
    public Material Material_Open;
    public Material Material_Close;
    
    private bool changeDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        firstAngles = door.transform.eulerAngles;
        firstPosition = door.transform.position;

    }
    void OnMouseDown()
    {
        if(!changeDoor)
        {
            door.transform.localPosition = finalPosition;
            door.transform.localRotation = Quaternion.Euler(finalAngles);

            changeDoor= true;
            this.gameObject.GetComponent<MeshRenderer>().material = Material_Close;
        }
        else{
            door.transform.position= firstPosition;
            door.transform.eulerAngles = firstAngles;

            changeDoor= false;
            this.gameObject.GetComponent<MeshRenderer>().material = Material_Open;
            
        }
    }
    // Update is called once per frame
    
}
