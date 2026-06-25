using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    public IEnumerator Pulse()
    {
        Vector3 originalScale = transform.localScale;

        transform.localScale = originalScale * 1.2f;

        yield return new WaitForSeconds(0.2f);

        transform.localScale = originalScale;
    }
}
