using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner
{
    public float height;

    public override GameObject Instantiate()
    {
        GameObject go = base.Instantiate();
        go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        return go;
    }
}
