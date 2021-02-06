using UnityEngine;

[CreateAssetMenu(fileName = "New pickaxe", menuName = "Inventory/Pickaxe")]
public class Pickaxe : ScriptableObject
{
    new public string name = "New pickaxe";
    public int price = 0;
    public int durability = 0;
    public GameObject pickPrefab;
}
