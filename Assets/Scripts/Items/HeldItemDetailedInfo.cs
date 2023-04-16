using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HeldItemDetailedInfo : MonoBehaviour
{
    [Header("Detailed Info")]
    [SerializeField] private TextMeshProUGUI heldItemHeader;
    [SerializeField] private Image heldItemImage;
    [SerializeField] private TextMeshProUGUI stats1Txt;
    [SerializeField] private TextMeshProUGUI stats2Txt;
    [SerializeField] private TextMeshProUGUI flavorText;
    [SerializeField] private TextMeshProUGUI levelPartitionTxt;

    public void AlterDescriptiveData(Held_Item_Specific heldItemData)
    {
        if (heldItemData == null)
            Debug.LogError("Missing Held Item Data");

        else
        {
            //Header Change
            heldItemHeader.text = heldItemData.name;

            //Call Singleton Function that will insert the image
            heldItemImage.sprite = HeldImageManager.Instance.RetrieveSprite(heldItemData.heldid);

            //Do Function that will parse everything = Need The Dictionary method
            stats1Txt.text = heldItemData.attrib1type + ": " + heldItemData.attrib1val.ToString();

            if (heldItemData.attrib2type != null)
                stats2Txt.text = heldItemData.attrib2type + ": " + heldItemData.attrib2val.ToString();

            else
                stats2Txt.text = "";

            flavorText.text = heldItemData.description;
            levelPartitionTxt.text = heldItemData.tier1val + "% / " + heldItemData.tier10val + "% / " 
                + heldItemData.tier1val + "% " + heldItemData.tierattributeType;
        }
    }
}
