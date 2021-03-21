using UnityEngine;
using UnityEngine.UI;

public sealed class UIShowMoney : UIBaseInterface
{
    private Text _text;

    public int Text { set { _text.text = $"{value}"; } }

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        Services.Instance.EventService.OnUpdateAmountMoney += UpdateAmountMoney;
    }

    private void OnDisable()
    {
        Services.Instance.EventService.OnUpdateAmountMoney -= UpdateAmountMoney;
    }

    private void UpdateAmountMoney(int value)
    {
        _text.text = $"{value}";
    }
}