using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class All_Pokemon_Query
{
    public List<List<Pokemon>> All_Pokemon;
    public List<List<ColumnDefinition>> All_ColumnDefinitions;
}

public class Pokemon
{
    public int pokemonid;
    public string name;
    public SpriteData sprite;
}

public class SpriteData
{
    public string type;
    public byte[] data;
}

public class ColumnDefinition
{
    public string name;
    public string type;
}

public class WebAPI : MonoBehaviour
{
    public string BaseURL
    {
        get
        {
            return "https://gdinfmg-pokemon-db.onrender.com";
        }
    }

    public static WebAPI Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }


    

    //Pre-Loading
    public IEnumerator GetAllPokemon()
    {

        Dictionary<string, object> charaterData = new Dictionary<string, object>();

        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Pokemon", "GET"))
        {
            //Debug.Log((BaseURL + $"/{level.ToString()}"));
            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");


               All_Pokemon_Query Query_List = JsonConvert.
                   DeserializeObject<All_Pokemon_Query>(request.downloadHandler.text);

                foreach (List<Pokemon> pokemonList in Query_List.All_Pokemon)
                {
                    foreach (Pokemon pokemon in pokemonList)
                    {
                        //Debug.Log("Pokemon ID: " + pokemon.pokemonid);
                        //Debug.Log("Pokemon Name: " + pokemon.name);
                        PokemonImageManager.Instance.RegisterDictionary(pokemon.pokemonid, pokemon.name);
                    }
                }


            }

            //If No Data Found
            else
            {

            }

            MainUIBehaviour.instance.SpawnDefaultPokemon();
        }
    }
            // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAllPokemon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
