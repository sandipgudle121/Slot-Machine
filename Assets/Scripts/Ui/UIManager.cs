using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private TextMeshProUGUI betText;
    [SerializeField] private TextMeshProUGUI resultText;

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
}
