using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    public Vector2 position;
    public string text;
    float moveSpeed = 0.2f, disappearSpeed = 3, timer = 1;
    TextMeshPro tmp;
    Color colour;

    // Start is called before the first frame update
    void Start()
    {
        // Set the position
        transform.position = position;

        // Set the text component
        tmp = GetComponent<TextMeshPro>();
        tmp.text = text;
        colour = tmp.color;
    }

    void Update()
    {
        // Move the text up
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;

        // Fade the text out
        if(timer >= 0) timer -= Time.deltaTime;
        else
        {
            colour.a -= disappearSpeed * Time.deltaTime;
            tmp.color = colour;

            // Destroy once dissapeared
            if (colour.a < 0) Destroy(gameObject);
        }
    }
}
