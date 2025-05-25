using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class TitleMenuFunction : MonoBehaviour
{
    public Action<TitleState> ChangeTitleStateCallback;

    public void OnStartButton()
    {
        S_LoadSceneManager.Instance.LoadScene(SceneKind.Stage0);
        S_SEManager.Instance.Play("u_submit");
    }

    public void OnSettingButton()
    {

        ChangeTitleStateCallback?.Invoke(TitleState.Setting);
        S_SEManager.Instance.Play("u_submit");
    }
    
    public void OnExitButton()
    {
        OnExitButtonAsync().Forget();
        S_SEManager.Instance.Play("u_submit");
    }

    private async UniTaskVoid OnExitButtonAsync()
    {
        S_FadeManager.Instance.FadeOut(1f);

        await UniTask.WaitForSeconds(1f);

        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
