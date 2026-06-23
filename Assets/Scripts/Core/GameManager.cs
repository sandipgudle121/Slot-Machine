using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SlotMachineController slotMachineController;

    private int currentBet = 0;

    public int CurrentBet => currentBet;

    private void Start()
    {
        uiManager.UpdateBalance(currencyManager.CurrentBalance);
        uiManager.UpdateBet(currentBet);
        uiManager.UpdateResult("READY");
    }

    public void SetBet(int amount)
    {
        currentBet = amount;

        uiManager.UpdateBet(currentBet);
        uiManager.UpdateResult("READY");
    }

    public void SetBet10() => SetBet(10);

    public void SetBet50() => SetBet(50);

    public void SetBet100() => SetBet(100);

    public void Spin()
    {
        // No bet selected
        if (currentBet <= 0)
        {
            uiManager.UpdateResult("SELECT BET");
            return;
        }

        // Not enough balance
        if (!currencyManager.Spend(currentBet))
        {
            uiManager.UpdateResult("NOT ENOUGH BALANCE");
            return;
        }

        // Update balance after spending
        uiManager.UpdateBalance(currencyManager.CurrentBalance);

        // Generate random symbols
        SymbolData symbol1 = slotMachineController.Spin();
        SymbolData symbol2 = slotMachineController.Spin();
        SymbolData symbol3 = slotMachineController.Spin();

        // Show them
        slotMachineController.SetCenterSymbols(symbol1, symbol2, symbol3);

        // Check win
        if (symbol1 == symbol2 && symbol2 == symbol3)
        {
            int reward = currentBet * symbol1.payoutMultiplier;

            currencyManager.Add(reward);

            uiManager.UpdateBalance(currencyManager.CurrentBalance);

            uiManager.UpdateResult(
                $"YOU WIN! +{reward}"
            );
        }
        else
        {
            uiManager.UpdateResult("TRY AGAIN");
        }
    }
}
