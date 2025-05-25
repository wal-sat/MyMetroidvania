using UnityEngine;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    private Vector2 _settingPanelActivePos = new Vector2(0, 0);
    private Vector2 _settingPanelInactivePos = new Vector2(0, 1080);


    public void DisplaySettingPanel(bool isActive)
    {
        if (isActive) _settingPanel.transform.DOLocalMove(_settingPanelActivePos, 1f).SetEase(Ease.OutCubic);
        else _settingPanel.transform.DOLocalMove(_settingPanelInactivePos, 1f).SetEase(Ease.OutCubic);
    }
}
