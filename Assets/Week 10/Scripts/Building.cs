using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject[] sprites = new GameObject[5];
    int current = 0;
    float interpolation = 0;
    Vector3 end = new Vector3(1.3f, 1.3f, 1);
    Coroutine build;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < sprites.Length; i++)
        {
            sprites[i].SetActive(false);
        }

        build = StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        while (interpolation <= 1)
        {
            sprites[current].transform.localScale = Vector3.Lerp(Vector3.one, end, interpolation);
            interpolation += 0.1f;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        if (current < sprites.Length - 1)
        {
            sprites[current].SetActive(false);
            sprites[current + 1].SetActive(true);
            current++;
            interpolation = 0;
            build = StartCoroutine(Build());
        }
        else StopCoroutine(build);
    }
}
