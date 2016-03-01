using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundControls : MonoBehaviour {

    public bool controlsDisplayed = false;
    public GameObject manager;
    public Button musicButton;
    public Button effectsButton;
    public Sprite musicOn;
    public Sprite musicOff;
    public Sprite effectsOn;
    public Sprite effectsOff;

    public void SetupAndDisplay()
    {
        int state = PlayerPrefs.GetInt("Music");
        if (state == 1)
            musicButton.image.sprite = musicOn;
        else
            musicButton.image.sprite = musicOff;

        state = PlayerPrefs.GetInt("Effects");
        if (state == 1)
            effectsButton.image.sprite = effectsOn;
        else
            effectsButton.image.sprite = effectsOff;

        FadeShow fadeShowScript = (FadeShow)GetComponent("FadeShow");
        controlsDisplayed = !controlsDisplayed;
        if (controlsDisplayed)
            fadeShowScript.ShowMe(100);
        else
            fadeShowScript.FadeMe(100);
    }

    public void MusicClicked()
    {
        int musicState = PlayerPrefs.GetInt("Music");
        AudioSource source = manager.GetComponent<AudioSource>();

        if (musicState == 1)
        {
            source.Stop();
            PlayerPrefs.SetInt("Music", 0);
            musicButton.image.sprite = musicOff;
        }
        else
        {
            source.Play(0);
            PlayerPrefs.SetInt("Music", 1);
            musicButton.image.sprite = musicOn;
        }
    }

    public void EffectsClicked()
    {
        int effectsState = PlayerPrefs.GetInt("Effects");

        if (effectsState == 1)
        {
            PlayerPrefs.SetInt("Effects", 0);
            effectsButton.image.sprite = effectsOff;
        }
        else
        {
            PlayerPrefs.SetInt("Effects", 1);
            effectsButton.image.sprite = effectsOn;
        }
    }
}
