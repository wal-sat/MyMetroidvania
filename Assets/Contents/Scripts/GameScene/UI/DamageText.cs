using UnityEngine;
using DG.Tweening;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float DAMAGE_TEXT_LIFE_TIME;
    [SerializeField] private float DAMAGE_TEXT_MOVE_DiSTANCE;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroup.DOFade(0f, DAMAGE_TEXT_LIFE_TIME / 2).SetEase(Ease.Linear).SetDelay(DAMAGE_TEXT_LIFE_TIME / 2).SetLink(this.gameObject);
        transform.DOLocalMoveY(transform.localPosition.y + DAMAGE_TEXT_MOVE_DiSTANCE, DAMAGE_TEXT_LIFE_TIME).SetEase(Ease.OutSine).SetLink(this.gameObject)
        .OnComplete(() => {
            Destroy(gameObject);
        });
    }
}
