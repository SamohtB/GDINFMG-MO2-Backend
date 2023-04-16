using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldImageManager : MonoBehaviour
{
   public static HeldImageManager Instance;

    [SerializeField] private List<Sprite> heldImageData;
    [SerializeField] private Dictionary<int, string> heldDictionary;
    [SerializeField] private Dictionary<string, int> heldNumber;

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
        //Debug.Log($"SpriteName:{heldImageData[0].name } ");
        spriteDictionary = new Dictionary<string, Sprite>();
        heldDictionary = new Dictionary<int, string>();
        heldNumber = new Dictionary<string, int>();

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

    public void RegisterDictionary(int heldId, string value)
    {
        if (heldId != 0 && CheckExistingData(value))
        {
            //Debug.Log($"Id value: {pokemonId}");
            heldDictionary.Add(heldId, value);
            heldNumber.Add(value, heldId);

            allID.Add(heldId);
        }
    }

    private void RegisterAllSprite()
    {
        foreach (Sprite pokemonSprite in heldImageData)
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

    public Sprite RetrieveSprite(int heldId)
    {
        Sprite copySprite = spriteDictionary[heldDictionary[heldId]];

        if (copySprite == null)
        {
            Debug.LogError($"Cannot Find Matching Image: {heldDictionary[heldId]}");
            return null;
        }

        return copySprite;
    }

    public string RetrievePokemonName(int heldId)
    {
        if (heldDictionary[heldId] == null)
        {
            Debug.LogError($"No Name Found: {heldId}");
            return null;
        }

        return heldDictionary[heldId];
    }

    public int RetrievePokemonId(string heldName)
    {
        //Debug.LogWarning(pokemonName);

        if (heldNumber[heldName] == null)
        {
            Debug.LogError($"No Number Found: {heldName}");
            return 0;
        }
        //Debug.LogWarning(pokemonNumber[pokemonName]);
        return heldNumber[heldName];
    }


    //All Data Request
    public Dictionary<int, string> RetrieveAllData()
    {
        return heldDictionary;
    }

    public List<int> RetrieveAllId()
    {
        return allID;
    }

    private bool CheckExistingData(string pokemonName)
    {
        if (internalDataName.Contains(pokemonName))
        {
            return true;
        }

        Debug.Log($"Pokemon that were not found: {pokemonName}");
        return false;
    }
}
