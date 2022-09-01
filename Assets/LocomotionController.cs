using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController lefttp;
    public InputHelpers.Button teleportactivationbutton;
    public float activationthreshot = 0.1f;
    public GameObject reticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool checkActive(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportactivationbutton, out bool isActivated, activationthreshot);
        return isActivated;
    }
    // Update is called once per frame
    void Update()
    {
        if(lefttp){
            lefttp.gameObject.SetActive(checkActive(lefttp));
            reticle.SetActive(checkActive(lefttp));
        }
    }
}
