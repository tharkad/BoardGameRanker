using UnityEngine;
using System.Collections;

public class FadeShow : MonoBehaviour {

	public void ShowMe(float showFactor)
    {
        StartCoroutine(DoShow(showFactor));
    }

    IEnumerator DoShow(float showFactor)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * showFactor;
            yield return null;
        }
        canvasGroup.interactable = true;
        yield return null;
    }

    public void FadeMe(float fadeFactor)
    {
        StartCoroutine(DoFade(fadeFactor));
    }

    IEnumerator DoFade(float fadeFactor)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeFactor;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}
