using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    public RectTransform background1; // First background image
    public RectTransform background2; // Second background image
    public float scrollSpeed = 100f;  // Speed of scrolling (pixels per second)

    private float backgroundWidth; // Width of a single background image

    void Start()
    {
        // Get the width of the background image
        backgroundWidth = background1.rect.width;
    }

    void Update()
    {
        // Move the backgrounds to the left
        background1.anchoredPosition -= new Vector2(scrollSpeed * Time.deltaTime, 0);
        background2.anchoredPosition -= new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Reset positions if they go off-screen
        if (background1.anchoredPosition.x <= -backgroundWidth)
        {
            background1.anchoredPosition += new Vector2(backgroundWidth * 2, 0);
        }

        if (background2.anchoredPosition.x <= -backgroundWidth)
        {
            background2.anchoredPosition += new Vector2(backgroundWidth * 2, 0);
        }
    }
}