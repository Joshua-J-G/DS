using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointMan : MonoBehaviour
{
    public static CheckpointMan instance;
    public int currentTrackID = 0;
    public int NextId = 1;

    public TMP_Text lapcounter;
    public int MAXLAPS = 6;

    public List<Vector4> Times = new List<Vector4>();
    public List<TMP_Text> textfromtimes = new();

    public int LAP = 0;

    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassedCheckPoint(int id)
    {
        currentTrackID = id;

        if (NextId == 0 && id == 0)
        {
            LAP++;
            Times.Add(Timer.Instance.ResetTimer());
        }

        if (currentTrackID == NextId)
        {
            NextId++;
            if(NextId == 4)
            {
                NextId = 0;
            }
        }

        lapcounter.text = $"{LAP}/{MAXLAPS}";
        
        if(LAP == MAXLAPS+1)
        {
            WinScreen.SetActive(true);
            int i = 0;
            foreach(TMP_Text t in textfromtimes)
            {
                int mil, sec, min, hour;
                hour = (int)Times[i].w;
                min = (int)Times[i].z;
                sec = (int)Times[i].y;
                mil = (int)Times[i].x;
                t.text = hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2") + ":" + mil.ToString("D2");
                i++;
            }
        }

    }
}
