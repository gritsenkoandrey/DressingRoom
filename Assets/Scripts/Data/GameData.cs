using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int _startValueMoney = 200;
    [SerializeField] private int _itemCost = 100;
    [SerializeField] private int _spinCount = 99;
    [SerializeField] private int _getMoney = 100;
    [SerializeField] private int _amountClothing = 4;

    private int _currentValueMoney;
    private int _currentValueSpin;

    [Header("Character Hat")]
    public Image[] hats;

    [Header("Character Skin")]
    public Image[] skins;

    [Header("Character Robe")]
    public Image[] robes;

    [Header("Character Money")]
    public Sprite money;

    [Header("Button Active")]
    public Sprite activeButton;
    public Sprite inactiveButton;

    private Dictionary<HatType, bool> hat;
    private Dictionary<RobeType, bool> robe;
    private Dictionary<SkinType, bool> skin;

    public int GetValueMoney()
    {
        return _currentValueMoney;
    }

    public void SetValueMoney()
    {
        _currentValueMoney = _startValueMoney;
    }

    public void AddMoney(int value)
    {
        _currentValueMoney += value;
    }

    public void BuyItem()
    {
        _currentValueMoney -= _itemCost;
    }

    public bool ICanBuyItem()
    {
        return _currentValueMoney >= _itemCost == true;
    }

    public int GetSpinCount()
    {
        return _currentValueSpin;
    }

    public void SetSpinCount()
    {
        _currentValueSpin = _spinCount;
    }

    public void SpendSpin(int value)
    {
        _currentValueSpin -= value;
    }

    public bool ICanSpinWheel()
    {
        return _currentValueSpin > 0 == true;
    }

    public int GetAmountClothing()
    {
        return _amountClothing;
    }

    public int GetMoney()
    {
        return _getMoney;
    }

    public void LoadClothing()
    {
        LoadHat();
        LoadRobe();
        LoadSkin();
    }

    public void HatUnlocked(HatType hatType, bool value)
    {
        hat[hatType] = value;
    }

    public void RobeUnlocked(RobeType robeType, bool value)
    {
        robe[robeType] = value;
    }

    public void SkinUnlocked(SkinType skinType, bool value)
    {
        skin[skinType] = value;
    }

    public bool HatIsUnlocked(HatType hatType)
    {
        return hat[hatType] == true;
    }

    public bool RobeIsUnlocked(RobeType robeType)
    {
        return robe[robeType] == true;
    }

    public bool SkinIsUnlocked(SkinType skinType)
    {
        return skin[skinType] == true;
    }

    private void LoadHat()
    {
        hat = new Dictionary<HatType, bool>
        {
            { HatType.HatOne, true },
            { HatType.HatTwo, false },
            { HatType.HatThree, false },
            { HatType.HatFour, false }
        };
    }
    private void LoadRobe()
    {
        robe = new Dictionary<RobeType, bool>
        {
            { RobeType.RobeOne, true },
            { RobeType.RobeTwo, false },
            { RobeType.RobeThree, false },
            { RobeType.RobeFour, false }
        };
    }
    private void LoadSkin()
    {
        skin = new Dictionary<SkinType, bool>
        {
            { SkinType.SkinOne, true },
            { SkinType.SkinTwo, false },
            { SkinType.SkinThree, false },
            { SkinType.SkinFour, false }
        };
    }
}