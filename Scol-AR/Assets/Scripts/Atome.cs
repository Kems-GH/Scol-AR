using UnityEngine;
using UnityEngine.UI;

public class Atome : MonoBehaviour
{
    public GameObject prefabElectron;

    private GameObject[] electrons;
    private int level;
    public void CreateElectrons(int nbElectrons)
    {
        electrons = new GameObject[nbElectrons];
        int y = 0;
        level = 1;
        for (int i = 0; i < nbElectrons; i++)
        {
            int nbElectronsInLevel = (int)(2 * Mathf.Pow(level, 2));

            float x = Mathf.Cos(y * 2 * Mathf.PI / nbElectronsInLevel) * (0.02f + (level * 0.03f));
            float z = Mathf.Sin(y * 2 * Mathf.PI / nbElectronsInLevel) * (0.02f + (level * 0.03f));

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
        this.UpdateTextNbElectron(nbElectrons);
    }

    private void DestroyElectrons()
    {
        for (int i=0; i<electrons.Length; i++)
        {
            Destroy(electrons[i]);
        }
    }

    public void UpdateElectrons(int nbElectrons)
    {
        this.DestroyElectrons();
        this.CreateElectrons(nbElectrons);
    }

    public int GetNbElectrons()
    {
        return this.electrons.Length;
    }

    public void UpdateTextNbElectron(int nbElectron)
    {
        GameObject go = GameObject.FindWithTag("NB electron");
        TextMesh textMesh = go.GetComponent<TextMesh>();

        textMesh.text = nbElectron.ToString();
    }
}
