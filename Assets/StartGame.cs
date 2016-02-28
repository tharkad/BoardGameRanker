using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    string baseURL = "http://robotgamesquad.com/bgr/bgg-images-scaled/";

    public int lowestRankInGame = 1000;
    public string rankURL;
    public string[] gameIDs = new string[1001];
    public int quizRank;
    public int topRank;
    public int bottomRank;
    public Text bestText;
    public GameObject start_canvas;
    public GameObject disconnected_canvas;


    void Start()
    {
        GameSetup();
    }

    public void GameSetup()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            bestText.text = PlayerPrefs.GetInt("BestScore").ToString();
        else
        {
            bestText.text = "0";
            PlayerPrefs.SetInt("BestScore", 0);
        }

        PlayerPrefs.SetInt("CurrentScore", 0);

        StartCoroutine(DownloadRanks());
    }

    public IEnumerator DownloadRanks()
    {
        FadeShow script;

        WWW www = new WWW(rankURL);
        while (!www.isDone)
        yield return www;

        if (www.error != null)
        {
            script = (FadeShow)start_canvas.GetComponent("FadeShow");
            script.FadeMe(10);
            script = (FadeShow)disconnected_canvas.GetComponent("FadeShow");
            script.ShowMe(10);
        }
        else
        {
            script = (FadeShow)start_canvas.GetComponent("FadeShow");
            script.ShowMe(10);
            script = (FadeShow)disconnected_canvas.GetComponent("FadeShow");
            script.FadeMe(10);

            string text = www.text;
            gameIDs = text.Split("\n"[0]);

            SetupRound();

        }
    }

    public void SetupRound ()
    {
        quizRank = Random.Range(2, lowestRankInGame);
        topRank = quizRank;
        while (topRank == quizRank)
            topRank = Random.Range(1, lowestRankInGame);
        bottomRank = quizRank;
        while (bottomRank == quizRank)
            bottomRank = Random.Range(topRank + 1, lowestRankInGame + 1);

        GameObject pic = GameObject.Find("game_quiz");
        GameController script = (GameController)pic.GetComponent("GameController");
        script.url = baseURL + gameIDs[quizRank - 1] + ".png";

        pic = GameObject.Find("game_top");
        script = (GameController)pic.GetComponent("GameController");
        script.url = baseURL + gameIDs[topRank - 1] + ".png";

        pic = GameObject.Find("game_bottom");
        script = (GameController)pic.GetComponent("GameController");
        script.url = baseURL + gameIDs[bottomRank - 1] + ".png";
    }
}
