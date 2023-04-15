using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;


public class One_Pokemon : MonoBehaviour
{
    private class PokemonData
    {
        public List<Pokemon> pokemon;
        public List<List<Pokemon_Stats>> stats;
        public List<List<Pokemon_Skill>> skills;
    }

    private class Pokemon
    {
        public int pokemonid;
        public string name;
        public SpriteData sprite;
        public string attacktype;
        public string attackstyle;
        public string role;
        public string complexity;
    }
    private class Pokemon_Stats
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
    private class Pokemon_Skill
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

    public string BaseURL
    {
        get
        {
            return "https://gdinfmg-pokemon-db.onrender.com";
        }
    }

    public static One_Pokemon Instance
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
    public IEnumerator GetOnePokemon()
    {

        Dictionary<string, object> charaterData = new Dictionary<string, object>();

        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Pokemon/1", "GET"))
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


               PokemonData Query_List = JsonConvert.
                   DeserializeObject<PokemonData>(request.downloadHandler.text);

               foreach (Pokemon pokemon in Query_List.pokemon)
               {
                    Debug.Log(Query_List.pokemon[0].name);
                    Debug.Log(Query_List.stats[0][0].level);//has 1-15 levels
                    Debug.Log(Query_List.skills[0][0].name);//has upto hawmany skill they have
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
        StartCoroutine(GetOnePokemon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
