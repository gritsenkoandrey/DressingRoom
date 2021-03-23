using UnityEngine;
using UnityEngine.UI;

public sealed class UIButtonGetReward : UIBaseInterface
{
    [SerializeField] private Image _image = null;
    [SerializeField] private Text _text = null;
    private GameData _data;

    private void Awake()
    {
        _data = Data.Instance.Game;
    }

    private void Start()
    {
        SetActiveObject(false);
    }

    public void SetActiveObject(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetActiveText(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void ShowInventory(InventoryType type, int index)
    {
        switch (type)
        {
            case InventoryType.Skin:
                _image.sprite = _data.skins[index].sprite;
                break;
            case InventoryType.Hat:
                _image.sprite = _data.hats[index].sprite;
                break;
            case InventoryType.Robe:
                _image.sprite = _data.robes[index].sprite;
                break;
        }
    }

    public void ShowMoney()
    {
        _image.sprite = _data.money;
        SetActiveText(true);
    }
}