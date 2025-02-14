using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public int CountWin;
    public int _CountWin;
    private bool isWin;

    public void CheckWin()
    {
        _CountWin++;
        if (!isWin)
        {
            if (_CountWin == CountWin)
            {
                isWin = true;
                Debug.LogError("Win Win Win");
            }
        }
    }
}
