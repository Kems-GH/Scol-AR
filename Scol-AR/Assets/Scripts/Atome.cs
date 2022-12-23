using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atome : MonoBehaviour
{
    public GameObject prefabElectron;
    public int nbElectrons;

    private GameObject[] electrons;
    public Text debugText;
    
    // Start is called before the first frame update
    void Start()
    {
        electrons = new GameObject[nbElectrons];
        for (int i = 0; i < nbElectrons; i++)
        {
            float x = Mathf.Cos(i * 2 * Mathf.PI / nbElectrons) * 0.05f;
            float z = Mathf.Sin(i * 2 * Mathf.PI / nbElectrons) * 0.05f;

            electrons[i] = GameObject.Instantiate(prefabElectron);
            electrons[i].transform.position = transform.position + new Vector3(x, 0, z );
            electrons[i].transform.parent = transform;
        }
        debugText.text = "electron count: " + electrons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // if(nbElectrons != electrons.Length)
        // {
        //     electrons = new GameObject[nbElectrons];
        //     for(int i = 0; i < nbElectrons; i++)
        //     {
        //         electrons[i] = prefabElectron;
        //         electrons[i].transform.position = new Vector3(0.05f, 0.05f, 0.05f);
        //         electrons[i].transform.parent = transform;
        //     }
        // }
    }
}
