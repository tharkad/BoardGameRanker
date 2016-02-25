using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public string url;
    public bool downloading = false;
    public GameObject quiz_image;
    public GameObject top_image;
    public GameObject bottom_image;
    public GameObject quiz_spinner;
    public GameObject top_spinner;
    public GameObject bottom_spinner;
    public GameObject answer_buttons_canvas;

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetButton("Fire1"))
       // {
       // }
    }

    public void GetImage()
    {
        StartCoroutine(ccGetImage());
    }

    public IEnumerator ccGetImage()
    {
        float scaleFactor;
        float newWidth;
        float unitPixels;
        float widthInUnits;
        //float ScreenWidthInUnits;

        downloading = true;

        WWW www = new WWW(url);
        yield return www;

        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

        Camera camera = Camera.main;
        Vector3 screenPos0 = camera.WorldToScreenPoint(new Vector3(0.0f, 0.0f, 0.0f));
        Vector3 screenPos1 = camera.WorldToScreenPoint(new Vector3(1.0f, 0.0f, 0.0f));
        unitPixels = screenPos1.x - screenPos0.x;
        //Vector3 ScreenDims = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //ScreenWidthInUnits = ScreenDims.x * 2;

        scaleFactor = 200.0f / www.texture.height;
        newWidth = www.texture.width * scaleFactor;
        if (newWidth > 240.0f)
            scaleFactor = 240.0f / www.texture.width;
        newWidth = www.texture.width * scaleFactor;
        widthInUnits = newWidth / unitPixels;

        Sprite sprite = new Sprite();
        sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        float yPos = transform.position.y;
        transform.position = new Vector3((-widthInUnits / 2.0f), yPos, 0);

        renderer.sprite = sprite;

        downloading = false;
        GameController quiz_script = (GameController)quiz_image.GetComponent("GameController");
        GameController top_script = (GameController)top_image.GetComponent("GameController");
        GameController bottom_script = (GameController)bottom_image.GetComponent("GameController");

        if ((!quiz_script.downloading && !top_script.downloading) && !bottom_script.downloading)
        {
            Renderer ren = quiz_image.GetComponent<Renderer>();
            ren.enabled = true;
            ren = top_image.GetComponent<Renderer>();
            ren.enabled = true;
            ren = bottom_image.GetComponent<Renderer>();
            ren.enabled = true;

            ren = quiz_spinner.GetComponent<Renderer>();
            ren.enabled = false;
            ren = top_spinner.GetComponent<Renderer>();
            ren.enabled = false;
            ren = bottom_spinner.GetComponent<Renderer>();
            ren.enabled = false;

            FadeShow buttons_script = (FadeShow)answer_buttons_canvas.GetComponent("FadeShow");
            buttons_script.ShowMe(10);
        }
    }
}
