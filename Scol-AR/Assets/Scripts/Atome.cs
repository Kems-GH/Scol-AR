using UnityEngine;
using UnityEngine.UI;

public class Atome : MonoBehaviour
{
    public GameObject prefabElectron;
    public int nbElectrons;

    private GameObject[] electrons;
    public Text debugText;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        electrons = new GameObject[nbElectrons];
        int y = 0;
        level = 1;
        for (int i = 0; i < nbElectrons; i++)
        {
            int nbElectronsInLevel = (int)(2 * Mathf.Pow(level, 2));

            float x = Mathf.Cos(y * 2 * Mathf.PI / nbElectronsInLevel) * (0.02f+(level * 0.03f));
            float z = Mathf.Sin(y * 2 * Mathf.PI / nbElectronsInLevel) * (0.02f+(level * 0.03f));

            electrons[i] = GameObject.Instantiate(prefabElectron);
            electrons[i].transform.position = transform.position + new Vector3(x, 0, z);
            electrons[i].transform.parent = transform;

            y++;

            if (y >= nbElectronsInLevel)
            {
                y = 0;
                level++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
