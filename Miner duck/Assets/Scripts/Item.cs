using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public int value = 0;
    public Sprite icon = null;
}
