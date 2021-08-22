using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOverlay : MonoBehaviour
{
    [SerializeField] private Image _overlay;
    [SerializeField] private Text _text;

    public Tween ShowOverlay() => FadeOverlay(1);
    public Tween HideOverlay() => FadeOverlay(0);

    public Tween ShowText(string text)
    {
        _text.text = text;

        float _textHoldTime = 2f;
        float hideShowTime = 0.8f;

        return DOTween.Sequence()
            .SetId(transform)
            .AppendInterval(0.5f)
            .Append(_text.DOFade(1, hideShowTime).SetEase(Ease.InOutSine))
            .AppendInterval(_textHoldTime)
            .Append(_text.DOFade(0, hideShowTime).SetEase(Ease.InOutSine));
    }

    private Tween FadeOverlay(float targetAlpha) =>
        _overlay.DOFade(targetAlpha, duration: 2.5f).SetEase(Ease.InOutSine);
}