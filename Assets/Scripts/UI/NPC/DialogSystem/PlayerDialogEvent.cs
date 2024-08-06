using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDialogEvent : MonoBehaviour
{
    private string playerName = "주인공";

    private string sceneName;

    void SetIndex()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial Map")
            UIManager.instance.dialogSystem.charCurIndex = 100;

        // 씬에 할당하는 메세지가 많을시 사용
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
