using UnityEngine.UI;

public sealed class UIShowSpin : UIBaseInterface
{
    private Text _spinCount;

    public int Text { set { _spinCount.text = $"{value}"; } }

    private void Awake()
    {
        _spinCount = GetComponent<Text>();
    }
}