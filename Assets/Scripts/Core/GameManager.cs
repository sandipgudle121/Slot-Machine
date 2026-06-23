using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SlotMachineController slotMachineController;

    [SerializeField] private ReelController reel1;
    [SerializeField] private ReelController reel2;
    [SerializeField] private ReelController reel3;

    private bool isSpinning = false;
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
        if (isSpinning)
            return;

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;

        // Validation
        if (currentBet <= 0)
        {
            uiManager.UpdateResult("SELECT BET");
            isSpinning = false;
            yield break;
        }

        if (!currencyManager.Spend(currentBet))
        {
            uiManager.UpdateResult("NOT ENOUGH BALANCE");
            isSpinning = false;
            yield break;
        }

        uiManager.UpdateBalance(currencyManager.CurrentBalance);

        // Start spinning
        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        // Let all reels spin together
        yield return new WaitForSeconds(0.8f);

        // Stop Reel 1
        reel1.StopSpin();
        reel1.AlignReel();

        yield return new WaitForSeconds(0.3f);

        // Stop Reel 2
        reel2.StopSpin();
        reel2.AlignReel();

        yield return new WaitForSeconds(0.3f);

        // Stop Reel 3  
        reel3.StopSpin();
        reel3.AlignReel();

        SymbolData symbol1 = reel1.GetCenterSymbol();
        SymbolData symbol2 = reel2.GetCenterSymbol();
        SymbolData symbol3 = reel3.GetCenterSymbol();

        Debug.Log(
                    $"Center Symbols: " +
                    $"{symbol1.symbolName}, " +
                    $"{symbol2.symbolName}, " +
                    $"{symbol3.symbolName}");

        // Win check
        if (symbol1 == symbol2 && symbol2 == symbol3)
        {
            int reward = currentBet * symbol1.payoutMultiplier;

            currencyManager.Add(reward);

            uiManager.UpdateBalance(currencyManager.CurrentBalance);

            uiManager.UpdateResult($"YOU WIN! +{reward}");
        }
        else
        {
            uiManager.UpdateResult("TRY AGAIN");
        }

        isSpinning = false;
    }
}
