using Unity.Mathematics;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public Spawner FishSpawner;
    
    public override void Kill()
    {
        base.Kill();
        FishSpawner.Spawn(transform.position,quaternion.identity);
    }
}