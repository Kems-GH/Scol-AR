using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementElectron : MonoBehaviour
{
    private GameObject[] electrons;
    private float speed = 0.1f;
    private float[] x;
    private float[] y;
    private float[] z;

    private void Start()
    {
        this.Init();
    }

    void UpdatePosElectrons()
    {
        int nbElectrons = electrons.Length;
        Vector3 new_pos = Vector3.zero;
        for (int i = 0; i < nbElectrons; i++)
        {
            new_pos = transform.position + new Vector3(this.x[i], this.y[i], this.z[i]);
            this.electrons[i].transform.position = Vector3.MoveTowards(this.electrons[i].transform.position, new_pos, speed * Time.deltaTime);
        }
    }

    public void Init()
    {
        if(electrons.Length != 0)
        {
            Array.Clear(electrons, 0, electrons.Length);
        }
        electrons = GameObject.FindGameObjectsWithTag("Electron");
        InvokeRepeating(nameof(ChangePos), 0.1f, 0.8f);
        InvokeRepeating(nameof(UpdatePosElectrons), 0.11f, Time.deltaTime);
        x = new float[electrons.Length];
        y = new float[electrons.Length];
        z = new float[electrons.Length];
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
            radius = level * 0.1f;
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
