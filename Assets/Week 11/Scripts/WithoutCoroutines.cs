using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithoutCoroutines : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5, turningSpeedReduction = 0.75f;
    float interpolation, time, legLength;
    Quaternion currentHeading;
    Quaternion newHeading;
    bool turn = false, straight = false;

    // Update is called once per frame
    void Update()
    {
        if(turn)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
            if (interpolation > 1) turn = false;
        }

        if(straight)
        {
            time += Time.deltaTime;
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
            if (time > legLength) straight = false;
        }
    }

    public void Turn(float angle)
    {
        interpolation = 0;
        currentHeading = missile.transform.rotation;
        newHeading = currentHeading * Quaternion.Euler(0, 0, angle);
        turn = true;
    }

    public void Straight(float length)
    {
        time = 0;
        legLength = length;
        straight = true;
    }
}
