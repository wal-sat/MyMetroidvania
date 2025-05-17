using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneKind { Title, Game }

public class S_LoadSceneManager : Singleton<S_LoadSceneManager>
{
    private const float FADE_TIME = 1f;

    public async void LoadScene(SceneKind sceneKind)
    {
        S_InputSystem.instance.canInput = false;
        S_FadeManager.instance.FadeOut(FADE_TIME);

        await UniTask.WaitForSeconds(FADE_TIME);

        SceneManager.LoadScene( sceneKind.ToString() );

        await UniTask.WaitForSeconds(FADE_TIME / 2);

        S_InputSystem.instance.canInput = true;
        S_FadeManager.instance.FadeIn(FADE_TIME);
    }
}
