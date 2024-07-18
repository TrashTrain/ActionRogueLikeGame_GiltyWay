using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        // ��ġ���� 100����, ��ȭ������ npc �� 1000�����
        talkData.Add(1000, new string[] { "�ȳ�? ó������ ���̳�.", "�츮 ������ �� �� ȯ����." });
        talkData.Add(100, new string[] { "�� ���Ͼ��� ������� ���̴�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
}
