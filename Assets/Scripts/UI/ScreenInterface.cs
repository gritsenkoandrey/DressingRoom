public sealed class ScreenInterface
{
    private BaseUI _currentScreen;

    private readonly ScreenFactory _screenFactory;
    private static ScreenInterface _instance;

    private ScreenInterface()
    {
        _screenFactory = new ScreenFactory();
    }

    public static ScreenInterface GetScreenInterface()
    {
        if (_instance != null)
            return _instance;
        else 
            return _instance = new ScreenInterface();
    }

    public void Execute(ScreenType screenType)
    {
        _currentScreen?.Hide();

        switch (screenType)
        {
            case ScreenType.ShopMenu:
                _currentScreen = _screenFactory.GetShopMenu();
                break;
            case ScreenType.RouletteMenu:
                _currentScreen = _screenFactory.GetRouletteMenu();
                break;
        }

        _currentScreen?.Show();
    }

    public static void CleanScreenInterface()
    {
        _instance = null;
    }
}