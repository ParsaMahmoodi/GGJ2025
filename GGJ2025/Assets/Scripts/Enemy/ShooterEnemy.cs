using UnityEngine;
using Weapon.Application;

public class ShooterEnemy : Enemy, IWeapon
{
    public Range<float> ShootRange;
    
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
        
    }

    private void ResetShootConfig()
    {
        currentSelectedTime = Random.Range(ShootRange.Min, ShootRange.Max);
        _time = 0;
    }
}