using Unity.Mathematics;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public Spawner FishSpawner;
    public Health Health;
    protected override void Init()
    {
        base.Init();
        Health.OnDie += Kill;
        Health.OnDie += SpawnFish;
    }

    public void SpawnFish()
    {
        FishSpawner.Spawn(transform.position,quaternion.identity);
    }
}