using System.Collections.Generic;

public sealed class AssetsPathScreen
{
    public static readonly Dictionary<ScreenType, string> GameObjects = new Dictionary<ScreenType, string>
    {
        {
            ScreenType.Canvas, "Prefabs/UI/Canvas"
        },
        {
            ScreenType.ShopMenu, "Prefabs/UI/ShopMenu"
        },
        {
            ScreenType.RouletteMenu, "Prefabs/UI/RouletteMenu"
        }
    };
}