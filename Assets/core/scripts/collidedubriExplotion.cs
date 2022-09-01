using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidedubriExplotion : MonoBehaviour
{
public Animator animateelement;
public ParticleSystem particles;

private bool firsttime=true;
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
        particles.Stop();
        firsttime= true;
        //animateelement.SetBool("isFalling", false);
        }
    }
    void OnTriggerEnter()
    {
        if(particles.gameObject.activeSelf && firsttime)
        {
        foreach (Camera c in Camera.allCameras)
        {
            if ( c.gameObject.name == "2dCamera" && c.gameObject.activeSelf )
            {
            animateelement.Play("Falling");
            particles.Play();
            firsttime=false;
            break;

            }
            
        }
        }
    }
}
