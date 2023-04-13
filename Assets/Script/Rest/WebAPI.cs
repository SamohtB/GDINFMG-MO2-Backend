using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class WebAPI : MonoBehaviour
{
    public readonly string BaseURL = "https://gdapdev-web-api.herokuapp.com/api/";

    

   public void CreatePlayer()
    {
        StartCoroutine(SamplePostRequest());
    }

    IEnumerator SamplePostRequest() {

        //Dictionary to contain the parameters to create a player;
        Dictionary<string, object> PlayerParams = new Dictionary<string, object>();

        PlayerParams.Add("nickname", "Name3");
        PlayerParams.Add("name", "Name SeconName3");
        PlayerParams.Add("email", "Name.email.com");
        PlayerParams.Add("contact", "09091234123");

        //Turns dictionary into a JSON String
        string requestString = JsonConvert.SerializeObject(PlayerParams);
        //JsonConvert.ToString(PlayerParams["s"]);
        //Convert the string into bytes
        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "players", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.uploadHandler = new UploadHandlerRaw(requestData);

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log($"Response Code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");
            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }

    }

    public void GetPlayers()
    {
        StartCoroutine(SampleGetPlayersRequest());
    }

    IEnumerator SampleGetPlayersRequest()
    {
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "players" , "GET"))
        {

            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");

                List<Dictionary<string, string>> playerList = JsonConvert.
                   DeserializeObject <List<Dictionary<string, string>>> (request.downloadHandler.text);

                foreach(Dictionary<string, string> player in playerList) {

                    Debug.Log($"Got Player: {player["nickname"]}");
                } 
               

            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }

        
    }



    public void GetPlayerOne()
    {
        StartCoroutine(SampleGetPlayerRequest(1));
    }

    IEnumerator SampleGetPlayerRequest(int id)
    {
        //Get the request at the specific ID    
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "players" + id.ToString(), "GET"))
        {

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log($"GET all players.response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");

                Dictionary<string, string> player = JsonConvert.
                    DeserializeObject<Dictionary<string, string>>(request.downloadHandler.text);

                Debug.Log($"Got Player: {player["nickname"]}");

            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }

        yield return null;
    }


    // ==== For Submission ========== //

    public void CreateGroup()
    {
        StartCoroutine(CreateGroupPostRequest());
    }

    IEnumerator CreateGroupPostRequest()
    {

        //Dictionary to contain the parameters to create a player;
        Dictionary<string, dynamic> PlayerParams = new Dictionary<string, dynamic>();

        PlayerParams.Add("group_num", 103);
        PlayerParams.Add("group_name", "X22_Space_L03");
        PlayerParams.Add("game_name", "Dynamite Sniper Zone");
        PlayerParams.Add("secret", "L_03");

        //Turns dictionary into a JSON String

        string requestString = JsonConvert.SerializeObject(PlayerParams);

        //Convert the string into bytes
        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "groups", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.uploadHandler = new UploadHandlerRaw(requestData);

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log($"Response Code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");
            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }

    }

    public void SendScore() //add arguments later (number, Name, score)
    {
        StartCoroutine(SendScorePostRequest());
    }

    IEnumerator SendScorePostRequest()
    {




        //Dictionary to contain the parameters to create a player;
        Dictionary<string, dynamic> PlayerParams = new Dictionary<string, dynamic>();

        PlayerParams.Add("group_num", 101);
        PlayerParams.Add("user_name", "Dummy");
        PlayerParams.Add("score", 0);
       

        //Turns dictionary into a JSON String

        string requestString = JsonConvert.SerializeObject(PlayerParams);

        //Convert the string into bytes
        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.uploadHandler = new UploadHandlerRaw(requestData);

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log($"Response Code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");
            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }

    }

    public void GetAllPlayerScores()
    {
        StartCoroutine(SamplePlayersScoreRequest(101));
    }

    IEnumerator SamplePlayersScoreRequest(int groupID)
    {
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "groups/" + groupID.ToString(), "GET"))
        {

            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");

                List<Dictionary<string, dynamic>> playerList = JsonConvert.
                   DeserializeObject<List<Dictionary<string, dynamic>>>(request.downloadHandler.text);

                foreach (Dictionary<string, dynamic> player in playerList)
                {

                    Debug.Log($"Got Player: {player["user_name"]}");
                    Debug.Log($"Got Player: {player["score"]}");
                }


            }   

            else
            {
                Debug.LogError($"Error: {request.error}");
            }


        }


    }

    public void ResetAllPlayerScores()
    {
        StartCoroutine(ResetPlayerScoreRequest());
    }

    IEnumerator ResetPlayerScoreRequest()
    {
        //Dictionary to contain the parameters to create a player;
        Dictionary<string, dynamic> PlayerParams = new Dictionary<string, dynamic>();

        PlayerParams.Add("group_num", 60);
        PlayerParams.Add("secret", "test01");

        //Turns dictionary into a JSON String

        string requestString = JsonConvert.SerializeObject(PlayerParams);

        //Convert the string into bytes
        byte[] requestData = Encoding.UTF8.GetBytes(requestString);


        using (UnityWebRequest request = new UnityWebRequest(BaseURL + "scores", "DELETE"))

        {
            request.SetRequestHeader("Content-Type", "application/json");

            request.uploadHandler = new UploadHandlerRaw(requestData);

            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            Debug.Log($"Response Code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");
            }

            else
            {
                Debug.LogError($"Error: {request.error}");
            }

        }
    }


}
