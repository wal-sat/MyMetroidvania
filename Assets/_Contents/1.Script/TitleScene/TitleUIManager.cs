using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject[] menuCursor = new GameObject[3];
    [SerializeField] GameObject[] settingCursor = new GameObject[4];
    [SerializeField] Slider[] volumeSlider = new Slider[3];

    private Vector2 _settingPanelActivePos = new Vector2(0, 0);
    private Vector2 _settingPanelInactivePos = new Vector2(0, 1080);

    public void ChangeMenuCursorImage(int index)
    {
        for (int i = 0; i < menuCursor.Length; i++) menuCursor[i].SetActive(false);

        menuCursor[index].SetActive(true);
    }
    public void ChangeSettingCursorImage(int index)
    {
        for (int i = 0; i < settingCursor.Length; i++) settingCursor[i].SetActive(false);

        settingCursor[index].SetActive(true);
    }
    public void ChangeVolumeSlider(int index, float value)
    {
        volumeSlider[index].value = value;
    }

    public void DisplaySettingPanel(bool isActive)
    {
        if (isActive) SettingPanel.transform.DOLocalMove(_settingPanelActivePos, 1f).SetEase(Ease.OutCubic);
        else SettingPanel.transform.DOLocalMove(_settingPanelInactivePos, 1f).SetEase(Ease.OutCubic);
    }
}
