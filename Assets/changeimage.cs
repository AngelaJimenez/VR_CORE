using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeimage : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeimages(Sprite newSprite)
    {
        img.sprite=newSprite;
    }


}
