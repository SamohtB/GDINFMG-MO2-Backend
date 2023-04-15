using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PokemonImageManager : MonoBehaviour
{
    public static PokemonImageManager Instance;

    [SerializeField] private List<Sprite> data;
    [SerializeField] private Dictionary<int, string> pokemonDictionary;
    [SerializeField] private Dictionary<string, int> pokemonNumber;

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
       
        spriteDictionary = new Dictionary<string, Sprite>();
        pokemonDictionary = new Dictionary<int, string>();
        pokemonNumber = new Dictionary<string, int>();

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
        if(pokemonId != 0 && CheckExistingData(value))
        {
            //Debug.Log($"Id value: {pokemonId}");
            pokemonDictionary.Add(pokemonId, value);
            pokemonNumber.Add(value, pokemonId);

            allID.Add(pokemonId);
        }
       

    }

    public void RegisterAllSprite()
    {
        foreach(Sprite pokemonSprite in data)
        {
            RegisterImage(pokemonSprite.name, pokemonSprite);
        }
    }

    public Sprite RetrieveSprite(string keyName)
    {
        Sprite copySprite = spriteDictionary[keyName];

        if (copySprite == null)
        {
            Debug.LogError("Missing Retrieval Reference Pokemon Image");
            return null;
        }

        return copySprite;
     }

    public Sprite RetrieveSprite(int pokemonId)
    {
        Sprite copySprite = spriteDictionary[pokemonDictionary[pokemonId]];

        if (copySprite == null)
        {
            Debug.LogError($"Cannot Find Matching Image: {pokemonDictionary[pokemonId]}");
            return null;
        }

        return copySprite;
    }

    public string RetrievePokemonName(int pokemonId)
    {
        if(pokemonDictionary[pokemonId] == null)
        {
            Debug.LogError($"No Name Found: {pokemonId}");
            return null;
        }

        return pokemonDictionary[pokemonId];
    }

    public int RetrievePokemonId(string pokemonName)
    {
        Debug.LogWarning(pokemonName);

        if (pokemonNumber[pokemonName] == null)
        {
            Debug.LogError($"No Number Found: {pokemonName}");
            return 0;
        }
        Debug.LogWarning(pokemonNumber[pokemonName]);
        return pokemonNumber[pokemonName];
    }


    //All Data Request
    public Dictionary<int, string> RetrieveAllData()
    {
        return pokemonDictionary;
    }

    public List<int> RetrieveAllId()
    {
        return allID;
    }
    
    //Double Checking
    private bool CheckExistingData(string pokemonName)
    {
        if (internalDataName.Contains(pokemonName)){
            return true;
        }

        Debug.Log($"Pokemon that were not found: {pokemonName}");
        return false;
    }
    
}
