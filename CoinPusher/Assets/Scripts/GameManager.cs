using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public int startingCoins = 10;
    public int coinsPerDrop = 1;

    [Header("UI References")]
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI scoreText;

    private int currentCoins;
    private int score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentCoins = startingCoins;
        score = 0;
        UpdateUI();
    }

    public bool CanDropCoin()
    {
        return currentCoins >= coinsPerDrop;
    }

    public void OnCoinDropped()
    {
        currentCoins -= coinsPerDrop;
        UpdateUI();
    }

    public void CollectCoin(GameObject coin)
    {
        Coin coinComponent = coin.GetComponent<Coin>();
        score += coinComponent.value;
        currentCoins += coinComponent.value;

        // Visual/Audio feedback here
        Destroy(coin);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinCountText) coinCountText.text = "Coins: " + currentCoins;
        if (scoreText) scoreText.text = "Score: " + score;
    }
}