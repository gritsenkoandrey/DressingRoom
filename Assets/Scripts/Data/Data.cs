using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public sealed class Data : ScriptableObject
{
    [SerializeField] private string _gameDataPath = null;

    private static GameData _gameData;

    private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));

    public static Data Instance => _instance.Value;

    public GameData Game
    {
        get
        {
            if (_gameData == null)
            {
                _gameData = Load<GameData>("Data/" + Instance._gameDataPath);
            }

            return _gameData;
        }
    }

    private static T Load<T>(string resourcesPath) where T : Object =>
        CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}