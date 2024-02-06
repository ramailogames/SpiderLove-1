using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RamailoGames;
using TMPro;
using System.Runtime.InteropServices;
using System;
public class RamailoGamesApiHandler : MonoBehaviour
{

    public static int currentScore = 0;

    public static int highScore = 0;

    string playerHashValue;
    public static event UnityAction OnScoreUpdate;



    [DllImport("__Internal")]
    private static extern string GetParentURL();

    public string myUrl;


    [Header("Domain Check")]
    public GameObject blockUI;

    private void Awake()
    {

    }
    private void Start()
    {
        currentScore = 0;


        //Determine Tournament or not
        Main();

        // Call the JSlib function to get the browser URL
      /*   System.IntPtr urlPtr = GetBrowserURL();
         string url = Marshal.PtrToStringAnsi(urlPtr);
         myUrl = url;
         Debug.Log("Browser URL: " + url);*/



        // Don't forget to free the memory allocated in the JSlib function
        // when you're done using the string in C#
        // Marshal.FreeHGlobal(urlPtr);

    }

    public int ExtractTournamentId(string url)
    {
        // Parse the URL
        Uri uri = new Uri(url);

        // Get the segments from the path
        string[] segments = uri.AbsolutePath.Split('/');

        // Find the index of "tournament" in the path
        int tournamentIndex = Array.IndexOf(segments, "tournament");

        // Check if "tournament" is found and there is a segment after it
        if (tournamentIndex != -1 && tournamentIndex < segments.Length - 1)
        {
            // Attempt to parse the next segment as an integer
            if (int.TryParse(segments[tournamentIndex + 1], out int tournamentId))
            {
                ScoreAPI.instance.tournament_id = tournamentId;
                return tournamentId;
            }
        }

        // Default value or error handling if parsing fails
        return -1;
    }
    public string ExtractUserHashValue(string url)
    {
        // Parse the URL
        Uri uri = new Uri(url);

        // Get the segments from the path
        string[] segments = uri.AbsolutePath.Split('/');

        // Find the index of "user" in the path
        int userIndex = Array.IndexOf(segments, "user");

        // Check if "user" is found and there is a segment after it
        if (userIndex != -1 && userIndex < segments.Length - 1)
        {
            // Return the next segment as the userhashvalue
          
            return segments[userIndex + 1];
        }

        // Default value or error handling if extraction fails
        return null;
    }


    public void Main()
    {
        StartCoroutine(Enum_DeterminTournamentIdAndPlayerHasValue());
    }

    IEnumerator Enum_DeterminTournamentIdAndPlayerHasValue()
    {
        yield return new WaitForEndOfFrame();

        //Determine Tournament or not
        //myUrl = "http://localhost:61669/tournament/8/play/122/user/userhashvalue";
        //myUrl = "https://ui-gamebox.stacknize.com/game/play/122/user/VTJGc2RHVmtYMThMTXczOEloM2Z2aTZwZzZWcDQzSU01RjhadG0wNlJ3bz0";

        //string devUrl = "https://staging.redtailfox.co/";
        

        string parentURL = GetParentURL();
        Debug.Log("Parent URL: " + parentURL);
        myUrl = parentURL;
        bool isTournament;

        CheckLicense(parentURL);

        if (myUrl != null && myUrl.Contains("tournament"))
        {
            Debug.Log("Parent URL contains 'tournament'");
            ScoreAPI.instance.isTournament = true;
            isTournament = true;
        }
        else
        {
            Debug.Log("Parent URL does not contain 'tournament'");
            ScoreAPI.instance.isTournament = false;
            isTournament = false;
        }

       
        
        if (isTournament)
        {
            int tournamentId = ExtractTournamentId(myUrl);
            string playerHashValue_ = ExtractUserHashValue(myUrl);

            //int tournamentId = ExtractTournamentId(myUrl);

            Debug.Log("Determining tournment id and playerHashValue from url " + myUrl);
            yield return new WaitForSeconds(1f);
            if (tournamentId != -1)
            {
                // Console.WriteLine("Tournament ID: " + tournamentId);
                Debug.Log("Tournament ID: " + tournamentId);
                Debug.Log("Player has value is: " + playerHashValue_);
                ScoreAPI.instance.playerHashValue = playerHashValue_; //set playerHashValue
                playerHashValue = playerHashValue_;
            }
            else
            {
                //Console.WriteLine("Error extracting Tournament ID");
                Debug.Log("Error extracting Tournament ID");
                Debug.Log("Error extracting PlayerHashValue");

            }

            int playerId = ExtractPlayIdForTournament(myUrl);
            Debug.Log(playerId);
            ScoreAPI.instance.gameid = playerId;
        }
        else
        {
            //Determine player hash value of game
            string playerHasValue = ExtractUserHashValueForGame(myUrl);
            yield return new WaitForSeconds(1f);

            //set player hash value
            Debug.Log("Player has value is: " + playerHasValue);
            ScoreAPI.instance.playerHashValue = playerHasValue; //set playerHashValue

            // Example usage
            int playerId = ExtractPlayId(myUrl);
            Debug.Log(playerId);
            ScoreAPI.instance.gameid = playerId;
        }
       
    }

    void CheckLicense(string url)
    {

        if (ContainsSubstring(url, "ui-gamebox.stacknize.com") || ContainsSubstring(url, "yogamez.co.zw") || ContainsSubstring(url, "staging.redtailfox.co"))
        {
            blockUI.SetActive(false);
            Debug.Log("String contains the specified substring.");
        }
        else
        {
            blockUI.SetActive(true);
            Debug.Log("String does not contain the specified substring.");
        }
    }
    private bool ContainsSubstring(string mainString, string substring)
    {
        return mainString.Contains(substring);
    }

    public string ExtractUserHashValueForGame(string url)
    {
        // Parse the URL
        Uri uri = new Uri(url);

        // Get the segments from the path
        string[] segments = uri.AbsolutePath.Split('/');

        // Find the index of "user" in the path
        int userIndex = Array.IndexOf(segments, "user");

        // Check if "user" is found and there is a segment after it
        if (userIndex != -1 && userIndex < segments.Length - 1)
        {
            // Extract the user hash value
            string userHash = segments[userIndex + 1];
            return userHash;
        }

        // Default value or error handling if extraction fails
        return null;

    }

    public int ExtractPlayId(string url)
    {
        // Parse the URL
        Uri uri = new Uri(url);

        // Get the segments from the path
        string[] segments = uri.AbsolutePath.Split('/');

        // Find the index of "play" in the path
        int playIndex = Array.IndexOf(segments, "play");

        // Check if "play" is found and there is a segment after it
        if (playIndex != -1 && playIndex < segments.Length - 1)
        {
            // Attempt to parse the next segment as an integer
            if (int.TryParse(segments[playIndex + 1], out int playId))
            {
                return playId;
            }
        }

        // Default value or error handling if parsing fails
        return -1;
    }

  
    public int ExtractPlayIdForTournament(string url)
    {
        // Parse the URL
        Uri uri = new Uri(url);

        // Get the segments from the path
        string[] segments = uri.AbsolutePath.Split('/');

        // Find the index of "play" in the path
        int playIndex = Array.IndexOf(segments, "play");

        // Check if "play" is found and there is a segment after it
        if (playIndex != -1 && playIndex < segments.Length - 1)
        {
            // Attempt to parse the next segment as an integer
            if (int.TryParse(segments[playIndex + 1], out int playId))
            {
                return playId;
            }
        }

        // Default value or error handling if parsing fails
        return -1;
    }

    private void OnEnable()
    {
        currentScore = 0;
      
    }

    internal static void SubmitScore(float playtime)
    {
        ScoreAPI.SubmitScore(currentScore, (int)playtime,0, (bool s, string msg) => { });
        Debug.Log("scoreSumbitted");
    }

    internal static void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
        OnScoreUpdate?.Invoke();

    }


    internal static void UpdateHighScore(UnityAction callback)
    {
        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                highScore = d.high_score;
             
                callback?.Invoke();
            }
        });
    }



   
}
