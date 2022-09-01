using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicExample : MonoBehaviour
{
    public PlayableDirector lamp_playable;
    public AlembicStreamPlayer lamp_alembic;
    private bool stop= false;
    private bool control= true;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnEnable()
    {
        lamp_playable.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (lamp_playable == aDirector && stop)
        {
           stop=true;
        }
            
    }
    // Update is called once per frame
    void Update()
    {
    foreach (Camera c in Camera.allCameras)
        {
        if ( c.gameObject.name == "Main Camera" && c.gameObject.activeSelf)
            {
            control = true;
            lamp_alembic.UpdateImmediately(0.0f);
            }
        }
    }
    void OnTriggerEnter()
    {
        foreach (Camera c in Camera.allCameras)
        {
            if ( c.gameObject.name == "2dCamera" && c.gameObject.activeSelf && control)
            {
            lamp_playable.Play();
            control = false;

            }
            
        }
    }
}
