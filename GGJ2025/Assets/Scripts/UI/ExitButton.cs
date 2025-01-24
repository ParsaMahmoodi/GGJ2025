using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
