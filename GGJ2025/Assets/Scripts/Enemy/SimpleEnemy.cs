using Unity.Mathematics;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public Spawner FishSpawner;
    public Health Health;

    private string FishSpawnerTag = "FishSpawner";
   
    
    protected override void Init()
    {
        base.Init();
        FishSpawner = GameObject.FindGameObjectWithTag(FishSpawnerTag).GetComponent<Spawner>();
        Health.OnDie += Kill;
        Health.OnDie += SpawnFish;
    }

    public void SpawnFish()
    {
        FishSpawner.Spawn(transform.position,quaternion.identity);
    }
}