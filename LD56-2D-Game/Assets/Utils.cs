using ExtensionMethods;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public static class Utils
{
    public static bool GetRandBool()
    {
        return UnityEngine.Random.Range(0f, 1f) < 0.5f;
    }

    public static bool FloatTryParseInvariant(string s, out float value)
    {
        return float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }
    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static async Task LoadGoogleSheetAsTSV(string url, string filePath)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }

                Debug.Log("TSV file downloaded successfully.");
            }
            catch (Exception ex)
            {
                Debug.Log($"Error downloading the TSV file: {ex.Message}");
            }
        }
    }
    public static T DeepCopy<T>(T original) where T : new()
    {
        T copy = new T();
        foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.CanRead && property.CanWrite)
            {
                property.SetValue(copy, property.GetValue(original, null), null);
            }
        }
        foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }

    public static void ApplyHorizontalDragForce(Rigidbody rb, float dragCoefficient)
    {
        Vector3 dragForce = CalculateHorizontalDragForce(rb, dragCoefficient);

        rb.AddForce(dragForce);
    }

    public static Vector3 CalculateHorizontalDragForce(Rigidbody rb, float dragCoefficient)
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0;
        float speed = velocity.magnitude;
        return -dragCoefficient * speed * speed * velocity.normalized * 0.5f;
    }

    public static Color IncreaseBrightness(Color originalColor, float targetBrightness)
    {
        // Convert the color to HSB (Hue, Saturation, Brightness) space
        Color.RGBToHSV(originalColor, out float hue, out float saturation, out float brightness);

        // Increase the brightness until it reaches or exceeds the target brightness
        if (brightness < targetBrightness)
        {
            brightness = targetBrightness; // You can adjust the step size as needed
        }

        // Convert back to RGB space
        return Color.HSVToRGB(hue, saturation, brightness);
    }
    public static string FormatTimeForTimer(float f)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(f);
        return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}.{timeSpan.Milliseconds:D3}";
    }

    public static string FormatTimeForTimerTMP(float f)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(f);
        return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}<size=50%>.{timeSpan.Milliseconds:D3}</size>";
    }

    public static string FormatTimeForCombatLevelHS(float f)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(f);
        return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }
    public static bool IsInLayerMask(LayerMask layerMask, LayerMask layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }
    public static IEnumerator WaitForFrames(int frameCount)
    {
        int count = 0;
        while (count < frameCount)
        {
            yield return null;
            count++;
        }
    }


    public static IEnumerator WaitForTimeOrCondition(float time, Func<bool> condition)
    {
        var StartTime = Time.time;
        while (Time.time - StartTime < time)
        {
            if (condition())
            {
                yield break;
            }
            yield return null;
        }
    }

    public static Vector3 GetKnockBackVector(GameObject Attacker, GameObject Reciever, float Amount)
    {
        return (Reciever.transform.position - Attacker.transform.position).GetFlattened().normalized * Amount;
    }

    public static string ColorToHex(Color color)
    {
        int r = Mathf.RoundToInt(color.r * 255);
        int g = Mathf.RoundToInt(color.g * 255);
        int b = Mathf.RoundToInt(color.b * 255);
        int a = Mathf.RoundToInt(color.a * 255);

        return $"#{r:X2}{g:X2}{b:X2}{a:X2}";
    }

    public static Color HexToColor(string hex)
    {
        hex = hex.TrimStart('#');
        if (hex.Length == 6)
        {
            hex += "FF";
        }
        if (hex.Length != 8)
        {
            Debug.LogError("Invalid hex color format. Hex color must be in the format #AABBCCDD. What you gave was :"
                 + hex);
            return Color.white; // Return a default color in case of error
        }

        int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        int a = int.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    public static void LookAtJustY(Transform looker, Vector3 target)
    {
        var OriginalRotation = looker.rotation.eulerAngles;
        looker.LookAt(target);
        var YRot = looker.rotation.eulerAngles.y;
        var finalRot = new Vector3(OriginalRotation.x, YRot, OriginalRotation.z);
        looker.rotation = Quaternion.Euler(finalRot);
    }

    public static void LookAtJustY(Transform looker, Transform target)
    {
        LookAtJustY(looker, target.transform.position);
    }

    public static void LookAtJustYlerp(Transform looker, Vector3 target, float LerpAmount)
    {
        var OriginalRot = looker.rotation;
        LookAtJustY(looker, target);
        looker.rotation = Quaternion.Lerp(OriginalRot, looker.rotation, LerpAmount);
    }

    public static void LookAtJustlerp(Transform looker, Vector3 target, float LerpAmount)
    {
        var OriginalRotation = looker.rotation;
        looker.LookAt(target);
        var finalRot = looker.rotation;
        looker.rotation = Quaternion.Lerp(OriginalRotation, finalRot, LerpAmount);
    }

    public static void LookAtJustYlerp(Transform looker, Transform target, float LerpAmount)
    {
        LookAtJustYlerp(looker, target.transform.position, LerpAmount);
    }

    public static bool ComputeChance(float Chance)
    {
        if (Chance > 1f)
        {
            Debug.LogWarning("Chance should be from 0f-1f, returning true. Chance provided: " + Chance);
            return true;
        }
        return UnityEngine.Random.Range(0f, 1f) <= Chance;
    }

    public static int PickChoice(float[] chances)
    {
        float TotalChance = 0f;
        foreach (var chance in chances)
        {
            TotalChance += chance;
        }
        float val = UnityEngine.Random.Range(0f, TotalChance);
        TotalChance = 0f;
        for (int i = 0; i < chances.Length; i++)
        {
            TotalChance += chances[i];
            if (val <= TotalChance)
            {
                Debug.Log("returning " + i);

                return i;
            }
        }
        return 0;
    }
    public static IEnumerator DoWithFrameDelayRoutine(Action action)
    {
        yield return null;
        action.Invoke();
    }


    public static IEnumerator DoWithFramesDelayRoutine(int frames, Action action)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }
        action.Invoke();
    }

    public static IEnumerator DoWithDelayRoutine(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }


    public static IEnumerator DoWithDelayRealtimeRoutine(float time, Action action)
    {
        yield return new WaitForSecondsRealtime(time);
        action.Invoke();
    }
    // Function to return the current UTC timestamp as a formatted string
    public static string GetCurrentUTCTimestampFormatted()
    {
        return ConvertDateTimeToUTCTimeStamp(DateTime.Now);
    }

    // Function to convert a UTC timestamp string back to a DateTime object
    public static DateTime ConvertUTCTimestampToDateTime(string timestampString)
    {
        if (DateTime.TryParseExact(timestampString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal,
            out DateTime result))
        {
            return result;
        }
        return DateTime.MaxValue;
    }

    // Function to convert a UTC timestamp string back to a DateTime object
    public static string ConvertDateTimeToUTCTimeStamp(DateTime currentUtcTime)
    {
        return currentUtcTime.ToString("yyyy-MM-dd HH:mm:ss");
    }

    // Function to calculate time difference in seconds between two DateTime objects
    public static float TimeDifferenceInSeconds(string startTimeTS, string endTimeTS)
    {
        var startTime = ConvertUTCTimestampToDateTime(startTimeTS);
        var endTime = ConvertUTCTimestampToDateTime(endTimeTS);
        return TimeDifferenceInSeconds(startTime, endTime);
    }
    public static float TimeDifferenceInSeconds(DateTime startTime, DateTime endTime)
    {
        TimeSpan timeDifference = endTime - startTime;
        return (float)timeDifference.TotalSeconds;
    }

}
