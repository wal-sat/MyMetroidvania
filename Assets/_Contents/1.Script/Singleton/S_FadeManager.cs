using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;

public class S_FadeManager : Singleton<S_FadeManager>
{
    [SerializeField] CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup.alpha = 1f;
        FadeIn(1);   
    }

    public void FadeIn(float duration)
    {
        canvasGroup.DOFade(0f, duration).SetEase(Ease.Linear);
    }
    public void FadeOut(float duration)
    {
        canvasGroup.DOFade(1f, duration).SetEase(Ease.Linear);
    }
}
