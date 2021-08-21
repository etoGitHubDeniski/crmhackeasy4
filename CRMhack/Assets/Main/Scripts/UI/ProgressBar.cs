using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBarImage;

    private Tween _fillAnimation;

    private void Start() => _progressBarImage.fillAmount = 0;

    public void Fill(int maxSteps, int filledSteps)
    {
        _fillAnimation.Kill();

        _fillAnimation = _progressBarImage
            .DOFillAmount((1f / maxSteps) * filledSteps, 0.2f)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                if (_progressBarImage.fillAmount >= 0.98f)
                    FilledAnimation();
            });
    }

    private void FilledAnimation()
    {
        _fillAnimation.Kill();

        float animationTime = 0.4f;
        Ease ease = Ease.OutSine;

        DOTween.Sequence()
            .SetId(transform)
            .Append(transform.DOScale(1.3f, animationTime).SetEase(ease))
            .Join(transform.DOMoveY(transform.position.y + 0.15f, animationTime).SetEase(ease))
            .Join(_progressBarImage.DOFade(0, animationTime).SetEase(ease));
    }
}