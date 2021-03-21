using UnityEngine;

public sealed class UInterface
{
    private UIScrollRect _scrollRect;
    private UIRoulette _roulette;
    private UICharacter _character;
    private UIShowMoney _showMoney;
    private UIShowSpin _showSpin;

    public UIScrollRect ScrollRect
    {
        get
        {
            if (_scrollRect == null)
            {
                _scrollRect = Object.FindObjectOfType<UIScrollRect>();
            }

            return _scrollRect;
        }
    }

    public UIRoulette Roulette
    {
        get
        {
            if (_roulette == null)
            {
                _roulette = Object.FindObjectOfType<UIRoulette>();
            }

            return _roulette;
        }
    }

    public UICharacter Character
    {
        get
        {
            if (_character == null)
            {
                _character = Object.FindObjectOfType<UICharacter>();
            }

            return _character;
        }
    }

    public UIShowMoney ShowMoney
    {
        get
        {
            if (_showMoney == null)
            {
                _showMoney = Object.FindObjectOfType<UIShowMoney>();
            }

            return _showMoney;
        }
    }

    public UIShowSpin ShowSpin
    {
        get
        {
            if (_showSpin == null)
            {
                _showSpin = Object.FindObjectOfType<UIShowSpin>();
            }

            return _showSpin;
        }
    }
}