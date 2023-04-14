using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostEmblemDisplayer : MonoBehaviour
{
    [Header("BoostEmblem Displayer")]
    [SerializeField] private TextMeshProUGUI boostEmblemName;
    [SerializeField] private BoostEmblemBreakdown bronzeVariant;
    [SerializeField] private BoostEmblemBreakdown silverVariant;
    [SerializeField] private BoostEmblemBreakdown goldVariant;


    public void OnUpdateBoostEmblems(string emblemName)
    {
        boostEmblemName.text = emblemName;

        //Call the single function to return the intended request
        /*Ex. bronzeVariant.OnRegist*/
        bronzeVariant.OnRegisterName(emblemName);
        silverVariant.OnRegisterName(emblemName);
        goldVariant.OnRegisterName(emblemName);
    }

   
}
