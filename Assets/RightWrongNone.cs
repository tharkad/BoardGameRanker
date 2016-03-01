using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightWrongNone : MonoBehaviour {

    public Sprite[] rightWrongNone;
    public AudioClip rightClip;
    public AudioClip wrongClip;

	public void ShowRightWrongNone(int rightWrongNoneIndex)
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = rightWrongNone[rightWrongNoneIndex];

        AudioSource source = GetComponent<AudioSource>();
        if (rightWrongNoneIndex == 0)
        {
            int currentScore = PlayerPrefs.GetInt("CurrentScore");
            source.pitch = 1.0f + ((float)currentScore * 0.1224554f);

            if (PlayerPrefs.GetInt("Effects") == 1)
                source.PlayOneShot(rightClip);
        }
        else if (rightWrongNoneIndex == 1)
        {
            source.pitch = 1.0f;
            if (PlayerPrefs.GetInt("Effects") == 1)
                source.PlayOneShot(wrongClip);
        }
    }
}
 