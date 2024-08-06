using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDialogEvent : MonoBehaviour
{
    private string playerName = "���ΰ�";

    private string sceneName;

    void SetIndex()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial Map")
            UIManager.instance.dialogSystem.charCurIndex = 100;

        // ���� �Ҵ��ϴ� �޼����� ������ ���
        switch (sceneName)
        {
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetIndex();
        if (collision.gameObject.tag == "Player")
        {
            UIManager.instance.dialogSystem.ActiveDialog(UIManager.instance.dialogSystem.charCurIndex, playerName);
            UIManager.instance.dialogSystem.charCurIndex = UIManager.instance.dialogSystem.nextDialogNum;
        }

        Destroy(gameObject);

    }
}
