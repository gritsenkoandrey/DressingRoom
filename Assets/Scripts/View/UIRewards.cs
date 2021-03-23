using UnityEngine;

public sealed class UIRewards : UIBaseInterface
{
    private UIButtonGetReward _button;
    private UIImageReward[] _images;
    private Sprite _tmpSprite;
    private GameData _data;

    private void Awake()
    {
        _data = Data.Instance.Game;
        _button = FindObjectOfType<UIButtonGetReward>();
        _images = GetComponentsInChildren<UIImageReward>();
    }

    private void OnEnable()
    {
        Services.Instance.EventService.OnUpdateItems += UpdateItems;
        Services.Instance.EventService.OnRewardInventory += RewardInventory;
        Services.Instance.EventService.OnRewardMoney += RewardMoney;
    }

    private void OnDisable()
    {
        Services.Instance.EventService.OnUpdateItems -= UpdateItems;
        Services.Instance.EventService.OnRewardInventory -= RewardInventory;
        Services.Instance.EventService.OnRewardMoney -= RewardMoney;
    }

    private void UpdateItems()
    {
        for (int i = _images.Length - 2; i >= 0; i--)
        {
            _tmpSprite = _images[i].GetImage.sprite;
            _images[i + 1].GetImage.sprite = _tmpSprite;
        }
    }

    private void RewardInventory(InventoryType type, int index)
    {
        switch (type)
        {
            case InventoryType.Skin:
                RewardSkin(index);
                break;
            case InventoryType.Hat:
                RewardHat(index);
                break;
            case InventoryType.Robe:
                RewardRobe(index);
                break;
        }
    }

    private void RewardSkin(int index)
    {
        _button.ShowInventory(InventoryType.Skin, index);
        if (!_data.SkinIsUnlocked((SkinType)index)) _data.SkinUnlocked((SkinType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.skins[index].sprite;
    }

    private void RewardRobe(int index)
    {
        _button.ShowInventory(InventoryType.Robe, index);
        if (!_data.RobeIsUnlocked((RobeType)index)) _data.RobeUnlocked((RobeType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.robes[index].sprite;
    }

    private void RewardHat(int index)
    {
        _button.ShowInventory(InventoryType.Hat, index);
        if (!_data.HatIsUnlocked((HatType)index)) _data.HatUnlocked((HatType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.hats[index].sprite;
    }

    private void RewardMoney()
    {
        _button.ShowMoney();
        GetMoney();
        _images[0].GetImage.sprite = _data.money;
    }

    private void GetMoney()
    {
        _data.AddMoney(_data.GetMoney());
        Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
    }
}