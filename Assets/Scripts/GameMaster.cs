//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Networking;
//using Newtonsoft.Json;
//using System.Text;

//public class GameMaster : MonoBehaviour
//{
//    [SerializeField] PlayerCharacter player;
//    [SerializeField] Character enemy;
//    [SerializeField] Button combatBtn;
//    [SerializeField] ResultController results;

//    const int WINNER_XP = 100;
//    const int LOSER_XP = 50;

//    int lastLevelDefeated = 2;

//    bool hasEnemyLoaded;

//    public string BaseURL
//    {
//        get
//        {
//            return "https://gdapdev-web-api.herokuapp.com/api/greatjar";
//        }
//    }

//    public static GameMaster Instance
//    {
//        get;  private set;
//    }

//    public bool IsInCombat
//    {
//        get; private set;
//    }

//    private void Awake()
//    {
//        if (Instance == null)
//            Instance = this;
//        else
//            Destroy(this);
//    }

//    private void Start()
//    {
//        hasEnemyLoaded = false;
//        combatBtn.interactable = false;
//        string name = PlayerPrefs.GetString("player_name");
//        player.SetCharacterStats(new CharacterStats(name));
//        SendEnemyGetRequest();
//    }

//    public void ResetCombat()
//    {
//        player.SetCharacterStats(player.GetCharacterStats());
//        if (!hasEnemyLoaded)
//            SendEnemyGetRequest();
//    }

//    public void StartCombat()
//    {
//        ResetCombat();
//        IsInCombat = true;
//        combatBtn.interactable = false;
//    }

//    public void EndCombat(bool isPlayerWinner)
//    {
//        IsInCombat = false;
//        if (isPlayerWinner)
//        {
//            // If player wins
//            lastLevelDefeated += 1;
//            // Handle result

//            if (player.GetCurHP() >= player.GetCharacterStats().GetHP() * 0.5)
//            {
//                // Overwhelming Victory
//                results.DisplayResult(CombatResult.VICTORY_OVERWHELM);
//                // Adds two levels above the player's current level (after levelling up)
//                lastLevelDefeated = player.GetCharacterStats().level + 3;
//            }
//            else
//            {
//                // Regular Victory
//                results.DisplayResult(CombatResult.VICTORY);
//                hasEnemyLoaded = false;
//                if (!player.IsAwardedExp(WINNER_XP))
//                    ResetCombat();
//            }

//            // Upload player data
//            if (player.objectId == "")
//            {
//                // TODO: send a POST request to send the player name and stats. Then assign returned objectID to this player's objectID property
//                StartCoroutine(UploadNewPlayerData(player));
//            }
//            else
//            {
//                // TODO: using the existing objectID, send a PATCH request to update the player stats.

//                StartCoroutine(PatchPlayerData(player));
//            }
//        }
//        else
//        {
//            // If player loses
//            if (enemy.objectId != "")
//            {
//                string objId = enemy.objectId;
//                // If the player lost to a champion from the leaderboard
//                // TODO: send a POST request to increment the victory count of that champion

//                //My Task create a IEnumerator for victory

//                StartCoroutine(PostIncrementVictoryPlayerData(objId));


//            }
//            results.DisplayResult(CombatResult.DEFEAT);
//            hasEnemyLoaded = false;
//            if (!player.IsAwardedExp(LOSER_XP))
//                ResetCombat();
//        }
//    }

//    public void SendEnemyGetRequest()
//    {
//        enemy.SetLabelsToLoading();
//        StartCoroutine(GetEnemyStatsCoroutine(lastLevelDefeated));
//    }

//    /// <summary>
//    /// Coroutine that sends a GET request to get an enemy profile from the database, which matches the specified level. 
//    /// Once data is retrieved, the stats are assigned to the enemy via `SetCharacterStats(CharacterStats)`, and combatBtn is set to be interactable.
//    /// If no matches are found, a basic Character is returned by the API instead, named "Unknown Champion". This Champion will not have an object ID as it does not exist in the database.
//    /// </summary>
//    /// <param name="level"></param>
//    /// <returns></returns>
//    IEnumerator GetEnemyStatsCoroutine(int level)
//    {
//        // TODO: send a GET request to get an enemy profile from the database. Once data is retrieved
//        // Hint 1 : Use Dictionary<string, object> for different datatypes
//        // Hint 2 : For downloaded data, use Convert.ToString(x) / Convert.ToInt32(x) to convert from object to string / integer

//        //4
//        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/{level.ToString()}", "GET"))
//        {
//            Debug.Log((BaseURL + $"/{level.ToString()}"));
//            request.downloadHandler = new DownloadHandlerBuffer();

//            Debug.Log("Sending got request.....");
//            yield return request.SendWebRequest();

//            Debug.Log($"Get all players response code: {request.responseCode}");

//            //Check if have errors;
//            if (string.IsNullOrEmpty(request.error))
//            {
//                Debug.Log($"Message: {request.downloadHandler.text}");
              

//                Dictionary<string, object> championData = JsonConvert.
//                   DeserializeObject<Dictionary<string, object>>(request.downloadHandler.text);

//                string enemName = championData["name"].ToString();

//                Debug.Log($"Message: Find Enemy{championData["level"].GetType()}");
                
//                int enemLevel = System.Convert.ToInt32(championData["level"]);
//                int enemHp = System.Convert.ToInt32(championData["hp"]);
//                int enemStr = System.Convert.ToInt32(championData["str"]);
//                int enemDex = System.Convert.ToInt32(championData["dex"]);


//                CharacterStats enemyStats = new CharacterStats(enemName, enemLevel, enemHp, enemStr, enemDex);
//                enemy.SetCharacterStats(enemyStats);
//                enemy.objectId = championData["objectId"].ToString();

//            }

//            //If No Data Found
//            else
//            {

//            }


//        }

//        //throw new NotImplementedException();

//        combatBtn.interactable = true;
//        hasEnemyLoaded = true;

//        yield return null;
//    }

//    public void OnPlayerSelectMercy()
//    {
//        hasEnemyLoaded = false;
//        if (!player.IsAwardedExp(WINNER_XP))
//            ResetCombat();
//    }

//    public void SendEnemyVanquishDeleteRequest()
//    {
//        if (enemy.objectId == "")
//        {
//            hasEnemyLoaded = false;
//            if (!player.IsAwardedExp(WINNER_XP))
//                ResetCombat();
//        }
//        else
//        {
//            StartCoroutine(VanquishEnemyCoroutine(enemy.objectId));
//        }
//    }

//    IEnumerator VanquishEnemyCoroutine(string objectId)
//    {
//        // TODO: send a DELETE request that would vanquish the current enemy with the given objectId. If the enemy does not have an object Id (i.e., unknown champion), do nothing.
//        // Hint: Use Dictionary<string, object> for different datatypes

//        //5

//        Dictionary<string, object> charaterData = new Dictionary<string, object>();

//        charaterData.Add("objId", objectId);


//        //Turns dictionary into a JSON String
//        string requestString = JsonConvert.SerializeObject(charaterData);

//        //Convert the string into bytes
//        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


//        using (UnityWebRequest request = new UnityWebRequest(BaseURL, "POST"))
//        {
//            request.SetRequestHeader("Content-Type", "application/json");

//            request.uploadHandler = new UploadHandlerRaw(requestData);

//            request.downloadHandler = new DownloadHandlerBuffer();

//            yield return request.SendWebRequest();

//            Debug.Log($"Response Code: {request.responseCode}");

//            //Check if have errors;
//            if (string.IsNullOrEmpty(request.error))
//            {
//                Debug.Log($"Message: {request.downloadHandler.text}");
//            }

//            else
//            {
//                Debug.LogError($"Error: {request.error}");
//            }


//        }




//        // After everything has been processed successfully:
//        hasEnemyLoaded = false;
//        if (!player.IsAwardedExp(WINNER_XP))
//            ResetCombat();

//        //throw new NotImplementedException();
//        yield return null;

//    }


//    IEnumerator UploadNewPlayerData(PlayerCharacter playerData)
//    {
//        CharacterStats characterUploadData = playerData.GetCharacterStats();

//        //Dictionary to contain the parameters to create a player;
//        Dictionary<string, object> charaterData = new Dictionary<string, object>();

//        charaterData.Add("name", characterUploadData.GetName());
//        charaterData.Add("level", characterUploadData.GetLevel());
//        charaterData.Add("hp", characterUploadData.GetHP());
//        charaterData.Add("str", characterUploadData.GetSTR());
//        charaterData.Add("dex", characterUploadData.GetDEX());


//        //Turns dictionary into a JSON String
//        string requestString = JsonConvert.SerializeObject(charaterData);
       
//        //Convert the string into bytes
//        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


//        using (UnityWebRequest request = new UnityWebRequest(BaseURL, "POST"))
//        {
//            request.SetRequestHeader("Content-Type", "application/json");

//            request.uploadHandler = new UploadHandlerRaw(requestData);

//            request.downloadHandler = new DownloadHandlerBuffer();

//            yield return request.SendWebRequest();

//            Debug.Log($"Response Code: {request.responseCode}");

//            //Check if have errors;
//            if (string.IsNullOrEmpty(request.error))
//            {
//                Debug.Log($"Message: {request.downloadHandler.text}");
//            }

//            else
//            {
//                Debug.LogError($"Error: {request.error}");
//            }

//            //request
//           Dictionary<string, object> championData = JsonConvert.
//                   DeserializeObject<Dictionary<string, object>>(request.downloadHandler.text);


//            Debug.Log($"New ID: {championData["objectId"].ToString()}");
//            playerData.objectId = championData["objectId"].ToString();


//        }


        



//        //throw new NotImplementedException();
//        yield return null;
//    }


//    IEnumerator PatchPlayerData(Character characterProfileData)
//    {

//        //Dictionary to contain the parameters to create a player;
//        string objID = characterProfileData.objectId;
//        CharacterStats characterUploadData = characterProfileData.GetCharacterStats();

//        Dictionary<string, object> charaterData = new Dictionary<string, object>();

//        charaterData.Add("objectId", objID);
//        charaterData.Add("level", characterUploadData.GetLevel());
//        charaterData.Add("hp", characterUploadData.GetHP());
//        charaterData.Add("str", characterUploadData.GetSTR());
//        charaterData.Add("dex", characterUploadData.GetDEX());


//        //Turns dictionary into a JSON String
//        string requestString = JsonConvert.SerializeObject(charaterData);

//        //Convert the string into bytes
//        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


//        using (UnityWebRequest request = new UnityWebRequest(BaseURL, "PATCH"))
//        {
//            request.SetRequestHeader("Content-Type", "application/json");

//            request.uploadHandler = new UploadHandlerRaw(requestData);

//            request.downloadHandler = new DownloadHandlerBuffer();

//            yield return request.SendWebRequest();

//            Debug.Log($"Response Code: {request.responseCode}");

//            //Check if have errors;
//            if (string.IsNullOrEmpty(request.error))
//            {
//                Debug.Log($"Message: {request.downloadHandler.text}");
//            }

//            else
//            {
//                Debug.LogError($"Error: {request.error}");
//            }


//        }
//        //throw new NotImplementedException();
//        yield return null;
//    }

//    IEnumerator PostIncrementVictoryPlayerData(string objID)
//    {
        

//        Dictionary<string, object> charaterData = new Dictionary<string, object>();

//        charaterData.Add("objectId", objID);


//        //Turns dictionary into a JSON String
//        string requestString = JsonConvert.SerializeObject(charaterData);

//        //Convert the string into bytes
//        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


//        using (UnityWebRequest request = new UnityWebRequest(BaseURL, "POST"))
//        {
//            request.SetRequestHeader("Content-Type", "application/json");

//            request.uploadHandler = new UploadHandlerRaw(requestData);

//            request.downloadHandler = new DownloadHandlerBuffer();

//            yield return request.SendWebRequest();

//            Debug.Log($"Response Code: {request.responseCode}");

//            //Check if have errors;
//            if (string.IsNullOrEmpty(request.error))
//            {
//                Debug.Log($"Message: {request.downloadHandler.text}");
//            }

//            else
//            {
//                Debug.LogError($"Error: {request.error}");
//            }


//        }

//        //throw new NotImplementedException();
//        yield return null;
//    }
//}
