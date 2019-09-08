using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Time = UnityEngine.Time;

public class AirQualityDataDemo : MonoBehaviour {
    public float updateRate = 5f;
    public float nextUpdateTime = 0;

    public string no2measurement = "ppm";
    public string o3measurement = "ppm";
    public string pm10measurement = "µg/m<sup>3</sup>";
    public string pm25measurement = "µg/m<sup>3</sup>";
    
    // Data from 07/08/2019, no api calls, couldn't find it anywhere.
    public float[] no2data = { 0.002f, 0.003f, 0.002f, 0.003f, 0.002f, 0.001f, 0.001f, 0.001f, 0.003f, 0.002f };
    public float[] o3data = { 0.031f, 0.028f, 0.028f, 0.027f, 0.027f, 0.028f, 0.027f, 0.027f, 0.027f, 0.028f };
    public float[] pm10data = { 15.5f, 17.8f, 14.8f, 20.6f, 25.7f, 24.8f, 21f, 25.4f, 24.9f, 28.8f };
    public float[] pm25data = { 7.4f, 10.7f, 7.7f, 11.9f, 12.2f, 8.5f, 4.7f, 5.3f, 4.5f, 8.2f };

    public int no2cursor = 0;
    public int o3cursor = 0;
    public int pm10cursor = 0;
    public int pm25cursor = 0;

    public TMP_Text no2text;
    public TMP_Text o3text;
    public TMP_Text pm10text;
    public TMP_Text pm25text;

    void Update() {
        if (Time.time > nextUpdateTime) {
            nextUpdateTime = Time.time + updateRate;

            no2cursor++;
            o3cursor++;
            pm10cursor++;
            pm25cursor++;

            if (no2cursor >= no2data.Length) no2cursor = 0;
            if (o3cursor >= o3data.Length) o3cursor = 0;
            if (pm10cursor >= pm10data.Length) pm10cursor = 0;
            if (pm25cursor >= pm25data.Length) pm25cursor = 0;
        
            no2text.text = no2data[no2cursor] + " " + no2measurement;
            o3text.text = o3data[o3cursor] + " " + o3measurement;
            pm10text.text = pm10data[pm10cursor] + " " + pm10measurement;
            pm25text.text = pm25data[pm25cursor] + " " + pm25measurement;
        }
    }
}
