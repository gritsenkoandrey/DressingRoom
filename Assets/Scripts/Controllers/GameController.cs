using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private void Start()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.ShopMenu);
    }
}