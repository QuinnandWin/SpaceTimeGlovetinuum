using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public static int coins=0;        // The player's coins.
    public static int superCoins=0;        // The player's coins.

    public bool removeCoins = true;

    Text coinText;                      // Reference to the Text component.
    [SerializeField]
    private bool coinUI = false;
    [SerializeField]
    private bool superCoinUI = false;
    private int previousCoinCount;
    private int previousSuperCoinCount;
    private AudioSource coinPickup;
    [SerializeField]
    private AudioClip coinsComplete;



    void Awake()
    {
        // Set up the reference.
        coinText = GetComponent<Text>();
        coinPickup = GetComponent<AudioSource>();


        if (removeCoins == true)
        {
            // Reset the score.
            coins = 0;
            superCoins = 0;
        }
    }

    void Update()
    {
        if (coinUI)
        {
            if (coins == 0)
            {
                // Set the displayed text to be the word "Score" followed by the score value.
                coinText.text = "Coins 000 / 100";
            }
            else if (coins < 10)
            {
                // Set the displayed text to be the word "Score" followed by the score value.
                coinText.text = "Coins 00" + coins + " / 100";
            }
            else if (coins < 100)
            {
                // Set the displayed text to be the word "Score" followed by the score value.
                coinText.text = "Coins 0" + coins + " / 100";
            }
            else if (coins > 100)
            {
                // Set the displayed text to be the word "Score" followed by the score value.
                coinText.text = "Coins" + coins + " / 100";
                coinText.color = Color.green;
            }
            if (coins > previousCoinCount)
            {
                if (coins == 100)
                {
                    coinPickup.PlayOneShot(coinsComplete, 1.0F);
                }
                else
                {
                    coinPickup.Play();
                }
                previousCoinCount = coins;
            }
        }
        else if (superCoins > previousSuperCoinCount)
        {
            coinPickup.Play();
            previousSuperCoinCount = superCoins;
            Invoke("UpdateUI", 1.0f);
        }
    }

    void UpdateUI()
    {
        if (superCoinUI)
        {
            coinText.text = "SuperCoins " + superCoins + " / 4";
        }
    }
}
