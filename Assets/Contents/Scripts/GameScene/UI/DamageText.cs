using UnityEngine;
using DG.Tweening;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float _damageTextLifeTime;
    [SerializeField] private float _damageTextMoveDistance;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroup.DOFade(0f, _damageTextLifeTime / 2).SetEase(Ease.Linear).SetDelay(_damageTextLifeTime / 2).SetLink(this.gameObject);
        transform.DOLocalMoveY(transform.localPosition.y + _damageTextMoveDistance, _damageTextLifeTime).SetEase(Ease.OutSine).SetLink(this.gameObject)
            .OnComplete(() => {
                Destroy(gameObject);
            });
    }
}
