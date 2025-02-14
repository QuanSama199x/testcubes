using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDataManager : MonoBehaviour,IDataManager
{
    public LibraryData Library;

    [SerializeField] protected List<Item> ItemList;
    [SerializeField] protected List<TypeItem> ItemTypeList;
    [SerializeField] protected List<Currency> CurrencyList;

    private List<Item> SortedList;
    public Currency[] GetAllCurrency()
    {
        List<Currency> currencies = new List<Currency>();
        for (int i = 0; i < CurrencyList.Count; i++)
        {
            currencies.Add(CurrencyList[i]);
        }
        return currencies.ToArray();
    }

    public Currency GetCurrency(string id)
    {

        for(int i=0;i<CurrencyList.Count;i++)
        {
            if (id == CurrencyList[i].CurrencyID)
            {
                return CurrencyList[i];
            }
        }
        Debug.LogError("Hong co Currency id nay`");
        return null;

    }

    public Item[] GetDefaultItems()
    {
        SortedList = new List<Item>();
        for(int i=0;i<Library.DefaultItem.Count;i++)
        {
            var item = GetItem(Library.DefaultItem[i].ItemID);
            if(item!=null)
            {
                SortedList.Add(item);
            }
        }
        return SortedList.ToArray();
    }

    public Item GetItem(string id)
    {
        for(int i=0;i< ItemList.Count;i++)
        {
            if(id == ItemList[i].ItemID)
            {
                return ItemList[i];
            }
        }
        Debug.LogError("Hong co Item Nay");
        return null;
    }

    public Item[] GetItembyType(string typeId)
    {
        SortedList = new List<Item>();
        for(int i=0;i<ItemList.Count;i++)
        {
            if(typeId == ItemList[i].TypeID)
            {
                SortedList.Add(ItemList[i]);
            }
        }
        return SortedList.ToArray();
    }

    // Start is called before the first frame update
    private void Start()
    {
        /*DontDestroyOnLoad(gameObject);
        this.Init();*/
    }
    public virtual void Init()
    {
        foreach(var data in Library.ListItem)
        {
            Item item = new Item(data);
            ItemList.Add(item);
        }

        foreach(var data in Library.ListType)
        {
            TypeItem typeItem = new TypeItem(data);
            ItemTypeList.Add(typeItem);
        }

        foreach(var data in Library.ListCurrency)
        {
            Currency currency = new Currency(data);
            CurrencyList.Add(currency);
        }
    }

}
