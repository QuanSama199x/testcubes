using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string ItemID;
    public string TypeID;
    public string ItemName;
    public string ItemPath;

    public Item(ItemData data)
    {
        this.ItemID = data.ItemID;
        this.TypeID = data.Type.TypeId;
        this.ItemName = data.ItemName;
        this.ItemPath = data.ItemImgPath;
    }
}

[System.Serializable]
public class Currency
{
    public string CurrencyID;
    public string CurrencyName;
    public string CurrencyPath;

    public Currency(CurrencyData currencydata)
    {
        this.CurrencyID = currencydata.CurrencyId;
        this.CurrencyName = currencydata.CurrencyName;
        this.CurrencyPath = currencydata.CurrencyPath;
    }
}

[System.Serializable]
public class TypeItem
{
    public string TypeID;
    public string TypeName;
    
    public TypeItem(TypeData data)
    {
        this.TypeID = data.TypeId;
        this.TypeName = data.TypeName;

    }
}





public interface IDataManager
{
    Item GetItem(string id);
    Item[] GetItembyType(string typeId);
    Item[] GetDefaultItems();

    Currency GetCurrency(string id);
    Currency[] GetAllCurrency();
}



[System.Serializable]
public class PlayerProfile
{

}

public interface IPlayerProgression
{
    void Initialize();
    void Load(string data);
    void Save();
    PlayerProfile PlayerProfile { get; }
}


