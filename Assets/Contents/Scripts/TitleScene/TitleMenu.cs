using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] TitleUIManager titleUIManager;
    public Action<TitleStatus> ChangeTitleStatus;

    private int _menuIndex;
    int menuIndex
    {
        get => _menuIndex;
        set
        {
            _menuIndex = Mathf.Clamp(value, 0, 2);
            titleUIManager.ChangeMenuCursorImage(_menuIndex);
        }
    }

    private void Start()
    {
        menuIndex = 0;
    }

    public void NavigateUp()
    {
        menuIndex--;
        S_SEManager.instance.Play("u_cursor");
    }
    public void NavigateDown()
    {
        menuIndex++;
        S_SEManager.instance.Play("u_cursor");
    }
    public void Submit()
    {
        switch (menuIndex)
        {
            case 0:
                S_LoadSceneManager.instance.LoadScene(SceneKind.Stage0);
                S_SEManager.instance.Play("u_submit");
                break;
            case 1:
                ChangeTitleStatus(TitleStatus.setting);
                S_SEManager.instance.Play("u_submit");
                break;
            case 2:
                EndGame();
                S_SEManager.instance.Play("u_cancel");
                break;
        }
    }

    private async void EndGame()
    {
        S_FadeManager.instance.FadeOut(1f);

        await UniTask.WaitForSeconds(1f);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
