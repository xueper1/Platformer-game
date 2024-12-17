using UnityEngine;
using UnityEngine.UI; // Для работы с UI
using UnityEngine.SceneManagement;
using TMPro;
public class CoinPickup : MonoBehaviour
{
    public int pickedUpCoins = 0;
    public int coinValue = 1; 
    public int requiredCoins = 10;
    public string targetSceneName = "Level2";
    private bool isPortalActivated = false; 

    public GameObject portal;
    public Text coinText; 
    public Text coinsLeftText;

    private void Start()
    {
      
        UpdateCoinText();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            pickedUpCoins += coinValue;
            Destroy(gameObject);

         
            UpdateCoinText();

           
            CheckPortalActivation();
        }
    }

    private void CheckPortalActivation()
    {
        if (!isPortalActivated && pickedUpCoins >= requiredCoins)
        {
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        isPortalActivated = true;

      
        Debug.Log("Портал активирован!");

        if (portal != null)
        {
            portal.SetActive(true);
        }
    }

    private void UpdateCoinText()
    {

        if (coinText != null)
        {
            coinText.text = "Монеты: " + pickedUpCoins;
        }


        if (coinsLeftText != null)
        {
            int coinsLeft = Mathf.Max(0, requiredCoins - pickedUpCoins);
            coinsLeftText.text = "Coins left: " + coinsLeft;
        }
    }
}
