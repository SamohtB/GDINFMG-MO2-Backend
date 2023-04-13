using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEmblemImageData : MonoBehaviour
{
    [SerializeField] private string boostEmblemName;


    public void OnRegisterName(string name)
    {
        boostEmblemName = name;
    }


    //For Event Trigger Point Click
    public void OnClick()
    {
        //Do SomeSinglePattern that reference the pokemon name
    }
}
