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
            _settingIndex = Mathf.Clamp(value, 0, 3);
            titleUIManager.ChangeSettingCursorImage(_settingIndex);
        }
    }
    private int _masterVolumeIndex;
    int masterVolumeIndex
    {
        get => _masterVolumeIndex;
        set
        {
            _masterVolumeIndex = Mathf.Clamp(value, 0, 10);
            titleUIManager.ChangeVolumeSlider(0, _masterVolumeIndex / 10f);

            S_BGMManager.instance.ChangeVolume(_masterVolumeIndex * _bgmVolumeIndex / 100f);
            S_SEManager.instance.ChangeVolume(_masterVolumeIndex * _seVolumeIndex / 100f);
        }
    }
    private int _bgmVolumeIndex;
    int bgmVolumeIndex
    {
        get => _bgmVolumeIndex;
        set
        {
            _bgmVolumeIndex = Mathf.Clamp(value, 0, 10);
            titleUIManager.ChangeVolumeSlider(1, _bgmVolumeIndex / 10f);

            S_BGMManager.instance.ChangeVolume(_masterVolumeIndex * _bgmVolumeIndex / 100f);
        }
    }
    private int _seVolumeIndex;
    int seVolumeIndex
    {
        get => _seVolumeIndex;
        set
        {
            _seVolumeIndex = Mathf.Clamp(value, 0, 10);
            titleUIManager.ChangeVolumeSlider(2, _seVolumeIndex / 10f);

            S_SEManager.instance.ChangeVolume(_masterVolumeIndex * _seVolumeIndex / 100f);
        }
    }

    private void Start()
    {
        settingIndex = 0;
        masterVolumeIndex = 8;
        bgmVolumeIndex = 8;
        seVolumeIndex = 8;
    }

    public void NavigateUp()
    {
        settingIndex--;
        S_SEManager.instance.Play("u_cursor");
    }
    public void NavigateDown()
    {
        settingIndex++;
        S_SEManager.instance.Play("u_cursor");
    }
    public void NavigateLeft()
    {
        switch (settingIndex)
        {
            case 0:
                masterVolumeIndex--;
                break;
            case 1:
                bgmVolumeIndex--;
                break;
            case 2:
                seVolumeIndex--;
                break;
        }
        S_SEManager.instance.Play("u_cursor");
    }
    public void NavigateRight()
    {
        switch (settingIndex)
        {
            case 0:
                masterVolumeIndex++;
                break;
            case 1:
                bgmVolumeIndex++;
                break;
            case 2:
                seVolumeIndex++;
                break;
        }
        S_SEManager.instance.Play("u_cursor");
    }
    public void Submit()
    {
        if (settingIndex == 3) Cancel();
        else S_SEManager.instance.Play("u_submit");
    }
    public void Cancel()
    {
        ChangeTitleStatus(TitleStatus.menu);
        S_SEManager.instance.Play("u_cancel");
    }
}
