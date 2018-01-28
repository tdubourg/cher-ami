using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthUI : MonoBehaviour {
    public float FadeRate;
    public RawImage text;
    public RawImage green;
    private float targetAlpha;
    public const int HEALTH_BLINK_NUMBER = 3;
    public const float HEALTH_BLINK_INTERVAL_IN_SEC = 0.5f;
    // Use this for initialization
    void Start()
    {
        //if (this.image == null)
        //{
        //    Debug.LogError("Error: No image on " + this.name);
        //}
        //this.targetAlpha = 0;// this.image.color.a;
    }



    IEnumerator internalBlink()
    {
        //Debug.Log("Entering blink()");
        for (int i = 0; i < HEALTH_BLINK_NUMBER; i++)
        {
            //Debug.Log("Turning renderer OFF");
            //this.image.CrossFadeAlpha(0.0f, 10.0f, false);

            yield return new WaitForSeconds(HEALTH_BLINK_INTERVAL_IN_SEC);
            //Debug.Log("Turning renderer ON");

            //GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(HEALTH_BLINK_INTERVAL_IN_SEC);

        }
    }
        public void bink()
    {
            StartCoroutine(internalBlink());


    }

    // Update is called once per frame
    void Update()
    {
        //Color curColor = this.image.color;
        //float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
        //if (alphaDiff > 0.0001f)
        //{
        //    curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
        //    this.image.color = curColor;
        //}
    }

    public void FadeOut()
    {
        this.targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
        this.targetAlpha = 1.0f;
    }
}
