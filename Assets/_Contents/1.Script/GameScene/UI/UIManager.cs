using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas worldSpaceCanvas;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI crystalText;
    [SerializeField] GameObject damegeText;

    [SerializeField] private Vector3 DAMAGE_TEXT_OFFSET = new Vector3(0, 1f, 0);

    private void OnEnable()
    {
        S_PlayerInformation.instance.SubscribeHPAmountUpdateCallback(HPTextUpdate);
        S_PlayerInformation.instance.SubscribeCoinCountUpdateCallback(CoinTextUpdate);
        S_PlayerInformation.instance.SubscribeCrystalCountUpdateCallback(CrystalTextUpdate);
    }
    private void OnDisable()
    {
        S_PlayerInformation.instance.SubscribeHPAmountUpdateCallback(HPTextUpdate, false);
        S_PlayerInformation.instance.SubscribeCoinCountUpdateCallback(CoinTextUpdate, false);
        S_PlayerInformation.instance.SubscribeCrystalCountUpdateCallback(CrystalTextUpdate, false);
    }

    private void HPTextUpdate(int hpAmount)
    {
        hpText.text = hpAmount.ToString() + " / " + S_PlayerInformation.instance.MAX_HP_AMOUNT.ToString();
    }
    private void CoinTextUpdate(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }
    private void CrystalTextUpdate(int crystalCount)
    {
        crystalText.text = crystalCount.ToString();
    }

    public void DisplayDamageText(int damage, Vector3 position)
    {
        Camera cam = worldSpaceCanvas.worldCamera;
        Vector3 screenPos = cam.WorldToScreenPoint(position + DAMAGE_TEXT_OFFSET);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(worldSpaceCanvas.transform as RectTransform, screenPos, cam, out Vector2 localPos);

        GameObject damageText = Instantiate(damegeText, localPos, Quaternion.identity);
        damageText.transform.SetParent(worldSpaceCanvas.transform, false);
        damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }
}
