using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _attackSprite;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ViewUpdate(bool isFacingRight)
    {
        if (isFacingRight) ChangeScaleX(1f);
        else ChangeScaleX(-1f);
    }

    public void ChangeScaleX(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    }

    public void ChangeAttackSprite(bool isAttacking)
    {
        if (isAttacking) _spriteRenderer.sprite = _attackSprite;
        else _spriteRenderer.sprite = _normalSprite;
    }
}
