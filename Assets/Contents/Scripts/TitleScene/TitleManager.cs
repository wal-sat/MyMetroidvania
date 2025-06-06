using Cysharp.Threading.Tasks;
using UnityEngine;
using NaughtyAttributes;

public enum TitleStatus { menu, setting }

public class TitleManager : MonoBehaviour
{
    [SerializeField] TitleMenu titleMenu;
    [SerializeField] TitleSetting titleSetting;
    [SerializeField] TitleUIManager titleUIManager;

    private bool _isNavigateUp;
    private bool _isNavigateDown;
    private bool _isNavigateLeft;
    private bool _isNavigateRight;
    private bool _isSubmit;
    private bool _isCancel;

    private TitleStatus _titleStatus;

    private void Awake()
    {
        titleMenu.ChangeTitleStatus = ChangeTitleStatus;
        titleSetting.ChangeTitleStatus = ChangeTitleStatus;
    }
    private void Start()
    {
        S_InputSystemManager.instance.SwitchActionMap(ActionMapKind.UI);

        S_BGMManager.instance.Play("title", 2f);

        ChangeTitleStatus(TitleStatus.menu);
    }

    private void Update()
    {
        if (S_InputSystemManager.instance.UIMove == Vector2.up && !_isNavigateUp) NavigateUp();
        else if (S_InputSystemManager.instance.UIMove != Vector2.up && _isNavigateUp) _isNavigateUp = false;

        if (S_InputSystemManager.instance.UIMove == Vector2.down && !_isNavigateDown) NavigateDown();
        else if (S_InputSystemManager.instance.UIMove != Vector2.down && _isNavigateDown) _isNavigateDown = false;

        if (S_InputSystemManager.instance.UIMove == Vector2.right && !_isNavigateRight) NavigateRight();
        else if (S_InputSystemManager.instance.UIMove != Vector2.right && _isNavigateRight) _isNavigateRight = false;

        if (S_InputSystemManager.instance.UIMove == Vector2.left && !_isNavigateLeft) NavigateLeft();
        else if (S_InputSystemManager.instance.UIMove != Vector2.left && _isNavigateLeft) _isNavigateLeft = false;

        if (S_InputSystemManager.instance.isPushingSubmit && !_isSubmit) Submit();
        else if (!S_InputSystemManager.instance.isPushingSubmit && _isSubmit) _isSubmit = false;

        if (S_InputSystemManager.instance.isPushingCancel && !_isCancel) Cancel();
        else if (!S_InputSystemManager.instance.isPushingCancel && _isCancel) _isCancel = false;
    }

    private void NavigateUp()
    {
        _isNavigateUp = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                titleMenu.NavigateUp();
                break;
            case TitleStatus.setting:
                titleSetting.NavigateUp();
                break;
        }
    }
    private void NavigateDown()
    {
        _isNavigateDown = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                titleMenu.NavigateDown();
                break;
            case TitleStatus.setting:
                titleSetting.NavigateDown();
                break;
        }
    }
    private void NavigateRight()
    {
        _isNavigateRight = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                break;
            case TitleStatus.setting:
                titleSetting.NavigateRight();
                break;
        }
    }
    private void NavigateLeft()
    {
        _isNavigateLeft = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                break;
            case TitleStatus.setting:
                titleSetting.NavigateLeft();
                break;
        }
    }
    private void Submit()
    {
        _isSubmit = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                titleMenu.Submit();
                break;
            case TitleStatus.setting:
                titleSetting.Submit();
                break;
        }
    }
    private void Cancel()
    {
        _isCancel = true;
        switch (_titleStatus)
        {
            case TitleStatus.menu:
                break;
            case TitleStatus.setting:
                titleSetting.Cancel();
                break;
        }
    }

    private void ChangeTitleStatus(TitleStatus titleStatus)
    {
        _titleStatus = titleStatus;

        switch (_titleStatus)
        {
            case TitleStatus.menu:
                titleUIManager.DisplaySettingPanel(false);
                break;
            case TitleStatus.setting:
                titleUIManager.DisplaySettingPanel(true);
                break;
        }
    }
}
