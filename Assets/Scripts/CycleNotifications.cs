using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleNotifications : MonoBehaviour {
    public float cycleTime = 5f;
    private float nextCycleTime;

    public string title;
    public string[] texts = { "Are you able to car-pool today?", "Are you using a park-and-ride today?", "Are your compost worms alive and healthy?", "Are your plants alive and healthy?"};
    public int cursor;

    public NotificationTestButton testButton;

    void Update() {
        if (Time.time > nextCycleTime) {
            nextCycleTime = Time.time + cycleTime;
            testButton.title = title;
            cursor++;
            if (cursor >= texts.Length) cursor = 0;
            testButton.text = texts[cursor];
        }
    }
}
