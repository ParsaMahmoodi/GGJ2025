using System;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
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
    
    protected virtual void Move()
    {
        Vector3 movementOffset = ((Vector3.left * speed) * Time.deltaTime);
        transform.position += movementOffset;
    }
}
