using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] toolButtons;
    public int[] toolCosts;
    private CoinCounter coinCounter;
    private Color selectedColor = new Color(82f / 255f, 145f / 255f, 203f / 255f); // Color 5291CB
    private GameObject selectedTool = null;
    private bool[] toolPurchased; 

    private void Start()
    {
        coinCounter = GameObject.FindObjectOfType<CoinCounter>();
        toolPurchased = new bool[toolButtons.Length]; 
    }

    void Update()
    {
        if (coinCounter != null)
        {
            int coinCount = coinCounter.GetCoinCount();
        }
        else
        {
            Debug.LogWarning("CoinCounter not found. Be sure it exists in the scene.");
        }
    }

    // Method to select a tool
    public void SelectTool(GameObject button)
    {
        if (selectedTool != null)
        {
            selectedTool.GetComponent<Image>().color = selectedColor;
        }

        if (selectedTool == button)
        {
            selectedTool = null;
            return;
        }

        button.GetComponent<Image>().color = Color.green;
        selectedTool = button;
    }

    // Method to buy a tool
    public void BuyTool()
    {
        if (selectedTool != null)
        {
            int toolIndex = System.Array.IndexOf(toolButtons, selectedTool);
            int cost = toolCosts[toolIndex];

            if (coinCounter.GetCoinCount() >= cost && !toolPurchased[toolIndex])
            {
                coinCounter.RemoveCoins(cost);
                toolPurchased[toolIndex] = true;
                Debug.Log("Tool purchased: " + selectedTool.name);
            }
            else if (coinCounter.GetCoinCount() < cost)
            {
                Debug.Log("Not enough coins to purchase this tool.");
            }
            else if (toolPurchased[toolIndex])
            {
                Debug.Log("This tool is already purchased.");
                selectedTool.GetComponent<Image>().color = Color.gray;

            }
        }
        else
        {
            Debug.Log("No tool selected.");
        }
    }

    // Method to sell a tool
    public void SellTool()
    {
        if (selectedTool != null)
        {
            int toolIndex = System.Array.IndexOf(toolButtons, selectedTool);
            int sellPrice = toolCosts[toolIndex];

            if (toolPurchased[toolIndex])
            {
                coinCounter.AddCoins(sellPrice);
                toolPurchased[toolIndex] = false;
                Debug.Log("Tool sold: " + selectedTool.name);
            }
            else
            {
                Debug.Log("This tool is not owned.");
            }
        }
        else
        {
            Debug.Log("No tool selected.");
        }
    }
}