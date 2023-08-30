
using UnityEngine;

public enum ItemType
{
    Default,
    Supplies,
    Weapon,

}

public abstract class ItemObject : ScriptableObject
{
    public Sprite sprite;
    public ItemType type;
}
