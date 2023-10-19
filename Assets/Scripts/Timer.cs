using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TMP_Text counterText;

    public int milliseconds, seconds, minutes, hours;

    public Vector4 minusAmount;

    void Start()
    {
        Instance = this;
       // counterText = GetComponent<TMP_Text>() as TMP_Text;
    }

    void Update()
    {
        hours = (int)(Time.timeSinceLevelLoad / 3600f) - (int)minusAmount.w;
        minutes = (int)((Time.timeSinceLevelLoad / 60f) % 60) - (int)minusAmount.z;
        seconds = (int)(Time.timeSinceLevelLoad % 60f) - (int)minusAmount.y;
        milliseconds = ((int)(Time.timeSinceLevelLoad * 1000f) % 1000) ;

        counterText.text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");

    }

    public Vector4 ResetTimer()
    {
       Vector4 savedTime = new Vector4 (milliseconds,seconds,minutes,hours);

        minusAmount += savedTime;
     
        return savedTime;
    }    
}