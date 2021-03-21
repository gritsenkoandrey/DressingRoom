using UnityEngine;

public sealed class ScreenFactory
{
    private readonly Canvas _canvas;

    private ShopMenu _shopMenu;
    private RouletteMenu _rouletteMenu;

    public ScreenFactory()
    {
        var resources = CustomResources.Load<Canvas>(AssetsPathScreen.GameObjects[ScreenType.Canvas]);
        _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
    }

    public ShopMenu GetShopMenu()
    {
        if (_shopMenu == null)
        {
            var resources =
                CustomResources.Load<ShopMenu>(AssetsPathScreen.GameObjects[ScreenType.ShopMenu]);
            _shopMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _shopMenu;
    }

    public RouletteMenu GetRouletteMenu()
    {
        if (_rouletteMenu == null)
        {
            var resources =
                CustomResources.Load<RouletteMenu>(AssetsPathScreen.GameObjects[ScreenType.RouletteMenu]);
            _rouletteMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity,
                _canvas.transform);
        }

        return _rouletteMenu;
    }
}