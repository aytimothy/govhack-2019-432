using System;
using System.Collections.Generic;
using Unity.Notifications;
using Unity.Notifications.Android;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
using UnityEngine;

public class NotificationTestButton : MonoBehaviour {
        public AndroidNotificationChannel androidNotificationChannel;
        public AndroidNotification androidNotification;
        public static bool initialized;
        public string title = "Hello World!";
        public string text = "This is just a test notification!";
        public int delay = 5;

    void Start() {
        if (initialized) return;
        initialized = true;
        androidNotificationChannel = new AndroidNotificationChannel();
        androidNotificationChannel.Id = "channel_id";
        androidNotificationChannel.Name = "Default Channel";
        androidNotificationChannel.Importance = Importance.High;
        androidNotificationChannel.Description = "Generic Notifications";
        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);
    }

    public void NotificationTestButton_OnClick() {
#if UNITY_IOS
        
#elif UNITY_ANDROID
        androidNotification = new AndroidNotification();
        androidNotification.Title = title;
        androidNotification.Text = text;
        androidNotification.FireTime = DateTime.Now.AddSeconds(delay);
        AndroidNotificationCenter.SendNotification(androidNotification, "channel_id");
#endif
    }
}
