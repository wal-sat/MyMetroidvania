using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas _worldSpaceCanvas;
    [SerializeField] GameObject _damegeText;
    [SerializeField] private TextMeshProUGUI _hpText;

    private Vector3 _DAMAGE_TEXT_OFFSET = new Vector3(0, 1f, 0);

    public void HPTextUpdate(int currentHp, int maxHp)
    {
        _hpText.text = "HP : " + currentHp.ToString() + " / " + maxHp.ToString();
    } 

    public void DisplayDamageText(int damage, Vector3 position)
    {
        Camera cam = _worldSpaceCanvas.worldCamera;
        Vector3 screenPos = cam.WorldToScreenPoint(position + _DAMAGE_TEXT_OFFSET);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_worldSpaceCanvas.transform as RectTransform, screenPos, cam, out Vector2 localPos );
        
        GameObject damageText = Instantiate(_damegeText, localPos, Quaternion.identity);
        damageText.transform.SetParent(_worldSpaceCanvas.transform, false);
        damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }
}
