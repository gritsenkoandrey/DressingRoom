using UnityEngine;
using UnityEngine.UI;

public sealed class UIButtonScrollRect : UIBaseInterface
{
    [SerializeField] private Text _text = null;
    [SerializeField] private Image _imageItem = null;
    [SerializeField] private Image _inactiveImage = null;

    public Text GetText => _text;
    public Image GetItemImage => _imageItem;
    public Image GetInactiveImage => _inactiveImage;
}