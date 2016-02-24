using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RightWrongNone : MonoBehaviour {

    public Sprite[] rightWrongNone;

	public void ShowRightWrongNone(int rightWrongNoneIndex)
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = rightWrongNone[rightWrongNoneIndex];
    }
}
 