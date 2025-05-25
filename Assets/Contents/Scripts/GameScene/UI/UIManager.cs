using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas _worldSpaceCanvas;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _crystalText;
    [SerializeField] private GameObject _damegeText;
    [SerializeField] private Vector3 _damageTextOffset = new Vector3(0, 1f, 0);

    private void OnEnable()
    {
        S_PlayerInformation.Instance.SubscribeHPAmountUpdateCallback(HPTextUpdate);
        S_PlayerInformation.Instance.SubscribeCoinCountUpdateCallback(CoinTextUpdate);
        S_PlayerInformation.Instance.SubscribeCrystalCountUpdateCallback(CrystalTextUpdate);
    }
    private void OnDisable()
    {
        if (S_PlayerInformation.Instance != null) S_PlayerInformation.Instance.SubscribeHPAmountUpdateCallback(HPTextUpdate, false);
        if (S_PlayerInformation.Instance != null) S_PlayerInformation.Instance.SubscribeCoinCountUpdateCallback(CoinTextUpdate, false);
        if (S_PlayerInformation.Instance != null) S_PlayerInformation.Instance.SubscribeCrystalCountUpdateCallback(CrystalTextUpdate, false);
    }

    private void HPTextUpdate(int hpAmount)
    {
        _hpText.text = hpAmount.ToString() + " / " + S_PlayerInformation.Instance.MAX_HP_AMOUNT.ToString();
    }
    private void CoinTextUpdate(int coinCount)
    {
        _coinText.text = coinCount.ToString();
    }
    private void CrystalTextUpdate(int crystalCount)
    {
        _crystalText.text = crystalCount.ToString();
    }

    public void DisplayDamageText(int damage, Vector3 position, Color textColor)
    {
        Camera cam = _worldSpaceCanvas.worldCamera;
        Vector3 screenPos = cam.WorldToScreenPoint(position + _damageTextOffset);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_worldSpaceCanvas.transform as RectTransform, screenPos, cam, out Vector2 localPos);

        GameObject damageText = Instantiate(_damegeText, localPos, Quaternion.identity);
        damageText.transform.SetParent(_worldSpaceCanvas.transform, false);

        TextMeshProUGUI tmp = damageText.GetComponent<TextMeshProUGUI>();
        tmp.text = damage.ToString();
        tmp.color = textColor;
    }
}
