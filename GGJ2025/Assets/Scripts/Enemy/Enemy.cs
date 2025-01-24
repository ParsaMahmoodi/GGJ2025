using System;
using UnityEngine;

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

    public virtual void Kill()
    {
        gameObject.SetActive(false);
    }
    
    protected virtual void Move()
    {
        Vector3 movementOffset = ((Vector3.left * speed) * Time.deltaTime);
        transform.position += movementOffset;
    }
    
    
}