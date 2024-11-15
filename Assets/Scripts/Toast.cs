using UnityEngine;

public class Toast : MonoBehaviour {

    private readonly string mText;
    private AndroidJavaObject currentActivity;

    private Toast(string message) {
        mText = message;
    }

    public static void show(string message) {
        if (Application.platform == RuntimePlatform.Android) {
            // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
            new Toast(message).ShowToast();
        }
    }

    private void ShowToast() {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(AndroidJavaRunnableCallback));
    }

    private void AndroidJavaRunnableCallback() {
        var context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        var toastWidget = new AndroidJavaClass("android.widget.Toast");
        var javaString = new AndroidJavaObject("java.lang.String", mText);
        var toast = toastWidget.CallStatic<AndroidJavaObject>("makeText", context, javaString,
            toastWidget.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }

}