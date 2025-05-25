using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

// Scene名を列挙する
public enum SceneKind { Title, Stage0, Stage1, Ending }

public class S_LoadSceneManager : Singleton<S_LoadSceneManager>
{
    private const float FadeTime = 1f;

    public async void LoadScene(SceneKind sceneKind)
    {
        S_InputSystemManager.Instance.SetLockInputDictionary(this.gameObject, true);
        S_FadeManager.Instance.FadeOut(FadeTime);

        await UniTask.WaitForSeconds(FadeTime);

        SceneManager.LoadScene(sceneKind.ToString());

        await UniTask.WaitForSeconds(FadeTime / 2);

        S_InputSystemManager.Instance.SetLockInputDictionary(this.gameObject, false);
        S_FadeManager.Instance.FadeIn(FadeTime);
    }
}

