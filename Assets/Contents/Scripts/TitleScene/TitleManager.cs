using Cysharp.Threading.Tasks;
using UnityEngine;

public enum TitleState { Menu, Setting }

public class TitleManager : MonoBehaviour
{
    [SerializeField] private TitleMenuNavigate _titleMenuNavigate;
    [SerializeField] private TitleMenuFunction _titleMenuFunction;
    [SerializeField] private TitleSettingNavigate _titleSettingNavigate;
    [SerializeField] private TitleSettingFunction _titleSettingFunction;
    [SerializeField] private TitleUIManager _titleUIManager;
    private TitleState _currentTitleState;

    private void Awake()
    {
        _titleMenuFunction.ChangeTitleStateCallback = ChangeTitleState;
        _titleSettingFunction.ChangeTitleStateCallback = ChangeTitleState;

        ChangeTitleState(TitleState.Menu);
    }
    private void Start()
    {
        S_BGMManager.Instance.Play("title", 2f);
    }
    private void Update()
    {
        switch (_currentTitleState)
        {
            case TitleState.Menu:
                _titleMenuNavigate.NavigateUpdate();
                break;
            case TitleState.Setting:
                _titleSettingNavigate.NavigateUpdate();
                break;
        }
    }

    private void ChangeTitleState(TitleState newState)
    {
        _currentTitleState = newState;

        switch (_currentTitleState)
        {
            case TitleState.Menu:
                _titleMenuNavigate.SelectInitial();
                _titleUIManager.DisplaySettingPanel(false);
                break;
            case TitleState.Setting:
                _titleSettingNavigate.SelectInitial();
                _titleUIManager.DisplaySettingPanel(true);
                break;
        }
    }
}
