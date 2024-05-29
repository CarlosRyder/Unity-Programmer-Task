using System.Collections;
using System.Linq.Expressions;
using TMPro;
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
    public GameObject swordObject;
    public GameObject hammerObject;
    public GameObject scytheObject;
    public GameObject playerWithoutWeapons;
    public GameObject playerWithHammer;
    public GameObject playerWithSword;
    public GameObject playerWithScythe;
    public GameObject noEnoughMoney;
    public GameObject toolAlready;
    public GameObject noToolSelected;
    public GameObject toolNotOwned;



    public float displayDuration = 2f;


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
                if (selectedTool.name == "Sword") 
                {
                    swordObject.SetActive(true);
                }
                else if (selectedTool.name == "Hammer") 
                {
                    hammerObject.SetActive(true);
                }
                else if(selectedTool.name == "Scythe") 
                {
                    scytheObject.SetActive(true);
                }

            }
            else if (coinCounter.GetCoinCount() < cost)
            {
                noEnoughMoney.gameObject.SetActive(true);
                StartCoroutine(HideTextAfterDuration());
            }
            else if (toolPurchased[toolIndex])
            {
                selectedTool.GetComponent<Image>().color = Color.gray;
                toolAlready.gameObject.SetActive(true);
                StartCoroutine(HideTextAfterDuration());
            }
        }
        else
        {
            noToolSelected.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDuration());
        }
    }

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

                if (selectedTool.name == "Sword")
                {
                    swordObject.SetActive(false);
                    playerWithSword.SetActive(false);
                    playerWithoutWeapons.SetActive(true);
                }
                else if (selectedTool.name == "Hammer")
                {
                    hammerObject.SetActive(false);
                    playerWithHammer.SetActive(false);
                    playerWithoutWeapons.SetActive(true);
                }
                else if (selectedTool.name == "Scythe")
                {
                    scytheObject.SetActive(false);
                    playerWithScythe.SetActive(false);
                    playerWithoutWeapons.SetActive(true);
                }
            }
            else
            {
                toolNotOwned.gameObject.SetActive(true);
                StartCoroutine(HideTextAfterDuration());
            }
        }
        else
        {
            noToolSelected.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDuration());
        }

    }

    IEnumerator HideTextAfterDuration()
    {
        yield return new WaitForSeconds(displayDuration);
        noEnoughMoney.gameObject.SetActive(false);
        noToolSelected.gameObject.SetActive(false);
        toolAlready.gameObject.SetActive(false);
        toolNotOwned.gameObject.SetActive(false);
    }
}