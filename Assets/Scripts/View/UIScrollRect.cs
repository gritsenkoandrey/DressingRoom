using UnityEngine;
using UnityEngine.UI;

public sealed class UIScrollRect : UIBaseInterface
{
    [SerializeField] private GameObject _content = null;

    private GameData _data;
    private UIButtonScrollRect[] _buttons;
    private int _index = -1;

    private void Awake()
    {
        _data = Data.Instance.Game;
        _buttons = GetComponentsInChildren<UIButtonScrollRect>();

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    private void OnEnable()
    {
        ExecuteScrollRect();
    }

    private void Start()
    {
        _content.SetActive(false);
    }

    public void ShowInventory(Image[] images, InventoryType inventory)
    {
        for (int i = 0; i < images.Length; i++)
        {
            _content.SetActive(true);

            _buttons[i].GetComponent<Button>().interactable = true;
            _buttons[i].GetItemImage.sprite = images[i].sprite;
            _buttons[i].GetItemImage.transform.localScale = new Vector3(0.8f, 0.6f, 1f);

            if (inventory == InventoryType.Skin)
            {
                _index = (int)InventoryType.Skin;

                if (!_data.SkinIsUnlocked((SkinType)i)) SetActive(_buttons[i], true);
                else SetActive(_buttons[i], false);
            }
            else if (inventory == InventoryType.Hat)
            {
                _index = (int)InventoryType.Hat;

                if (!_data.HatIsUnlocked((HatType)i)) SetActive(_buttons[i], true);
                else SetActive(_buttons[i], false);
            }
            else if (inventory == InventoryType.Robe)
            {
                _index = (int)InventoryType.Robe;

                if (!_data.RobeIsUnlocked((RobeType)i)) SetActive(_buttons[i], true);
                else SetActive(_buttons[i], false);
            }
        }
    }

    private void SetActive(UIButtonScrollRect button, bool value)
    {
        button.GetText.gameObject.SetActive(value);
        button.GetInactiveImage.gameObject.SetActive(value);
    }

    public void ButtonItem(int index)
    {
        switch (_index)
        {
            case (int)InventoryType.Skin:
                if (index == (int)SkinType.SkinOne) UseSkinItem(SkinType.SkinOne);
                else if (index == (int)SkinType.SkinTwo) UseSkinItem(SkinType.SkinTwo);
                else if (index == (int)SkinType.SkinThree) UseSkinItem(SkinType.SkinThree);
                else if (index == (int)SkinType.SkinFour) UseSkinItem(SkinType.SkinFour);
                break;
            case (int)InventoryType.Hat:
                if (index == (int)HatType.HatOne) UseHatItem(HatType.HatOne);
                else if (index == (int)HatType.HatTwo) UseHatItem(HatType.HatTwo);
                else if (index == (int)HatType.HatThree) UseHatItem(HatType.HatThree);
                else if (index == (int)HatType.HatFour) UseHatItem(HatType.HatFour);
                break;
            case (int)InventoryType.Robe:
                if (index == (int)RobeType.RobeOne) UseRobeItem(RobeType.RobeOne);
                else if (index == (int)RobeType.RobeTwo) UseRobeItem(RobeType.RobeTwo);
                else if (index == (int)RobeType.RobeThree) UseRobeItem(RobeType.RobeThree);
                else if (index == (int)RobeType.RobeFour) UseRobeItem(RobeType.RobeFour);
                break;
        }
    }

    private void UseRobeItem(RobeType type)
    {
        if (_data.ICanBuyItem() && !_data.RobeIsUnlocked(type))
        {
            _data.BuyItem();
            _data.RobeUnlocked(type, true);
            ShowInventory(_data.robes, InventoryType.Robe);
            Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
        }
        else if (_data.RobeIsUnlocked(type))
        {
            Services.Instance.EventService.EquipRobe(_data.robes[(int)type]);
        }
    }

    private void UseSkinItem(SkinType type)
    {
        if (_data.ICanBuyItem() && !_data.SkinIsUnlocked(type))
        {
            _data.BuyItem();
            _data.SkinUnlocked(type, true);
            ShowInventory(_data.skins, InventoryType.Skin);
            Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
        }
        else if (_data.SkinIsUnlocked(type))
        {
            Services.Instance.EventService.EquipSkin(_data.skins[(int)type]);
        }
    }

    private void UseHatItem(HatType type)
    {
        if (_data.ICanBuyItem() && !_data.HatIsUnlocked(type))
        {
            _data.BuyItem();
            _data.HatUnlocked(type, true);
            ShowInventory(_data.hats, InventoryType.Hat);
            Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
        }
        else if (_data.HatIsUnlocked(type))
        {
            Services.Instance.EventService.EquipHat(_data.hats[(int)type]);
        }
    }

    private void ExecuteScrollRect()
    {
        if (_index == (int)InventoryType.Skin)
        {
            ShowInventory(_data.skins, InventoryType.Skin);
        }
        else if (_index == (int)InventoryType.Hat)
        {
            ShowInventory(_data.hats, InventoryType.Hat);
        }
        else if (_index == (int)InventoryType.Robe)
        {
            ShowInventory(_data.robes, InventoryType.Robe);
        }

        Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
    }
}