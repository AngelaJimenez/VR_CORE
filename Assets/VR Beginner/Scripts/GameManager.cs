using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool nextStep;
    public bool sonidistaBool;
    public bool startRecordingBool;
    public GameObject indicatorMicrophone;
    public GameObject microphone;
    public GameObject playerPosition;
    private bool isPlayBool;
    private bool finishGameBool;

    public GameObject key;

    public AudioSource npcConversationAudioSource;

    private float distance;

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

       // npcConversationAudioSource.Play();
        nextStep = false;
        sonidistaBool = false;
        startRecordingBool = false;
        isPlayBool = false;
        finishGameBool = false;
        UIManager.instance.instructionsText.text = "Revise su reloj para empezar la simulación";
       
    }

    // Update is called once per frame
    void Update()
    {

        
        if (startRecordingBool)
        {
            CalculateDistance();
          
        }

       


    }

    public void StartToGuion()
    {
        
        UIManager.instance.instructionsText.text = "Busque la mesa con el guion";

    }
    public void ConfirmInstructionsGuion()
    {

        UIManager.instance.instructionsText.text = "Lea las instrucciones en la pared";

    }
    public void StartToInstructions()
    {

        UIManager.instance.instructionsText.text = "Busque un lente en el cajon del escritorio y coloquelo en la camara";

    }

    public void StartSounds()
    {
       
        UIManager.instance.instructionsText.text = "Pasa la caña de 2 metros al sonidista";
        sonidistaBool = true;

    }


    public void StartRecordingScene()
    {
        sonidistaBool = false;
        UIManager.instance.instructionsText.text = "Utiliza la caña de 2 metros para la escena";
        npcConversationAudioSource.Play();
        startRecordingBool = true;


    }

    public void CalculateDistance()
    {
        distance = Vector3.Distance(indicatorMicrophone.transform.position , microphone.transform.position);
        distance = distance / 5;
       // print("Tiene una distancia de : " + distance);

        //!npcConversationAudioSource.isPlaying &
        if (Mathf.Round(npcConversationAudioSource.time) == 59f)
        {
            finishGameBool = true;

            if (finishGameBool)
            {
                UIManager.instance.instructionsText.text = "Ha finalizado la simulacion con exito :D";

                Invoke("finishGame", 4f);
            }       
        }

        if (!finishGameBool)
        {
            if (Mathf.Round(distance) < 1)
            {
                UIManager.instance.instructionsText.text = "Esta muy cerca de la toma";
                UIManager.instance.paintTheIndicator(Mathf.Round(distance));
                StopRecordingScene();
            }
            else if (distance > 0.7)
            {
                UIManager.instance.instructionsText.text = "Esta muy lejos de la escena";
                UIManager.instance.paintTheIndicator(Mathf.Round(distance));
                StopRecordingScene();
            }
            else
            {
                if (isPlayBool)
                {

                }
                UIManager.instance.instructionsText.text = "Es un buen lugar";
                UIManager.instance.paintTheIndicator(Mathf.Round(distance));

                if (!npcConversationAudioSource.isPlaying)
                    npcConversationAudioSource.Play();
            }
        }
     



    }


    public void StopRecordingScene()
    {
        npcConversationAudioSource.Pause();
    }


    public void finishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
