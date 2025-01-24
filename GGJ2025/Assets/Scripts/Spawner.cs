using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _object;
    public int SpawnCountPerFrame = 1;
    public float queueTime = 1.5f;
    public bool ShouldSpawnOnUpdate;

    private float _time = 0;
    

    private void Update()
    {
        if(!ShouldSpawnOnUpdate)
            return;
        
        if (_time > queueTime)
        {
            Spawn();
            _time = 0;
        }
        _time += Time.deltaTime;
    }

    public void Spawn()
    {
        for (int i = 0; i < SpawnCountPerFrame; i++)
        { 
            Instantiate();
        }
    }
    
    public void Spawn(Vector3 position,Quaternion rotation)
    {
        for (int i = 0; i < SpawnCountPerFrame; i++)
        {
            Instantiate(position,rotation);
        }
    }

    public virtual GameObject Instantiate()
    {
        GameObject obj = Instantiate(_object);
        return obj;
    } 
    
    public virtual GameObject Instantiate(Vector3 position,Quaternion rotation)
    {
        GameObject obj = Instantiate(_object,position,rotation);
        return obj;
    } 
}