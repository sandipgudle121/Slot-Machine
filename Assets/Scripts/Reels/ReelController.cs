using UnityEngine;

public class ReelController : MonoBehaviour
{
    [Header("Symbols")]
    [SerializeField] private RectTransform[] symbols;
    [SerializeField] private SymbolController[] symbolControllers;
    [SerializeField] private SymbolData[] availableSymbols;

    [Header("Spin Settings")]
    [SerializeField] private float spinSpeed = 500f;

    private bool isSpinning = false;

    private void Start()
    {
        for (int i = 0; i < symbolControllers.Length; i++)
        {
            SymbolData randomSymbol =
                availableSymbols[Random.Range(0, availableSymbols.Length)];

            symbolControllers[i].SetSymbol(randomSymbol);
        }
    }

    private void Update()
    {
        if (!isSpinning)
            return;

        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].anchoredPosition += Vector2.down * spinSpeed * Time.deltaTime;

            if (symbols[i].anchoredPosition.y <= -400f)
            {
                symbols[i].anchoredPosition += new Vector2(0f, 800f);

                SymbolData randomSymbol =
                    availableSymbols[Random.Range(0, availableSymbols.Length)];

                symbolControllers[i].SetSymbol(randomSymbol);
            }
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    public void StopSpin()
    {
        isSpinning = false;
    }

    public void AlignReel()
    {
        // We expect Symbol2 to be the center symbol
        float offset = -symbols[2].anchoredPosition.y;

        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition += new Vector2(0f, offset);
        }
    }

    public SymbolData GetCenterSymbol()
    {
        Debug.Log($"{gameObject.name} → symbolControllers.Length = {symbolControllers.Length}");

        if (symbolControllers == null)
        {
            Debug.LogError($"{gameObject.name}: symbolControllers is NULL");
            return null;
        }

        if (symbolControllers.Length <= 2)
        {
            Debug.LogError($"{gameObject.name}: symbolControllers has only {symbolControllers.Length} elements");
            return null;
        }

        return symbolControllers[2].CurrentSymbol;
    }

    public SymbolController GetCenterSymbolController()
    {
        return symbolControllers[2];
    }

    public void SetCenterSymbol(SymbolData symbol)
    {
        symbolControllers[2].SetSymbol(symbol);
    }
}
