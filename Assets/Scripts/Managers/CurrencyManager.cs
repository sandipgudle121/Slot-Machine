using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int startingBalance = 1000;

    public int CurrentBalance { get; private set; }

    private void Awake()
    {
        CurrentBalance = startingBalance;
    }

    public bool Spend(int amount)
    {
        if (CurrentBalance < amount)
            return false;

        CurrentBalance -= amount;
        return true;
    }

    public void Add(int amount)
    {
        CurrentBalance += amount;
    }
}
