using UnityEngine;
using UnityEngine.UI;

public sealed class UIImageReward : UIBaseInterface
{
    [SerializeField] private Image _image = null;

    public Image GetImage => _image;
}