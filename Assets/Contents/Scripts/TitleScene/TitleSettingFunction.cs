using System;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class TitleSettingFunction : MonoBehaviour
{
    public Action<TitleState> ChangeTitleStateCallback;

    private const float DefaultVolume = 0.8f;
    private float _masterVolume;
    private float _bgmVolume;
    private float _seVolume;

    private void Awake()
    {
        _masterVolume = DefaultVolume;
        _bgmVolume = DefaultVolume;
        _seVolume = DefaultVolume;

        S_BGMManager.Instance.ChangeVolume(_masterVolume * _bgmVolume);
        S_SEManager.Instance.ChangeVolume(_masterVolume * _seVolume);
    }

    public void OnMasterVolumeSliderValueChanged(float value)
    {
        _masterVolume = value;
        S_BGMManager.Instance.ChangeVolume(_masterVolume * _bgmVolume);
        S_SEManager.Instance.ChangeVolume(_masterVolume * _seVolume);

        S_SEManager.Instance.Play("u_cursor");
    }
    public void OnBGMVolumeSliderValueChanged(float value)
    {
        _bgmVolume = value;
        S_BGMManager.Instance.ChangeVolume(_masterVolume * _bgmVolume);

        S_SEManager.Instance.Play("u_cursor");
    }
    public void OnSEVolumeSliderValueChanged(float value)
    {
        _seVolume = value;
        S_SEManager.Instance.ChangeVolume(_masterVolume * _seVolume);

        S_SEManager.Instance.Play("u_cursor");
    }

    public void OnBackButton()
    {
        ChangeTitleStateCallback?.Invoke(TitleState.Menu);
        S_SEManager.Instance.Play("u_cancel");
    }
}
