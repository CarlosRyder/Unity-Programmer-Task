using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text coinText;
    private int coinCount = 0;

    private void Start()
    {
        UpdateCoinText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount += 20;
            UpdateCoinText();
            Destroy(other.gameObject); 
        }
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }
    }
    public int GetCoinCount()
    {
        return coinCount;
    }

    private void Update()
    {
        UpdateCoinText(); 
    }
    public void RemoveCoins(int amount)
    {
        coinCount -= amount;
        UpdateCoinText();
    }
    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
    }
}
