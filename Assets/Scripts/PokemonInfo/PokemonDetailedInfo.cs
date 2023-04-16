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
    [SerializeField] private Slider levelSliderData;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [Header("Skill Data Reference")]
    [SerializeField] private GameObject data;


    private List<Pokemon_Stats_Full> levelList;
    private int level = 1;


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
        levelList = new List<Pokemon_Stats_Full>();
    }


    public void AlterDescriptiveData(List<PokemonFull> pokemonData)
    {
        if (pokemonData == null)
            Debug.LogError("Missing Overview Data");

        else
        {

            //Debug.LogWarning("start altering");

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


    public void AlterStatsData (Pokemon_Stats_Full PokemonStatsData)
    {
        if (PokemonStatsData == null)
            Debug.LogError("Missing Overview Data");

        else
        {
            //Do Function that will parse everything
            healthStatsTxt.text = PokemonStatsData.HP.ToString();
            attackStatsTxt.text = PokemonStatsData.ATK.ToString();
            defenseStatsTxt.text = PokemonStatsData.DEF.ToString();
            spAtkStatsTxt.text = PokemonStatsData.SpA.ToString();
            spDefStatsTxt.text = PokemonStatsData.SpD.ToString();
            critRateStatsTxt.text = PokemonStatsData.criticalrate.ToString();
            cooldownReduxStatsTxt.text = PokemonStatsData.cooldownredux.ToString();
            lifeStealStatsTxt.text = PokemonStatsData.lifesteal.ToString();
        }
    }

    public void RegisterLevel(List<Pokemon_Stats_Full> levelData)
    {
        this.levelList = levelData;
        //Set the slider value into first level;
        AlterStatsData(levelData[0]);
        levelSliderData.value = 0;
        level = 1;


    }

    public void AlterSkillData()
    {
        
    }



    public void OnLevelSliderChange()
    {
        //Some Single Pattern that alter Data

        
        int levelIndex = DetermineIndex(levelSliderData.value, 15); //default max level

        if (level != levelIndex + 1 && levelList != null) 
        {
            AlterStatsData(levelList[levelIndex]);
            levelTxt.text = "Level " + (levelIndex + 1).ToString();
            level = levelIndex + 1;
        }
      
        
    }

    public int DetermineIndex(float range, int n)
    {
        float partitionSize = 1f / n;
        int index = (int)Mathf.Floor(range / partitionSize);

        return index;
    }
}
