#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;

public class AudioClipClassGenerator : EditorWindow
{
    [MenuItem("Custom Tools/Generate C# Audio Clip File")]
    public static void GenerateAudioClipFile()
    {
        PopulateScriptableObject("Assets/Audio", "Assets/Audio/Clips/", "Assets/Audio/ClipsData/");
        GenerateAudioClipClass("Assets/Audio/Clips/");
    }

    private static void PopulateScriptableObject(string scriptableObjFolderPath, string clipsPath, string clipsDataPath)
    {
        string[] guids = AssetDatabase.FindAssets("t:AudioClipsContainer", new[] { scriptableObjFolderPath });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            AudioClipsContainer asset = AssetDatabase.LoadAssetAtPath<AudioClipsContainer>(assetPath);

            if (asset != null)
            {
                asset.AudioClipsData.Clear();
                string[] wavFiles = System.IO.Directory.GetFiles(clipsPath, "*.wav"); // You can add other audio formats as well
                string[] oggFiles = System.IO.Directory.GetFiles(clipsPath, "*.ogg");

                string[] audioFiles = wavFiles.Concat(oggFiles).ToArray();
                GameObject emptyGO = new GameObject();
                emptyGO.AddComponent<AudioSource>();
                for (int i = 0; i < audioFiles.Length; i++)
                {
                    var fullFilePath = audioFiles[i];
                    var prefabFilePath = audioFiles[i].Replace("Clips", "ClipsData");
                    string prefabPath = $"{prefabFilePath.Split('.')[0]}.prefab";
                    GameObject audioDataAsset = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    if(audioDataAsset == null) 
                    {
                        audioDataAsset = PrefabUtility.SaveAsPrefabAsset(emptyGO, prefabPath);
                        var AS = audioDataAsset.GetComponent<AudioSource>();
                        AS.playOnAwake = true;
                        AS.clip = AssetDatabase.LoadAssetAtPath<AudioClip>(fullFilePath);
                        AS.volume = 0.5f;
                        audioDataAsset.AddComponent<AudioDataCustomOverrides>();
                    }
                    asset.AudioClipsData.Add(AssetDatabase.LoadAssetAtPath<AudioSource>(prefabPath));
                }
                DestroyImmediate(emptyGO);
                EditorUtility.SetDirty(asset);
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogWarning("Could not find asset!");
            }
        }

        AssetDatabase.SaveAssets();

        AssetDatabase.Refresh();
    }

    private static void GenerateAudioClipClass(string path)
    {
        CombinedSFXNames.Clear();
        string[] wavFiles = System.IO.Directory.GetFiles(path, "*.wav"); // You can add other audio formats as well
        string[] oggFiles = System.IO.Directory.GetFiles(path, "*.ogg");

        string[] audioFiles = wavFiles.Concat(oggFiles).ToArray();
        Array.Sort(audioFiles);

        StringBuilder classContent = new StringBuilder();

        classContent.AppendLine("using UnityEngine;");
        classContent.AppendLine("using System.Collections.Generic;");
        classContent.AppendLine();
        classContent.AppendLine("namespace Audio");
        classContent.AppendLine("{");
        classContent.AppendLine("public static class Clips");
        classContent.AppendLine("{");

        StringBuilder sfxPlayerContent = new StringBuilder();

        sfxPlayerContent.AppendLine("using Audio;");
        sfxPlayerContent.AppendLine("using UnityEngine;");
        sfxPlayerContent.AppendLine("public class SFXPlayer : MonoBehaviour");
        sfxPlayerContent.AppendLine("{");


        List<string> currentSetOfMultiples = new();
        string EndDictionary = "";
        string currentSetPrefix = "";
        foreach (string audioFile in audioFiles)
        {
            string variableName = Path.GetFileNameWithoutExtension(audioFile);
            variableName = new string(variableName.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
            variableName = variableName.Replace('-', '_');
            if (variableName == "")
            {
                Debug.LogWarning("No name here?");
                continue;
            }
            var newLine = $"    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) {variableName} => AudioManager.GetClip(" + '"' + variableName + '"' + ");";

            classContent.AppendLine(newLine);

            AddSFXPlayerLines(ref sfxPlayerContent, variableName);

            if (IsNumber(variableName[variableName.Length - 1]))
            {
                if (!IsNumber(variableName[variableName.Length - 2]) || variableName[variableName.Length - 3] != '_')
                {
                    Debug.LogError("Multiple audio clip file formatted wrong. Must be Clipname-XX where XX is a number between 00 and 99 " + variableName);
                    continue;
                }
                var prefix = variableName.Substring(0, variableName.Length - 3);
                if (prefix == currentSetPrefix)
                {
                    currentSetOfMultiples.Add(variableName);

                    if (audioFile == audioFiles[audioFiles.Length - 1])
                    {
                        HandleCompletedSet(ref classContent, currentSetPrefix, currentSetOfMultiples);
                        currentSetOfMultiples.Clear();
                        currentSetOfMultiples.Add(variableName);
                        AddSFXPlayerLines(ref sfxPlayerContent, currentSetPrefix);
                        EndDictionary += currentSetPrefix == "" ? "" : "       { \"" + currentSetPrefix + "\", Clips." + currentSetPrefix + "},\n";
                    }
                }
                else
                {
                    HandleCompletedSet(ref classContent, currentSetPrefix, currentSetOfMultiples);
                    currentSetOfMultiples.Clear();
                    currentSetOfMultiples.Add(variableName);
                    AddSFXPlayerLines(ref sfxPlayerContent, currentSetPrefix);
                    EndDictionary += currentSetPrefix == "" ? "" : "       { \"" + currentSetPrefix + "\", Clips." + currentSetPrefix + "},\n";
                }

                currentSetPrefix = prefix;
            }
            else if (currentSetOfMultiples.Count > 0)
            {
                HandleCompletedSet(ref classContent, currentSetPrefix, currentSetOfMultiples);
                currentSetOfMultiples.Clear();
                currentSetOfMultiples.Add(variableName);
                AddSFXPlayerLines(ref sfxPlayerContent, currentSetPrefix);
                EndDictionary += currentSetPrefix == "" ? "" : "       { \"" + currentSetPrefix + "\", Clips." + currentSetPrefix + "},\n";
                currentSetPrefix = "";
            }
        }
        // Add static dictionary at bottom
        classContent.AppendLine("    public static Dictionary<string, (AudioSource audioSource, AudioDataCustomOverrides overrides)> clipDict => new(){");
        foreach (string audioFile in audioFiles)
        {
            string variableName = Path.GetFileNameWithoutExtension(audioFile);
            variableName = new string(variableName.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
            variableName = variableName.Replace('-', '_');
            if (variableName == "")
            {
                Debug.LogWarning("No name here?");
                continue;
            }
            var newLine = "       { \"" + variableName + "\", Clips." + variableName + "},";

            classContent.AppendLine(newLine);
        }
        classContent.AppendLine(EndDictionary);
        classContent.AppendLine("   };");

        classContent.AppendLine("}");
        classContent.AppendLine("}");

        sfxPlayerContent.AppendLine("}");

        string filePath = Path.Combine(Application.dataPath, "Audio/Clips.cs");
        System.IO.File.WriteAllText(filePath, classContent.ToString());

        string sfxPlayerfilePath = Path.Combine(Application.dataPath, "Audio/SFXPlayer.cs");
        System.IO.File.WriteAllText(sfxPlayerfilePath, sfxPlayerContent.ToString());

        AssetDatabase.Refresh();
    }

    private static void AddSFXPlayerLines(ref StringBuilder sfxPlayerContent, string prefix)
    {
        if (prefix == "")
        {
            return;
        }
        sfxPlayerContent.AppendLine("    public void play_" + prefix + "()" + '{' + "AudioManager.PlayClip(Clips." + prefix + ");}");
        sfxPlayerContent.AppendLine("    public void play_" + prefix + "_randomized()" + '{' + "AudioManager.PlayClip(Clips." + prefix + ", AudioManager.GenericRandomizedData);}");
        sfxPlayerContent.AppendLine("    public void play_loop_" + prefix + "(float time)" + '{' + "AudioManager.PlayClip(Clips." + prefix + ", data: new() { Loop = true, LoopDuration = time});}");
    }

    public static List<string> CombinedSFXNames = new();
    private static void HandleCompletedSet(ref StringBuilder classContent, string prefix, List<string> currentSetOfMultiples)
    {
        if (prefix == "")
        {
            return;
        }
        var newLine = $"    public static (AudioSource audioSource, AudioDataCustomOverrides overrides) {prefix}\n" + "    {" + '\n' + "        get" + '\n' + "        {" + '\n' + "        var Clips = new (AudioSource audioSource, AudioDataCustomOverrides overrides)[]" + '\n' + "        {" + '\n';
        foreach (var clip in currentSetOfMultiples)
        {
            newLine += "            " + clip + ',' + '\n';
        }
        newLine += "        };\n";
        newLine += "        return Clips[Random.Range(0, Clips.Length)];" + '\n';
        newLine += "        }\n    }\n";
        classContent.AppendLine(newLine);
        CombinedSFXNames.Add(prefix);
    }

    static bool IsNumber(char c)
    {
        return (int)c >= (int)'0' && (int)c <= (int)'9';
    }
}
#endif