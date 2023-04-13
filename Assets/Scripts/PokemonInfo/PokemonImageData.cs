using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonImageData : MonoBehaviour
{
    [SerializeField] private string pokemonName;


    public void OnRegisterName(string name)
    {
        pokemonName = name;
    }


    //For Event Trigger Point Click
    public void OnClick()
    {
        //Do SomeSinglePattern that reference the pokemon name
    }
}
