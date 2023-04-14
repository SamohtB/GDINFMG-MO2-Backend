using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonImageData : MonoBehaviour
{
    [SerializeField] private string pokemonName;


    public void OnRegisterName(string name)
    {
        pokemonName = name;
        if (this.gameObject.GetComponent<Image>() == null)
            Debug.LogError("No Image Component Found");

        else
        {
            this.gameObject.GetComponent<Image>().sprite = PokemonImageManager.Instance.RetrieveSprite(name);
        }

    }


    //For Event Trigger Point Click
    public void OnClickPokemonDetail()
    {
        //Call Some WebAPI Request
         //Argument (name)

        MainUIBehaviour.instance.OnSwitchPokemonDetail();
        
    }

    
}
