using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject uiPanel;
    public GameObject allShopPanel;

    private void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("UI Panel is not assigned in the Inspector");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiPanel != null)
            {
                uiPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
                allShopPanel.SetActive(false);
            }
        }
    }
}