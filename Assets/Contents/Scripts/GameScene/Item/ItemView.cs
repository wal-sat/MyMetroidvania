using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _disableSprite;

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
