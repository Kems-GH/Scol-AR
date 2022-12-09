using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public GameObject Core;
    public GameObject Electrons;
    public GameObject ButtonDestroy;
    private Vector3 scaleChange;

    void Start()
    {
        Electrons.SetActive(true);
        ButtonDestroy.SetActive(false);
    }
    public void Zooming()
    {
        scaleChange = new Vector3(+0.0005f, +0.0005f, +0.0005f);
        Electrons.SetActive(false);
        ButtonDestroy.SetActive(true);
    }

    void Update()
    {
       
        if(Core.transform.localScale.y < 0.07f)
        {
            Core.transform.localScale += scaleChange;
            
        }
        else Core.transform.localScale -= scaleChange;
    }
}
