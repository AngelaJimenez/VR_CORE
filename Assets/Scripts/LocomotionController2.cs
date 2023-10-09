using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController2 : MonoBehaviour
{
    public XRController lefttp;
    public InputHelpers.Button teleportactivationbutton;
    public float activationthreshot = 0.1f;
    public GameObject reticle;
    
    private GameObject reticleScene;
    public XRInteractorLineVisual XRInteractorLineVisual;

    // Start is called before the first frame update
    void Start()
    {
        reticleScene= Instantiate(reticle);
        XRInteractorLineVisual.reticle=reticleScene;

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
            reticleScene.SetActive(checkActive(lefttp));
        }
    }
}
