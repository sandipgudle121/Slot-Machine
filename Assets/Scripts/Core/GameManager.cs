using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private UIManager uiManager;

    [SerializeField] private ReelController reel1;
    [SerializeField] private ReelController reel2;
    [SerializeField] private ReelController reel3;

    [SerializeField] private LeverController leverController;
    [SerializeField] private AudioManager audioManager;

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
        uiManager.ShowNormalMessage("READY");
    }

    public void SetBet10()
    {
        audioManager.PlayButtonClick();
        SetBet(10);
    }

    public void SetBet50()
    {
        audioManager.PlayButtonClick();
        SetBet(50);
    }

    public void SetBet100()
    {
        audioManager.PlayButtonClick();
        SetBet(100);
    }

    public void Spin()
    {
        audioManager.PlayButtonClick();
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
            uiManager.ShowErrorMessage("SELECT BET");
            isSpinning = false;
            yield break;
        }

        if (!currencyManager.Spend(currentBet))
        {
            uiManager.ShowErrorMessage("NOT ENOUGH BALANCE");
            isSpinning = false;
            yield break;
        }

        uiManager.UpdateBalance(currencyManager.CurrentBalance);

        // Pull lever first
        yield return StartCoroutine(leverController.PullLever());

        // Start spinning
        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        audioManager.PlayReelSpin();

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

        audioManager.StopReelSpin();

        SymbolData symbol1 = reel1.GetCenterSymbol();
        SymbolData symbol2 = reel2.GetCenterSymbol();
        SymbolData symbol3 = reel3.GetCenterSymbol();

        // Win check
        if (symbol1 == symbol2 && symbol2 == symbol3)
        {
            int reward = currentBet * symbol1.payoutMultiplier;

            if (symbol1 == null || symbol2 == null || symbol3 == null)
            {
                uiManager.ShowErrorMessage("SYMBOL ERROR");
                isSpinning = false;
                yield break;
            }

            currencyManager.Add(reward);

            uiManager.UpdateBalance(currencyManager.CurrentBalance);

            audioManager.PlayWin();

            StartCoroutine(reel1.GetCenterSymbolController().Pulse());
            StartCoroutine(reel2.GetCenterSymbolController().Pulse());
            StartCoroutine(reel3.GetCenterSymbolController().Pulse());

            uiManager.ShowWinPopup(reward);

            uiManager.ShowWinMessage($"YOU WIN! +{reward}");

            yield return new WaitForSeconds(2f);

            uiManager.HideWinPopup();
        }
        else
        {
            uiManager.ShowNormalMessage("TRY AGAIN");
        }

        isSpinning = false;
    }
}
