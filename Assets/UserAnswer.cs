using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserAnswer : MonoBehaviour {

    public Text quizText;
    public Text topText;
    public Text bottomText;
    public Image lessRightWrong;
    public Image betweenRightWrong;
    public Image moreRightWrong;
    public GameObject rightWrongNoneCanvas;
    public Text currentText;
    public Text bestText;

    public void UserAnswerButton(int answer) // 0 = <, 1 = between, 2 = >
    {
        GameObject manager = GameObject.Find("_Manager");
        StartGame startGameScript = (StartGame)manager.GetComponent("StartGame");

        quizText.text = startGameScript.quizRank.ToString();
        topText.text = startGameScript.topRank.ToString();
        bottomText.text = startGameScript.bottomRank.ToString();

        RightWrongNone rightWrongNoneScript;
        rightWrongNoneScript = (RightWrongNone)lessRightWrong.GetComponent("RightWrongNone");
        rightWrongNoneScript.ShowRightWrongNone(2);
        rightWrongNoneScript = (RightWrongNone)betweenRightWrong.GetComponent("RightWrongNone");
        rightWrongNoneScript.ShowRightWrongNone(2);
        rightWrongNoneScript = (RightWrongNone)moreRightWrong.GetComponent("RightWrongNone");
        rightWrongNoneScript.ShowRightWrongNone(2);

        bool correct = false;
        switch (answer)
        {
            case 0: // <
                rightWrongNoneScript = (RightWrongNone)lessRightWrong.GetComponent("RightWrongNone");
                if (startGameScript.quizRank < startGameScript.topRank)
                {
                    rightWrongNoneScript.ShowRightWrongNone(0);
                    correct = true;
                }
                else
                    rightWrongNoneScript.ShowRightWrongNone(1);
                break;

            case 1: // <
                rightWrongNoneScript = (RightWrongNone)betweenRightWrong.GetComponent("RightWrongNone");
                if ((startGameScript.topRank < startGameScript.quizRank) && (startGameScript.quizRank < startGameScript.bottomRank))
                {
                    rightWrongNoneScript.ShowRightWrongNone(0);
                    correct = true;
                }
                else
                    rightWrongNoneScript.ShowRightWrongNone(1);
                break;

            case 2: // <
                rightWrongNoneScript = (RightWrongNone)moreRightWrong.GetComponent("RightWrongNone");
                if (startGameScript.bottomRank < startGameScript.quizRank)
                {
                    rightWrongNoneScript.ShowRightWrongNone(0);
                    correct = true;
                }
                else
                    rightWrongNoneScript.ShowRightWrongNone(1);
                break;
        }

        int currentScore = PlayerPrefs.GetInt("CurrentScore");
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (correct)
        {
            currentScore = currentScore + 1;
            if (currentScore > bestScore)
                bestScore = currentScore;
        }
        else
        {
            currentScore = 0;
        }

        currentText.text = currentScore.ToString();
        bestText.text = bestScore.ToString();

        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.SetInt("BestScore", bestScore);

        FadeShow fadeShowScript = (FadeShow)rightWrongNoneCanvas.GetComponent("FadeShow");
        fadeShowScript.ShowMe(10);
    }

    public void BlankAnswers()
    {
        quizText.text = "";
        topText.text = "";
        bottomText.text = "";
    }
}
