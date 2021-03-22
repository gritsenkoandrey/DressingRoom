using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIRoulette : UIBaseInterface
{
    [SerializeField] private GameObject _rewards = null;
    [SerializeField] private UIButtonGetReward _getReward =null;
    private GameData _data;
    private Sprite _tmpSprite;
    private UIImageReward[] _images;

    private int _numberOfTurns;
    private readonly int _minNumberOfTurn = 20;
    private readonly int _maxNumberOfTurn = 60;
    private int _yourReward;
    private float _speed;

    public bool ICanTurn { get; private set; }

    private void Awake()
    {
        _data = Data.Instance.Game;
        _images = _rewards.GetComponentsInChildren<UIImageReward>();
    }

    private void OnEnable()
    {
        _getReward.GetComponent<Button>().onClick.AddListener(GetReward);

        Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
    }

    private void OnDisable()
    {
        _getReward.GetComponent<Button>().onClick.RemoveListener(GetReward);
    }

    private void Start()
    {
        _getReward.Hide();
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
        _getReward.Show();
    }

    private void GetReward()
    {
        _getReward.Hide();
        ICanTurn = true;
    }

    private void ShowReward(int reward)
    {
        var index = Random.Range(0, _data.GetAmountClothing());
        UpdateItems();

        switch (reward)
        {
            case 0:
            case 18:
                RewardSkin(index);
                break;
            case 36:
            case 54:
            case 72:
            case 90:
                RewardRobe(index);
                break;
            case 108:
            case 126:
            case 144:
                RewardHat(index);
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
                RewardMoney();
                break;
            case 342:
                RewardSkin(index);
                break;
        }
    }

    private void UpdateItems()
    {
        for (int i = _images.Length - 2; i >= 0; i--)
        {
            _tmpSprite = _images[i].GetImage.sprite;
            _images[i + 1].GetImage.sprite = _tmpSprite;
        }
    }

    private void RewardSkin(int index)
    {
        _getReward.Image.sprite = _data.skins[index].sprite;
        if (!_data.SkinIsUnlocked((SkinType)index)) _data.SkinUnlocked((SkinType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.skins[index].sprite;
    }

    private void RewardRobe(int index)
    {
        _getReward.Image.sprite = _data.robes[index].sprite;
        if (!_data.RobeIsUnlocked((RobeType)index)) _data.RobeUnlocked((RobeType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.robes[index].sprite;
    }

    private void RewardHat(int index)
    {
        _getReward.Image.sprite = _data.hats[index].sprite;
        if (!_data.HatIsUnlocked((HatType)index)) _data.HatUnlocked((HatType)index, true);
        else GetMoney();
        _images[0].GetImage.sprite = _data.hats[index].sprite;
    }

    private void RewardMoney()
    {
        _getReward.Image.sprite = _data.money;
        _getReward.Text.gameObject.SetActive(true);
        GetMoney();
        _images[0].GetImage.sprite = _data.money;
    }

    private void GetMoney()
    {
        _data.AddMoney(_data.GetMoney());
        Services.Instance.EventService.UpdateAmountMoney(_data.GetValueMoney());
    }
}