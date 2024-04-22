using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    int[,] map;
    GameObject[,] field;

    /*oid PrintArray()
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
    }*/


    void Start()

    {
        /*GameObject instance = Instantiate(
            playerPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);*/

        map = new int[,]
        {
           { 0, 0, 0, 0, 0 },
           { 0, 0, 1, 0, 0 },
           { 0, 0, 0, 0, 0 },
        };
        field = new GameObject
                  [
                   map.GetLength(0),
                   map.GetLength(1)
                  ];
        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
                if (map[y, x] == 1)
                {
                    //GameObject instance
                    field[y,x]= Instantiate(
                        playerPrefab,
                        new Vector3(x,map.GetLength(0)- y,0.0f),
                        Quaternion.identity);
                }
                
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
        
    }

    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < map.Length; y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y,x].tag == "Player")
                {
                    return new Vector2Int(x,y);
                }
            }
            
        }
        return new Vector2Int(-1, -1);
    }

    
    // Update is called once per frame
    /*void Update()
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
    }*/
   

}
