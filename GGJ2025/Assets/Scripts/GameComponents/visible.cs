using System;
using System.Collections.Generic;
using UnityEngine;

public class visible : MonoBehaviour
{
    private bool IsVisibleLater;

    private void OnBecameInvisible()
    {
        if (IsVisibleLater)
            Deactivate();
    }

    private void OnBecameVisible()
    {
        IsVisibleLater = true;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}