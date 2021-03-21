using UnityEngine;
using UnityEngine.UI;

public sealed class ShopMenu : BaseUI
{
    [SerializeField] private Button _rouletteButton = null;

    [SerializeField] private Button _skinButton = null;
    [SerializeField] private Button _hatButton = null;
    [SerializeField] private Button _robeButton = null;

    [SerializeField] private Button[] _itemButton = null;

    private void OnEnable()
    {
        _rouletteButton.onClick.AddListener(ShowRouletteMenu);

        _skinButton.onClick.AddListener(ShowSkinShop);
        _hatButton.onClick.AddListener(ShowHatShop);
        _robeButton.onClick.AddListener(ShowRobeShop);

        _itemButton[0].onClick.AddListener(ButtonOne);
        _itemButton[1].onClick.AddListener(ButtonTwo);
        _itemButton[2].onClick.AddListener(ButtonThree);
        _itemButton[3].onClick.AddListener(ButtonFour);
    }

    private void OnDisable()
    {
        _rouletteButton.onClick.RemoveListener(ShowRouletteMenu);

        _skinButton.onClick.RemoveListener(ShowSkinShop);
        _hatButton.onClick.RemoveListener(ShowHatShop);
        _robeButton.onClick.RemoveListener(ShowRobeShop);

        _itemButton[0].onClick.RemoveListener(ButtonOne);
        _itemButton[1].onClick.RemoveListener(ButtonTwo);
        _itemButton[2].onClick.RemoveListener(ButtonThree);
        _itemButton[3].onClick.RemoveListener(ButtonFour);
    }

    private void Start()
    {
        data.LoadClothing();
        data.SetValueMoney();

        uInterface.ShowMoney.Text = data.GetValueMoney();
    }

    private void ButtonOne()
    {
        uInterface.ScrollRect.ButtonItem(0);
    }
    private void ButtonTwo()
    {
        uInterface.ScrollRect.ButtonItem(1);
    }
    private void ButtonThree()
    {
        uInterface.ScrollRect.ButtonItem(2);
    }

    private void ButtonFour()
    {
        uInterface.ScrollRect.ButtonItem(3);
    }

    private void ShowRouletteMenu()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.RouletteMenu);
    }

    private void ShowSkinShop()
    {
        InactiveButton();
        _skinButton.image.sprite = data.activeButton;
        uInterface.ScrollRect.ShowInventory(data.skins, InventoryType.Skin);
    }

    private void ShowHatShop()
    {
        InactiveButton();
        _hatButton.image.sprite = data.activeButton;
        uInterface.ScrollRect.ShowInventory(data.hats, InventoryType.Hat);
    }

    private void ShowRobeShop()
    {
        InactiveButton();
        _robeButton.image.sprite = data.activeButton;
        uInterface.ScrollRect.ShowInventory(data.robes, InventoryType.Robe);
    }

    private void InactiveButton()
    {
        _skinButton.image.sprite = data.inactiveButton;
        _hatButton.image.sprite = data.inactiveButton;
        _robeButton.image.sprite = data.inactiveButton;
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}