using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EventBaseCharacterProjectSetting : EditorWindow
{
    [MenuItem("Tools/Event Base Character Project Setting")]
    public static void showWindow()
    {
        EditorWindow.GetWindow(typeof(EventBaseCharacterProjectSetting));
    }

    public EventBaseCharacterProjectSetting(){
        this.titleContent = new GUIContent("Event Base Character Project Setting");
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enabled New Input System:");
        if (GUILayout.Button("Player Setting"))
        {
            // Edit->ProjectSetting->Player->other->ActiveHandling
            SettingsService.OpenProjectSettings("Project/Player");
        }
        GUILayout.EndHorizontal();
    }

}


