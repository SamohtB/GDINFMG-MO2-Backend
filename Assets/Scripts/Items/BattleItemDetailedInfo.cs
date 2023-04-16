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

    public void AlterDescriptiveData(Battle_Item_Specific battleItemData)
    {
        if (battleItemData == null)
            Debug.LogError("Missing Battle Item Data");

        else
        {
            //Header Change
            headerBattleItemNameTxt.text = battleItemData.name;
            //Call Singleton Function that will insert the image
            battleItemImage.sprite = BattleImageManager.Instance.RetrieveSprite(battleItemData.battleid); 


            //Do Function that will parse everything = Need The Dictionary method
            cooldownTxt.text = battleItemData.cooldown.ToString() + "s";
            flavorText.text = battleItemData.description;
        }
    }


}
