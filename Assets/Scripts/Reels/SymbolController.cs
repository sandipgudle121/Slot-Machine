using UnityEngine;
using UnityEngine.UI;

public class SymbolController : MonoBehaviour
{
    [SerializeField] private Image symbolImage;

    private SymbolData currentSymbol;

    public SymbolData CurrentSymbol => currentSymbol;

    public void SetSymbol(SymbolData symbol)
    {
        currentSymbol = symbol;
        symbolImage.sprite = symbol.sprite;
    }
}
