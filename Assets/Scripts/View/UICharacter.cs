using UnityEngine;
using UnityEngine.UI;

public sealed class UICharacter : UIBaseInterface
{
    [SerializeField] private Image _skin = null;
    [SerializeField] private Image _hat = null;
    [SerializeField] private Image _robe = null;

    private void OnEnable()
    {
        Services.Instance.EventService.OnEquipSkin += EquipSkin;
        Services.Instance.EventService.OnEquipHat += EquipHat;
        Services.Instance.EventService.OnEquipRobe += EquipRobe;
    }

    private void OnDisable()
    {
        Services.Instance.EventService.OnEquipSkin -= EquipSkin;
        Services.Instance.EventService.OnEquipHat -= EquipHat;
        Services.Instance.EventService.OnEquipRobe -= EquipRobe;
    }

    private void EquipSkin(Image image)
    {
        _skin.sprite = image.sprite;
    }

    private void EquipHat(Image image)
    {
        _hat.sprite = image.sprite;
    }

    private void EquipRobe(Image image)
    {
        _robe.sprite = image.sprite;
    }
}