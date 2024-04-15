using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    int[] map;

    void PrintArray()
    {
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveForm, int moveTo)
    {
        //移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length) { return false; }
        //移動先に2（箱）がいたら
        if (map[moveTo] == 2)
        {
            //どの方向に移動するかを算出
            int velocity = moveTo - moveForm;
            //プレイヤーの移動先から、さらに先へ2(箱)を移動させる
            //箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
            //呼び、処理が再帰している。移動不可をboolで記録
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //もし箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }

        //プレイヤー・箱関わらずの移動処理
        map[moveTo] = number;
        map[moveForm] = 0;
        return true;
    }


    void Start()

    {
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 2, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int PlIndex = GetPlayerIndex();

            MoveNumber(1, PlIndex, PlIndex + 1);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int PlIndex = GetPlayerIndex();

            MoveNumber(1, PlIndex, PlIndex - 1);
            PrintArray();
        }
    }


}
