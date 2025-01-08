using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour, ITimeTracker
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    void Start()
    {
        TimeManager.Instance.RegisterTracker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClockUpdate(GameTimeStamp timeStamp)
    {
        int hours = timeStamp.hour;
        int minutes = timeStamp.minute;
        string suffix = " AM";
        if (hours > 12)
        {
            suffix = " PM";
            hours -= 12;
        }

        timeText.text = hours + ":" + minutes.ToString("00") + suffix;
    }
}
