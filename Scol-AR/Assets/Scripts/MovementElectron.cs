using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovementElectron : MonoBehaviour
{
    private GameObject[] electrons;
    private float speed = 0.1f;
    private float[] x;
    private float[] y;
    private float[] z;

    private void Start()
    {
        electrons = GameObject.FindGameObjectsWithTag("Electron");
        InvokeRepeating("ChangePos", 0.1f, 0.8f);
        x = new float[electrons.Length];
        y = new float[electrons.Length];
        z = new float[electrons.Length];
    }

    void Update()
    {
        int nbElectrons = electrons.Length;
        for (int i = 0; i < nbElectrons; i++)
        {
            this.electrons[i].transform.position = Vector3.MoveTowards(this.electrons[i].transform.position, new Vector3(this.x[i], this.y[i], this.z[i]), speed * Time.deltaTime);
        }
    }

    void ChangePos()
    {
        int nbElectrons = electrons.Length;
        int level = 1;
        int j = 0;
        float radius;
        for (int i = 0; i < nbElectrons; i++)
        {
            int nbElectronsInLevel = (int)(2 * Mathf.Pow(level, 2));
            radius = (0.02f + (level * 0.03f));
            int theta = Mathf.RoundToInt(Random.Range(0f, 360f));
            int phi = Mathf.RoundToInt(Random.Range(0f, 360f));

            this.x[i] = (float)radius * Mathf.Cos(theta) * Mathf.Sin(ConvertToRadian(phi));
            this.y[i] = (float)radius * Mathf.Sin(theta) * Mathf.Sin(ConvertToRadian(phi));
            this.z[i] = (float) radius * Mathf.Cos(ConvertToRadian(phi));

            j++;
            if (j >= nbElectronsInLevel)
            {
                j = 0;
                level++;
            }
        }
    }

    float ConvertToRadian(int degree)
    {
        return (float) (degree * Mathf.PI / 180);
    }
}
