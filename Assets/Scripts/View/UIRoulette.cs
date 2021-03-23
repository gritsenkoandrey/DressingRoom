using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIRoulette : UIBaseInterface
{
    private UIButtonGetReward _button;
    private GameData _data;
    private int _numberOfTurns;
    private readonly int _minNumberOfTurn = 20;
    private readonly int _maxNumberOfTurn = 60;
    private int _yourReward;
    private float _speed;

    public bool ICanTurn { get; private set; }

    private void Awake()
    {
        _data = Data.Instance.Game;
        _button = FindObjectOfType<UIButtonGetReward>();
    }

    private void OnEnable()
    {
        Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());

        _button.GetComponent<Button>().onClick.AddListener(GetReward);
    }

    private void OnDisable()
    {
        _button.GetComponent<Button>().onClick.RemoveListener(GetReward);
    }

    private void Start()
    {
        ICanTurn = true;
    }

    public void StartTurn()
    {
        StartCoroutine(TurnTheWheel());
    }

    private IEnumerator TurnTheWheel()
    {
        ICanTurn = false;

        _numberOfTurns = Random.Range(_minNumberOfTurn, _maxNumberOfTurn);
        _speed = 0.01f;

        for (int i = 0; i < _numberOfTurns; i++)
        {
            transform.Rotate(0f, 0f, 18.0f);

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.5f))
            {
                _speed = 0.02f;
            }

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.7f))
            {
                _speed = 0.07f;
            }

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.9f))
            {
                _speed = 0.1f;
            }

            yield return new WaitForSeconds(_speed);
        }

        _yourReward = Mathf.RoundToInt(transform.eulerAngles.z);
        ShowReward(_yourReward);
        _button.gameObject.SetActive(true);
    }

    private void GetReward()
    {
        _button.SetActiveObject(false);
        _button.SetActiveText(false);
        ICanTurn = true;
    }

    private void ShowReward(int reward)
    {
        var index = Random.Range(0, _data.GetAmountClothing());
        Services.Instance.EventService.UpdateItems();

        switch (reward)
        {
            case 0:
            case 18:
                Services.Instance.EventService.RewardItem(InventoryType.Skin, index);
                break;
            case 36:
            case 54:
            case 72:
            case 90:
                Services.Instance.EventService.RewardItem(InventoryType.Robe, index);
                break;
            case 108:
            case 126:
            case 144:
                Services.Instance.EventService.RewardItem(InventoryType.Hat, index);
                break;
            case 162:
            case 180:
            case 198:
            case 216:
            case 234:
            case 252:
            case 270:
            case 288:
            case 306:
            case 324:
                Services.Instance.EventService.RewardMoney();
                break;
            case 342:
                Services.Instance.EventService.RewardItem(InventoryType.Skin, index);
                break;
        }
    }
}