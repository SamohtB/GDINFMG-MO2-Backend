using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PokemonImageManager : MonoBehaviour
{
    PokemonImageManager Instance;

    [SerializeField] private List<Sprite> data;


    //DictionaryData
    private Dictionary<string, Sprite> spriteDictionary;


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
        Debug.Log($"SpriteName:{data[0].name } ");
        spriteDictionary = new Dictionary<string, Sprite>();
        RegisterAllSprite();
    }

    private void RegisterImage(string keyName, Sprite refImage)
    {
        if (keyName == "" || refImage == null)
            Debug.LogError("Missing Data Input on Pokemon Image Manager");

        else
        {
            spriteDictionary.Add(keyName, refImage);
            //Debug.Log("Success");
        }
    }

    private void RegisterAllSprite()
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
}
