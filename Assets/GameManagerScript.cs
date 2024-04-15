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
        //�ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length) { return false; }
        //�ړ����2�i���j��������
        if (map[moveTo] == 2)
        {
            //�ǂ̕����Ɉړ����邩���Z�o
            int velocity = moveTo - moveForm;
            //�v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������
            //���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h��
            //�ĂсA�������ċA���Ă���B�ړ��s��bool�ŋL�^
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //���������ړ����s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }

        //�v���C���[�E���ւ�炸�̈ړ�����
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
