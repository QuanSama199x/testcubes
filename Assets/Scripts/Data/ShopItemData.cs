using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ShopItemData")]
public class ShopItemData : ScriptableObject
{
    public string ItemShopId;
    public ItemData Item;
    public List<TypeBuy> TypeBuy;
}

[System.Serializable]
public class TypeBuy
{
    public CurrencyData currency;
    public float amount;

}
