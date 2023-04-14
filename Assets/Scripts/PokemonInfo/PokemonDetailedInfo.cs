using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonDetailedInfo : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void AlterDescriptiveData(Dictionary<string, object> PokemonData)
    {
        if (PokemonData == null)
            Debug.LogError("Missing Overview Data");

        else
        {
            //Call Singleton Function that will insert the image
                //PokemonImageManager.Instance.RetrieveSprite("");

            //Do Function that will parse everything = Need The Dictionary method
            headerNameExtension.text = "> ";
            pokemonNameTxt.text = "";
            attackTypeTxt.text = "";
            attackReachTxt.text = "";
            pokemonRoleTxt.text = "";
            complexityTxt.text = "";
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
