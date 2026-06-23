using UnityEngine;

[CreateAssetMenu(menuName = "Slot Machine/Symbol")]
public class SymbolData : ScriptableObject
{
    
    public string symbolName;
    public Sprite sprite;
    public int payoutMultiplier;
}
