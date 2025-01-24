using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Action OnUpdate;
    public float speed;
    public bool shouldMove = true;

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
        if (shouldMove)
        {
            Vector3 movementOffset = ((Vector3.left * speed) * Time.deltaTime);
            transform.position += movementOffset;
        }
    }


}