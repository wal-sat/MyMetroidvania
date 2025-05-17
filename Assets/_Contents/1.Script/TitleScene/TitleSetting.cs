using System;
using UnityEngine;

public class TitleSetting : MonoBehaviour
{
    [SerializeField] TitleUIManager titleUIManager;
    public Action<TitleStatus> ChangeTitleStatus;

    private int _settingIndex;
    int settingIndex
    {
        get => _settingIndex;
        set
        {
            _settingIndex = Mathf.Clamp(value, 0, 2);
            titleUIManager.ChangeMenuCursorImage(_settingIndex);
        }
    }
}
