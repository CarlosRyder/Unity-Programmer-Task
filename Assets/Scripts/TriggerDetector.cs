using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject uiPanel;

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
               // Debug.Log("Trigger Entered by: " + other.gameObject.name);
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
                //Debug.Log("Trigger Exited by: " + other.gameObject.name);
            }
        }
    }
}
