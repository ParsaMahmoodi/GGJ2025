using System;
using System.Collections;
using Weapon.Main.Bubble;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _object;
    public int SpawnCountPerFrame = 1;
    public int InitialSize = 10;
    public float queueTime = 1.5f;
    public bool ShouldSpawnOnUpdate;
    
    private ObjectPool _pool;
    private float _time = 0;

    private void Start()
    {
        int initialSize = InitialSize * SpawnCountPerFrame;
        _pool = new ObjectPool(_object,initialSize);
    }

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
        GameObject obj = _pool.GetObject();
        obj.SetActive(true);
        return obj;
    } 
    
    public virtual GameObject Instantiate(Vector3 position,Quaternion rotation)
    {
        GameObject obj = Instantiate();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public void StopAllSpawns()
    {
        foreach (var s in _pool.GetSpawns())
        {
            s.gameObject.SetActive(false);
        }
    }
}