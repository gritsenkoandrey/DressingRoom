using UnityEngine;
using UnityEngine.UI;

public sealed class RouletteMenu : BaseUI
{
    [SerializeField] private Button _shopButton = null;
    [SerializeField] private Button _startTurnButton = null;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(ShowShopMenu);
        _startTurnButton.onClick.AddListener(StartTurn);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(ShowShopMenu);
        _startTurnButton.onClick.RemoveListener(StartTurn);
    }

    private void Start()
    {
        data.SetSpinCount();

        uInterface.ShowMoney.Text = data.GetValueMoney();
        uInterface.ShowSpin.Text = data.GetSpinCount();
    }

    private void ShowShopMenu()
    {
        if (uInterface.Roulette.ICanTurn)
        {
            ScreenInterface.GetScreenInterface().Execute(ScreenType.ShopMenu);
        }
    }

    private void StartTurn()
    {
        if (uInterface.Roulette.ICanTurn && data.ICanSpinWheel())
        {
            data.SpendSpin(costOneSpin);
            uInterface.ShowSpin.Text = data.GetSpinCount();
            uInterface.Roulette.StartTurn();
        }
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