using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private TextMeshProUGUI betText;
    [SerializeField] private TextMeshProUGUI resultText;

    [Header("Win Popup")]
    [SerializeField] private GameObject winPopup;
    [SerializeField] private TextMeshProUGUI winPopupText;

    [Header("Result Colors")]
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color winColor = Color.yellow;
    [SerializeField] private Color errorColor = Color.red;

    private void Start()
    {
        winPopup.SetActive(false);
    }

    public void UpdateBalance(int balance)
    {
        balanceText.text = $"Balance : {balance}";
    }

    public void UpdateBet(int bet)
    {
        betText.text = $"Bet : {bet}";
    }

    public void UpdateResult(string message)
    {
        resultText.text = message;
    }

    public void ShowWinPopup(int reward)
    {
        winPopup.SetActive(true);
        winPopupText.text = $"YOU WIN!\n+{reward}";
    }

    public void HideWinPopup()
    {
        winPopup.SetActive(false);
    }

    public void ShowWinMessage(string message)
    {
        resultText.color = winColor;
        resultText.text = message;
    }

    public void ShowErrorMessage(string message)
    {
        resultText.color = errorColor;
        resultText.text = message;
    }

    public void ShowNormalMessage(string message)
    {
        resultText.color = normalColor;
        resultText.text = message;
    }
}
