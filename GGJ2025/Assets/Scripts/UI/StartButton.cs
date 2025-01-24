using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartScene);
    }

    private void StartScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
