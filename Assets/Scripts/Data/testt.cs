using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testt : MonoBehaviour
{
    public bool x,y;

    public List<int> number;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("test")]
    public void testcompare()
    {
        number.Sort(delegate (int a, int b)
        {
            Debug.LogError(a.CompareTo(b));
            return a.CompareTo(b);
        });

        Debug.LogError("tt: "+x.CompareTo(y));

    }
}

