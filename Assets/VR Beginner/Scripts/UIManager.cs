using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Singleton 
    public static UIManager instance;

    public TMPro.TMP_Text filmScritp;
    public TMPro.TMP_Text instructionsText;
    public GameObject guion_canvas;
    public Button acceptInstructionsButton;


    public Image indicatorImage;


    private Color lerpedColor = Color.white;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //  DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClosefilmScritp()
    {
        filmScritp.gameObject.SetActive(false);
        acceptInstructionsButton.gameObject.SetActive(false);
        GameManager.instance.nextStep = true;
        GameManager.instance.StartToInstructions();
        GameManager.instance.key.SetActive(true);
    }
    public void CloseguionScritp()
    {
        
        filmScritp.gameObject.SetActive(true);
        acceptInstructionsButton.gameObject.SetActive(true);
        guion_canvas.SetActive(false);
        GameManager.instance.ConfirmInstructionsGuion();
    }

    public void paintTheIndicator(float colorLerp)
    {
        lerpedColor = Color.Lerp(Color.green,Color.red, colorLerp);
    }


}
