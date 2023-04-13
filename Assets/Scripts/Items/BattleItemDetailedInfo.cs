using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleItemDetailedInfo : MonoBehaviour
{
    [Header("Detailed Info")]
    [SerializeField] private TextMeshProUGUI headerBattleItemNameTxt;
    [SerializeField] private Image battleItemImage;
    [SerializeField] private TextMeshProUGUI cooldownTxt;
    [SerializeField] private TextMeshProUGUI flavorText;

    public void AlterDescriptiveData(Dictionary<string, object> BattleItemData)
    {
        if (BattleItemData == null)
            Debug.LogError("Missing Battle Item Data");

        else
        {
            //Header Change
            headerBattleItemNameTxt.text = "";
            //Call Singleton Function that will insert the image

            //Do Function that will parse everything = Need The Dictionary method
            cooldownTxt.text = "" + "s";
            flavorText.text = "";
        }
    }


}
