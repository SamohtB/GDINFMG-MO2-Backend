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

    public void AlterDescriptiveData(Dictionary<string, object> HeldItemData1,
        Dictionary<string, object> HeldItemData2, 
        Dictionary<string, object> HeldItemData3)
    {
        if (HeldItemData1 == null || HeldItemData2 == null || HeldItemData3 == null)
            Debug.LogError("Missing Held Item Data");

        else
        {
            //Header Change
            heldItemHeader.text = "";
            //Call Singleton Function that will insert the image
            heldItemImage.sprite = null;

            //Do Function that will parse everything = Need The Dictionary method
            stats1Txt.text = "";
            stats2Txt.text = "";
            flavorText.text = "";
            levelPartitionTxt.text = "1" + " / " + "2" + " / " + "3" + " / ";
        }
    }
}
