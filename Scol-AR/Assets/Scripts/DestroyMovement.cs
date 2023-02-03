using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMovement : MonoBehaviour
{
    int Number = 0;
    public GameObject SphereObject1;
    public GameObject SphereObject2;
    public GameObject SphereObject3;
    public GameObject SphereObject4;
    public GameObject Core1;
    public GameObject Core2;
    public GameObject Core3;
    public GameObject Core4;
    public GameObject Particle1;
    public GameObject Particle2;
    public GameObject Particle3;
    public GameObject Particle4;
    public GameObject ReturnButton;

    private void Start()
    {
        SphereObject1.SetActive(false);
        SphereObject2.SetActive(false);
        SphereObject3.SetActive(false);
        SphereObject4.SetActive(false);
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(false);

    }

    public void Button()
    {
        Number = Number + 1;
    }

    float timer1 = 0.0f;
    float timer2 = 0.0f;
    float timer3 = 0.0f;
    float timer4 = 0.0f;
    float degreesPerSecond = 40;

    void Update()
    {

        if (Number > 0)
        {
            timer1 += Time.deltaTime;
            float seconds = timer1 % 60;

            SphereObject1.SetActive(true);
            SphereObject1.transform.position += Vector3.left * 3 * Time.deltaTime;
            SphereObject1.transform.position += Vector3.down * 3 * Time.deltaTime;

            if (seconds > 0.40)
            {
                if (seconds < 0.52)
                {
                    transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
                }
            }


        }
        if (Number > 1)
        {
            timer2 += Time.deltaTime;
            float seconds = timer2 % 60;

            SphereObject2.SetActive(true);
            SphereObject2.transform.position += Vector3.right * 3 * Time.deltaTime;
            SphereObject2.transform.position += Vector3.down * 3 * Time.deltaTime;

            if (seconds > 0.40)
            {
                if (seconds < 0.52)
                {
                    transform.Rotate(new Vector3(degreesPerSecond, 0, 0) * Time.deltaTime);
                }
            }
        }
        if (Number > 2)
        {
            timer3 += Time.deltaTime;
            float seconds = timer3 % 60;

            SphereObject3.SetActive(true);
            SphereObject3.transform.position += Vector3.right * 3 * Time.deltaTime;
            SphereObject3.transform.position += Vector3.up * 3 * Time.deltaTime;

            if (seconds > 0.40)
            {
                if (seconds < 0.52)
                {
                    transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
                }
            }


        }
        if (Number > 3)
        {
            timer4 += Time.deltaTime;
            float seconds = timer4 % 60;

            SphereObject4.SetActive(true);
            SphereObject4.transform.position += Vector3.left * 3 * Time.deltaTime;
            SphereObject4.transform.position += Vector3.up * 3 * Time.deltaTime;
            ReturnButton.SetActive(true);

            if (seconds > 0.40)
            {
                if (seconds < 0.47)
                {
                    Core1.transform.position += Vector3.left * Time.deltaTime;
                    Core2.transform.position += Vector3.right * Time.deltaTime;
                    Particle1.SetActive(true);
                    Particle4.SetActive(true);
                }
            }
        }


    }

}
