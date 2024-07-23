using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static async UniTask LoadScene(string sceneName)
    {
        // 로딩 씬을 먼저 로드
        await LoadLoadingScene();

        // 로딩 씬의 스크립트를 통해 실제 씬을 비동기적으로 로드
        LoadingScreen loadingScreen = LoadingScreen.Instance;
        if (loadingScreen != null)
        {
            await loadingScreen.LoadSceneAsync(sceneName);
        }
    }

    private static async UniTask LoadLoadingScene()
    {
        // 비동기 씬 로드 시작
        var operation = SceneManager.LoadSceneAsync("LoadingScene");
        await UniTask.WaitUntil(() => operation.isDone);
    }
}