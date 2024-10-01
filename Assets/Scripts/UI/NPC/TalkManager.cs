using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    [Header("RandomSlotNPC")]
    public GameObject randomSlot;
    public RectTransform selectCursor;
    public GameObject selectImage;
    private bool isRandomSlot = true;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        // ��ġ���� 100����, ��ȭ������ npc �� 1000�����
        talkData.Add(1000, new string[] { "��������Ʈ 3�� �Ҹ��ؼ� ���� ȿ���� ���� �� �ֽ��ϴ�.", "����Ͻðڽ��ϱ�?" });
        talkData.Add(100, new string[] { "�� ���Ͼ��� ������� ���̴�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            if(id == 1000)
            {
                selectImage.SetActive(true);
                return talkData[id][talkIndex - 1];
            }
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
    private void Update()
    {
  
    }

    void GetRandomSlot()
    {
        randomSlot.SetActive(true);
    }
}
