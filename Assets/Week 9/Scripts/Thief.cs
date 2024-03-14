using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1, spawnPoint2;
    public float attack1Delay = 0.09f, attack2Delay = 0.22f, dashSpeed = 5, dashLength = 1f;

    protected override void Attack()
    {
        speed = dashSpeed;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Attack();
        // You would probably just want to use coroutines here so you can pass in arguments instead of creating 2 methods
        // However I don't know if I'm allowed to use coroutines so I'm not gonna do that lol
        Invoke("SpawnDagger1", attack1Delay);
        Invoke("SpawnDagger2", attack2Delay);
        Invoke("EndDash", dashLength);
    }

    void SpawnDagger1()
    {
        Instantiate(dagger, spawnPoint1.position, spawnPoint1.rotation);
    }

    void SpawnDagger2()
    {
        Instantiate(dagger, spawnPoint2.position, spawnPoint2.rotation);
    }

    void EndDash()
    {
        speed = 3;
        destination = transform.position;
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
