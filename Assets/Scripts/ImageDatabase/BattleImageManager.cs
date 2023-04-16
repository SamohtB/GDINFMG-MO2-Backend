using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleImageManager : MonoBehaviour
{
    public static BattleImageManager Instance;

    [SerializeField] private List<Sprite> battleImageData;
    [SerializeField] private Dictionary<int, string> battleDictionary;
    [SerializeField] private Dictionary<string, int> battleNumber;

    //DictionaryData
    private Dictionary<string, Sprite> spriteDictionary;
    private List<string> internalDataName;
    private List<int> allID;


    private void Awake()
    {
        CreateSingleton();

    }

    void CreateSingleton()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"SpriteName:{battleImageData[0].name } ");
        spriteDictionary = new Dictionary<string, Sprite>();
        battleDictionary = new Dictionary<int, string>();
        battleNumber = new Dictionary<string, int>();

        allID = new List<int>();
        internalDataName = new List<string>();

        RegisterAllSprite();
    }

    private void RegisterImage(string keyName, Sprite refImage)
    {
        if (keyName == "" || refImage == null)
            Debug.LogError("Missing Data Input on Pokemon Image Manager");

        else
        {
            spriteDictionary.Add(keyName, refImage);
            internalDataName.Add(keyName);
            //Debug.Log("Success");
        }
    }

    public void RegisterDictionary(int pokemonId, string value)
    {
        if (pokemonId != 0 && CheckExistingData(value))
        {
            //Debug.Log($"Id value: {pokemonId}");
            battleDictionary.Add(pokemonId, value);
            battleNumber.Add(value, pokemonId);

            allID.Add(pokemonId);
        }


    }

    private void RegisterAllSprite()
    {
        foreach (Sprite pokemonSprite in battleImageData)
        {
            RegisterImage(pokemonSprite.name, pokemonSprite);
            //Debug.Log($"Pokemon Name Insert:{pokemonSprite.name}");
        }
    }

    public Sprite RetrieveSprite(string keyName)
    {
        Sprite copySprite = spriteDictionary[keyName];

        if (copySprite == null)
        {
            Debug.LogError("Missing Retrieval Reference Battle  Image");
            return null;
        }

        return copySprite;
    }

    public Sprite RetrieveSprite(int battleId)
    {
        Sprite copySprite = spriteDictionary[battleDictionary[battleId]];

        if (copySprite == null)
        {
            Debug.LogError($"Cannot Find Matching Image: {battleDictionary[battleId]}");
            return null;
        }

        return copySprite;
    }


    public string RetrievePokemonName(int battleId)
    {
        if (battleDictionary[battleId] == null)
        {
            Debug.LogError($"No Name Found: {battleId}");
            return null;
        }

        return battleDictionary[battleId];
    }

    public int RetrievePokemonId(string battleName)
    {
        //Debug.LogWarning(pokemonName);

        if (battleNumber[battleName] == null)
        {
            Debug.LogError($"No Number Found: {battleName}");
            return 0;
        }
        //Debug.LogWarning(pokemonNumber[pokemonName]);
        return battleNumber[battleName];
    }


    //All Data Request
    public Dictionary<int, string> RetrieveAllData()
    {
        return battleDictionary;
    }

    public List<int> RetrieveAllId()
    {
        return allID;
    }

    //Double Checking
    private bool CheckExistingData(string battleName)
    {
        if (internalDataName.Contains(battleName))
        {
            return true;
        }

        Debug.Log($"Pokemon that were not found: {battleName}");
        return false;
    }
}

