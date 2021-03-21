using System;

public class Services
{
    private static readonly Lazy<Services> _instance = new Lazy<Services>();

    public Services()
    {
        Initialize();
    }

    public static Services Instance => _instance.Value;
    public EventService EventService { get; private set; }

    private void Initialize()
    {
        EventService = new EventService();
    }
}