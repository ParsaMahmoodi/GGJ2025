using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR;

public class ButtonAnimation : MonoBehaviour
{
    public float DelayTime = 3f;
    public float ScaleDuration = 0.1f;
    public float additionalSize = 0.1f;
    
    private float firstSize = 0.5f;
    private Vector3 additionalScale;
    private void Awake()
    {
        transform.localScale = new Vector3(firstSize,firstSize,firstSize);
        additionalScale = new Vector3(additionalSize, additionalSize, additionalSize);
        additionalScale += Vector3.one;
    }

    private void OnEnable()
    {
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(AnimateButton());
    }

    private IEnumerator AnimateButton()
    {
        while (true)
        {
            transform.DOScale(additionalScale, ScaleDuration).SetEase(Ease.InOutBack).OnComplete( () =>
            {
                transform.DOScale(Vector3.one, ScaleDuration);
            });
            yield return new WaitForSeconds(DelayTime);
        }
    }
    
    
}
