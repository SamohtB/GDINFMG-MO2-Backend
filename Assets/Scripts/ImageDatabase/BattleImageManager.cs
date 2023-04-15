using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleImageManager : MonoBehaviour
{
    public static BattleImageManager Instance;

    [SerializeField] private List<Sprite> battleImageData;

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
        Debug.Log($"SpriteName:{battleImageData[0].name } ");
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
}

