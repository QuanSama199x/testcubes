using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConverDmg : MonoBehaviour
{
    [SerializeField]private double PlayerDmg;

    // Start is called before the first frame update
    void Start()
    {


    }

    [ContextMenu("TestConvert")]
    public void Convert()
    {
        Debug.LogError(OutString(PlayerDmg));
    }

    public float ConvertDmg(double dmg,out int index)
    {
        index = 0;
        double d = dmg;
        while (d >= 1000)
        {
            d /= 1000;
            index++;
        }
        return (float)d;
    }

    public string OutString(double dmg)
    {
        float dmgConvert= ConvertDmg(dmg,out var index);
        string text = "";
        string texttype = "";
        List<TypeDmg> types = new List<TypeDmg>();
        for(int x=0;x<2;x++)
        {
            TypeDmg type = new TypeDmg();
            type = TypeDmg.None;
            types.Add(type);
        }
        
        int count = Enum.GetNames(typeof(TypeDmg)).Length;
        while (index>0)
        {
            if (index>count)
            {
                types[0]++;

                index -= count;
            }
            else
            {
                types[1] += index;
                index = 0;
            }

        }

        for(int j=0;j>= types.Count - 1; j++)
        {
            if(types[j]== TypeDmg.None)
            {
                continue;
            }             
            texttype += types[j].ToString();
        }


        
 /*       if (type == TypeDmg.None)
        {
            text = dmgConvert.ToString();
        }*/

            text = string.Format("{0:#.##}", dmgConvert)+"//"+ texttype;

        
        return text;

    }

}

public enum TypeDmg
{
    None,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z,
}

