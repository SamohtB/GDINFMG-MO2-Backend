using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class PokemonData_Full
{
    public List<PokemonFull> pokemon;
    public List<List<Pokemon_Stats_Full>> stats;
    public List<List<Pokemon_Skill_Full>> skills;
}

public class PokemonFull
{
    public int pokemonid;
    public string name;
    public SpriteData sprite;
    public string attacktype;
    public string attackstyle;
    public string role;
    public string complexity;
}
public class Pokemon_Stats_Full
{
    public int ownerid;
    public int level;
    public int HP;
    public int ATK;
    public int DEF;
    public int SpA;
    public int SpD;
    public float criticalrate;
    public float cooldownredux;
    public float lifesteal;

}
public class Pokemon_Skill_Full
{
    public int ownerid;
    public string name;
    public string? skilltype;
    public string? skillclass;
    public int levelrequirement;
    public int? cooldown;
    public string skilltext;
    public string? attacktype;
    public float? attackmultiplier;
    public int? basemultiplier;
    public int? basedamage;
}

public class One_Pokemon : MonoBehaviour
{
    [SerializeField] private PokemonDetailedInfo details;

    public string BaseURL
    {
        get
        {
            //return "https://gdinfmg-pokemon-db.onrender.com";
            return "localhost:3000";
        }
    }

    //public static One_Pokemon Instance
    //{
    //    get; private set;
    //}

    //private void Awake()
    //{
    //    if (Instance == null)
    //        Instance = this;
    //    else
    //        Destroy(this);
    //}
    
    //Pre-Loading
    public IEnumerator GetOnePokemon(int val)
    {
       // Debug.Log("name: " + val.ToString());
        //Dictionary<string, object> charaterData = new Dictionary<string, object>();

        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Pokemon/{val}" , "GET"))
        {
            //Debug.Log((BaseURL + $"/{level.ToString()}"));
            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            Debug.Log($"Request Link: {request.url}");
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");


               PokemonData_Full Query_List = JsonConvert.
                   DeserializeObject<PokemonData_Full>(request.downloadHandler.text);

               foreach (PokemonFull pokemon in Query_List.pokemon)
               {
                    Debug.Log(Query_List.pokemon[0].name);
                    Debug.Log(Query_List.stats[0][0].level);//has 1-15 levels
                    Debug.Log(Query_List.skills[0][0].name);//has upto hawmany skill they have

                    //Specific Function Calls
                    Debug.Log($"name: {Query_List.pokemon[0].name}");

                    //if (PokemonDetailedInfo.instance == null)
                    //{
                    //    Debug.LogError("Big Bugs");
                    //}

                    PokemonDetailedInfo.instance.AlterDescriptiveData(Query_List.pokemon);
                    PokemonDetailedInfo.instance.RegisterLevel(Query_List.stats[0]);

               }
            }

            //If No Data Found
            else
            {
                Debug.LogWarning("Empty");
            }

            //Debug.LogWarning("done Processing");

        }


        
        //throw new NotImplementedException();
        yield return null;
    }
            // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetOnePokemon(21));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
