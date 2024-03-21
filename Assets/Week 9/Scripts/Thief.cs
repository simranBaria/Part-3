using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1, spawnPoint2;
    public float attack1Delay = 0.09f, attack2Delay = 0.22f;
    float dashSpeed = 7;
    Coroutine dashing;

    protected override void Attack()
    {
        if(dashing != null) StopCoroutine(dashing);

        dashing = StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = dashSpeed;

        while(speed > 3)
        {
            yield return null;
        }

        base.Attack();

        yield return new WaitForSeconds(attack1Delay);
        Instantiate(dagger, spawnPoint1.position, spawnPoint1.rotation);

        yield return new WaitForSeconds(attack2Delay);
        Instantiate(dagger, spawnPoint2.position, spawnPoint2.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    public override string ToString()
    {
        return "ur gay";
    }
}
