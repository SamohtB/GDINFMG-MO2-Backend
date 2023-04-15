using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonDetailedInfo : MonoBehaviour
{

    public static PokemonDetailedInfo instance;

    [Header("Pokkemon Descriptive Data")]
    [SerializeField] private TextMeshProUGUI headerNameExtension;
    [SerializeField] private Image PokemonImage;
    [SerializeField] private TextMeshProUGUI pokemonNameTxt;
    [SerializeField] private TextMeshProUGUI attackTypeTxt;
    [SerializeField] private TextMeshProUGUI attackReachTxt;
    [SerializeField] private TextMeshProUGUI pokemonRoleTxt;
    [SerializeField] private TextMeshProUGUI complexityTxt;

    [Header("Pokkemon Stats Data")]
    [SerializeField] private TextMeshProUGUI healthStatsTxt;
    [SerializeField] private TextMeshProUGUI attackStatsTxt;
    [SerializeField] private TextMeshProUGUI defenseStatsTxt;
    [SerializeField] private TextMeshProUGUI spAtkStatsTxt;
    [SerializeField] private TextMeshProUGUI spDefStatsTxt;
    [SerializeField] private TextMeshProUGUI critRateStatsTxt;
    [SerializeField] private TextMeshProUGUI cooldownReduxStatsTxt;
    [SerializeField] private TextMeshProUGUI lifeStealStatsTxt;
    [SerializeField] private TextMeshProUGUI atkSpeedStatsTxt;
    [SerializeField] private Slider levelSliderData;

    [Header("Skill Data Reference")]
    [SerializeField] private GameObject data;


    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void AlterDescriptiveData(List<PokemonFull> pokemonData)
    {
        if (pokemonData == null)
            Debug.LogError("Missing Overview Data");

        else
        {

            //Call Singleton Function that will insert the image
            PokemonImage.sprite = PokemonImageManager.Instance.RetrieveSprite(pokemonData[0].name);


            //Do Function that will parse everything = Need The Dictionary method
            headerNameExtension.text = $"> {  pokemonData[0].name}";
            pokemonNameTxt.text = pokemonData[0].name;
            attackTypeTxt.text = pokemonData[0].attacktype;
            attackReachTxt.text = pokemonData[0].attackstyle;
            pokemonRoleTxt.text = pokemonData[0].role;
            complexityTxt.text = pokemonData[0].complexity;
        }
    }


    public void AlterStatsData (Dictionary<string, object> PokemonStatsData)
    {
        if (PokemonStatsData == null)
            Debug.LogError("Missing Overview Data");

        else
        {
            //Call Singleton Function that will insert the image

            //Do Function that will parse everything
            healthStatsTxt.text = "";
            attackStatsTxt.text = "";
            defenseStatsTxt.text = "";
            spAtkStatsTxt.text = "";
            spDefStatsTxt.text = "";
            critRateStatsTxt.text = "";
            cooldownReduxStatsTxt.text = "";
            lifeStealStatsTxt.text = "";
            atkSpeedStatsTxt.text = "";
        }
    }

    public void AlterSkillData()
    {
        
    }



    public void OnLevelSliderChange(float level)
    {
        //Some Single Pattern that alter Data
    }
}
