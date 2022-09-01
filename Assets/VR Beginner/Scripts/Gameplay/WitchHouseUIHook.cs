using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This will be picked up automatically by the wrist watch when it get spawn in the scene by the Interaction toolkit
/// and setup the buttons and the linked events on the canvas
/// </summary>
public class WitchHouseUIHook : WatchScript.IUIHook
{
    public GameObject LeftUILineRenderer;
    public GameObject RightUILineRenderer;
    

    public override void GetHook(WatchScript watch)
    {
        watch.AddButton("Reset", () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        watch.AddButton("Unlock Teleporters", () => {MasterController.Instance.TeleporterParent.SetActive(true);});
        watch.AddButton("start simulation", () => {UIManager.instance.guion_canvas.gameObject.SetActive(true); GameManager.instance.StartToGuion(); });
        watch.AddButton("open prefabs list", () => {displayList(watch); });

        // watch.AddToggle("Closed Caption", (state) => { CCManager.Instance.gameObject.SetActive(state); });

       // LeftUILineRenderer.SetActive(false);
       // RightUILineRenderer.SetActive(false);

        watch.UILineRenderer = LeftUILineRenderer;
    }
    public void displayList(WatchScript watch)
    {
        watch.AddButton2("extinguisher", () => {});
        watch.AddButton2("fire", () => { });
        
        

    }
}
