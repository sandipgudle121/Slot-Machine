using UnityEngine;
using UnityEngine.UI;

public class SlotMachineController : MonoBehaviour
{
    [Header("Available Symbols")]
    [SerializeField] private SymbolData[] symbols;

    [Header("Center Payline Images")]
    [SerializeField] private Image reel1Center;
    [SerializeField] private Image reel2Center;
    [SerializeField] private Image reel3Center;

    public SymbolData Spin()
    {
        return symbols[Random.Range(0, symbols.Length)];
    }

    public void SetCenterSymbols(SymbolData symbol1,
                                 SymbolData symbol2,
                                 SymbolData symbol3)
    {
        reel1Center.sprite = symbol1.sprite;
        reel2Center.sprite = symbol2.sprite;
        reel3Center.sprite = symbol3.sprite;
    }
}
