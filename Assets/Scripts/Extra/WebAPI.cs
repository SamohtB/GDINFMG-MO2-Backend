using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class WebAPI : MonoBehaviour
{
    public string BaseURL
    {
        get
        {
            return "localhost:3000";
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


    IEnumerator GetAllPokemon()
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


               List<object> pokemonList = JsonConvert.
                   DeserializeObject<List<object>>(request.downloadHandler.text);
                int i = 0;
                foreach (object pokemon in pokemonList)
                {
                    Debug.Log($"Pokemon name: {pokemon.ToString()}");
                    
                }

            }

            //If No Data Found
            else
            {

            }
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
