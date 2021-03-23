using System;
using UnityEngine.UI;

public sealed class EventService : Service
{
    public event Action<int> OnUpdateAmountMoney;

    public event Action<Image> OnEquipSkin;
    public event Action<Image> OnEquipHat;
    public event Action<Image> OnEquipRobe;

    public event Action<InventoryType, int> OnRewardInventory;
    public event Action OnRewardMoney;
    public event Action OnUpdateItems;

    public EventService()
    {
        OnUpdateAmountMoney += delegate { };
        OnEquipSkin += delegate { };
        OnEquipHat += delegate { };
        OnEquipRobe += delegate { };
        OnRewardInventory += delegate { };
        OnRewardMoney += delegate { };
        OnUpdateItems += delegate { };
    }

    public void UpdateAmountMoney(int value) => OnUpdateAmountMoney?.Invoke(value);
    public void EquipSkin(Image image) => OnEquipSkin?.Invoke(image);
    public void EquipHat(Image image) => OnEquipHat?.Invoke(image);
    public void EquipRobe(Image image) => OnEquipRobe?.Invoke(image);
    public void RewardItem(InventoryType type, int index) => OnRewardInventory?.Invoke(type, index);
    public void RewardMoney() => OnRewardMoney?.Invoke();
    public void UpdateItems() => OnUpdateItems?.Invoke();
}