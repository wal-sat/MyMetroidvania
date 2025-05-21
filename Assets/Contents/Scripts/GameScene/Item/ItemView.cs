using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] Sprite _defaultSprite;
    [SerializeField] Sprite _disableSprite;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(bool isEnable)
    {
        if (isEnable) _spriteRenderer.sprite = _defaultSprite;
        else _spriteRenderer.sprite = _disableSprite;
    }
}
