using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/LibraryData")]
public class LibraryData : ScriptableObject
{
    public List<ItemData> ListItem;
    public List<TypeData> ListType;

    public List<ItemData> DefaultItem;

    public List<ShopItemData> ListShopItem;

    public List<CurrencyData> ListCurrency;
}
