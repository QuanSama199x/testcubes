using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public TypeData Type;
    public string ItemID;
    public string ItemName;
    public string ItemImgPath;

}
