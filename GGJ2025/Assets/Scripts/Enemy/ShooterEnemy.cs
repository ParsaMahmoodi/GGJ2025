using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Weapon.Application;
using Random = UnityEngine.Random;

public class ShooterEnemy : Enemy, IWeapon
{
    public Range<float> ShootRange;
    public Spawner BulletSpawner;
    
    private float _time = 0;
    private float currentSelectedTime = 0;

    protected override void Init()
    {
        base.Init();
        OnUpdate += ReadyToFire;
    }

    public void ReadyToFire()
    {
        if (_time > currentSelectedTime)
        {
            Shoot();
            ResetShootConfig();
        }
        _time += Time.deltaTime;
    }
    
    public void Shoot()
    {
        BulletSpawner.Spawn(transform.position,quaternion.identity);
    }

    private void ResetShootConfig()
    {
        currentSelectedTime = Random.Range(ShootRange.Min, ShootRange.Max);
        _time = 0;
    }
}