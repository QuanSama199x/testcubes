using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<SoundController>();
            return instance;
        }
    }
    public PoolElementSound Sound;
    void Start()
    {
        Sound.CreatePooling("Sound/Sound");
    }
}
[System.Serializable]
public class PoolElementSound
{
    public List<SoundScript> ListObjects;
    public int amount;
    public SoundScript obj;

    public void CreatePooling(string link)
    {
        obj = Resources.Load<SoundScript>(link);
        for (int i = 0; i < amount; i++)
        {
            SoundScript obj1 = SoundScript.Instantiate(obj);
            ListObjects.Add(obj1);
        }
    }

    public SoundScript GetPooledObject()
    {
        for (int i = 0; i < ListObjects.Count; i++)
        {
            return ListObjects[i];
        }
        SoundScript obj1 = SoundScript.Instantiate(obj);
        ListObjects.Add(obj1);
        return obj1;
    }
}

public struct aaa
{
    public int[] bb;
}
