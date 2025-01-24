using Unity.Mathematics;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    private Spawner FishSpawner;
    private Health Health;

    private string FishSpawnerTag = "FishSpawner";


    protected override void Init()
    {
        base.Init();
        Health = GetComponent<Health>();
        FishSpawner = GameObject.FindGameObjectWithTag(FishSpawnerTag).GetComponent<Spawner>();
        Health.OnDie += Kill;
        Health.OnDie += SpawnFish;
    }

    public void SpawnFish()
    {
        Debug.Log("Spawn Fish");
        FishSpawner.Spawn(transform.position, quaternion.identity);
    }
}