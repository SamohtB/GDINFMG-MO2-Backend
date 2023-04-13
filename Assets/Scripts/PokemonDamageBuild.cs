using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PokemonDamageBuild : MonoBehaviour
{
    [Header("Pokemon Base")]
    [SerializeField] private Image pokemonImage;
    [SerializeField] private TextMeshProUGUI pokemonName;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI buildName;
    [SerializeField] private TextMeshProUGUI levelDescription;


    [Header("Item Information")]
    [SerializeField] private HeldItemImageData hItem1;
    [SerializeField] private HeldItemImageData hItem2;
    [SerializeField] private HeldItemImageData hItem3;
    [SerializeField] private BattleItemImageData bItem1;

    private float pokemonLevel = 1;


    public void OnRegisterName(string name)
    {
        pokemonName.text = name;

        //Some Singleton Function that return sprite;

    }

    public void OnSelectSkill()
    {
        //It supposed to be a dropdown choice to highlight everything
        //Todo = populate the option inside the drop down with all the skills

    }

    public void OnValueChange(float data)
    {
        if (data > 15 && data < 1)
            Debug.LogError("Level Indicate is too much");
    }


    //Function the determine the level of the pokemon based on the slider position
    public int DetermineLevel(float data)
    {

        float partition_size = 1.0f / 15f; 
        int partition_index = (int)(data / partition_size) + 1; 

        return partition_index;
    }




    //For Event Trigger Point Click
    public void OnClick()
    {
        //Do SomeSinglePattern that reference the pokemon name
    }

}
