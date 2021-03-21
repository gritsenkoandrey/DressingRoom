using UnityEngine;
using UnityEngine.UI;

public sealed class UIButtonGetReward : UIBaseInterface
{
    [SerializeField] private Image _image = null;
    [SerializeField] private Text _text = null;

    public Image Image => _image;
    public Text Text => _text;

    public void Hide()
    {
        _text.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}