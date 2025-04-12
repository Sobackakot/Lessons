using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        Invoke(nameof(Spawn), 10);
    }

    private void Spawn()
    {
        Instantiate(Enemy, transform);
        Invoke(nameof(Spawn), 10);
    }
}
