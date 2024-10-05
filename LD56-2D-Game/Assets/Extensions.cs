using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace ExtensionMethods
{
    public static class AnimatorExtensions
    {
        public static IEnumerator SetAndUnsetTriggerRoutine(this Animator anim, string trigger)
        {
            anim.SetTrigger(trigger);
            yield return null;
            anim.ResetTrigger(trigger);
        }
    }

    public static class GenericExtensions
    {
        private static System.Random random = new System.Random();
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        public static AudioSource SetVolume(this AudioSource AS, float vol)
        {
            if (AS != null)
            {
                AS.volume = vol;
            }
            return AS;
        }

        public static AudioSource SetVolume(this AudioSource AS, float minVol, float maxVol)
        {
            if (AS != null)
            {
                AS.volume = UnityEngine.Random.Range(minVol, maxVol);
            }
            return AS;
        }

        public static Vector3 GetFlattened(this Vector3 input)
        {
            return new Vector3(input.x, 0, input.z);
        }

        public static Vector2 GetFlattened(this Vector2 input)
        {
            return new Vector2(input.x, 0);
        }

        public static T PickRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new InvalidOperationException("Cannot pick a random element from an empty or null list.");
            }

            int index = random.Next(list.Count);
            return list[index];
        }

        public static T PickRandom<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new InvalidOperationException("Cannot pick a random element from an empty or null array.");
            }

            int index = random.Next(array.Length);
            return array[index];
        }

        public static Dictionary<string, string> FlipKeysAndValues(this Dictionary<string, string> dict)
        {
            Dictionary<string, string> result = new();
            foreach (var kv in dict)
            {
                if (result.ContainsKey(kv.Value))
                {
                    Debug.LogError("Cannot flip this dictionary because there are multiplies of a value:" + kv.Value.ToString());
                    return null;
                }
                result[kv.Value] = kv.Key;
            }
            return result;
        }

        public static void ResetThenSetTrigger(this Animator anim, string trigger)
        {
            anim.ResetTrigger(trigger);
            anim.SetTrigger(trigger);
        }
    }
}