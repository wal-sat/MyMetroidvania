using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneKind { Title, Stage0, Stage1, Ending }

public class S_LoadSceneManager : Singleton<S_LoadSceneManager>
{
    private const float FADE_TIME = 1f;

    public async void LoadScene(SceneKind sceneKind)
    {
        S_InputSystem.instance.SetLockInputDictionary(this.gameObject, true);
        Debug.Log("Lock Input");
        S_FadeManager.instance.FadeOut(FADE_TIME);

        await UniTask.WaitForSeconds(FADE_TIME);

        SceneManager.LoadScene(sceneKind.ToString());

        await UniTask.WaitForSeconds(FADE_TIME / 2);

        S_InputSystem.instance.SetLockInputDictionary(this.gameObject, false);
        Debug.Log("Unlock Input");
        S_FadeManager.instance.FadeIn(FADE_TIME);
    }

    private void Update()
    {
        if (S_InputSystem.instance.isPushingPause)
        {
            S_SEManager.instance.Play("p_cancel");
        }
    }
}

