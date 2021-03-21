using System;
using UnityEngine.UI;

public sealed class EventService : Service
{
    public event Action<int> OnUpdateAmountMoney;
    public event Action<Image> OnEquipSkin;
    public event Action<Image> OnEquipHat;
    public event Action<Image> OnEquipRobe;

    public EventService()
    {
        OnUpdateAmountMoney += delegate { };
        OnEquipSkin += delegate { };
        OnEquipHat += delegate { };
        OnEquipRobe += delegate { };
    }

    public void UpdateAmountMoney(int value) => OnUpdateAmountMoney?.Invoke(value);
    public void EquipSkin(Image image) => OnEquipSkin?.Invoke(image);
    public void EquipHat(Image image) => OnEquipHat?.Invoke(image);
    public void EquipRobe(Image image) => OnEquipRobe?.Invoke(image);
}