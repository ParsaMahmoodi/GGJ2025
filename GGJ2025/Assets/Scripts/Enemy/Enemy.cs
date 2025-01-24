using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Enemy : MonoBehaviour
{
    protected Action OnUpdate;
    public float speed;

    private void Start()
    {
        Init();
    }
    
    private void Update()
    {
        OnUpdate?.Invoke();
    }

    protected virtual void Init()
    {
        OnUpdate += Move;
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }
    
    protected virtual void Move()
    {
        Vector3 movementOffset = ((Vector3.left * speed) * Time.deltaTime);
        transform.position += movementOffset;
    }
    
    
}