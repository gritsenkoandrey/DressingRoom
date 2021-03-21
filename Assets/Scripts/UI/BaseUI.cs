using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected readonly int costOneSpin = 1;

    protected GameData data;
    protected UInterface uInterface;

    private void Awake()
    {
        data = Data.Instance.Character;
        uInterface = new UInterface();
    }

    public abstract void Show();
    public abstract void Hide();
}