using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

[ExecuteInEditMode]
public class TimpsTools : MonoBehaviour
{
    [MenuItem("Tools/Timps/Remove Parents")]
    public static void Execute()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.transform.parent = null;
        }
    }
}

public class DockableTools : EditorWindow
{

    static MethodInfo _clearConsoleMethod;
    static MethodInfo clearConsoleMethod
    {
        get
        {
            if (_clearConsoleMethod == null)
            {
                Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
                Type logEntries = assembly.GetType("UnityEditor.LogEntries");
                _clearConsoleMethod = logEntries.GetMethod("Clear");
            }
            return _clearConsoleMethod;
        }
    }

    private GameObject newChild;
    private Transform newParent;
    private string parentName;
    private string childName;
    private GameObject movingBox;
    private Transform movingBoxPos;
    private bool hasChildPicked;
    private GameObject source;
    private GameObject destparent;
    private bool bothObjectsPicked = false;
    Vector3 copiedPosition;
    private bool positionCopied = false;
    Quaternion copiedRotation;
    private bool rotationCopied = false;
    Quaternion homeRotation = new Quaternion(0f, 0f, 0f, 0f);
    Vector3 homePosition = new Vector3(0f,0f,0f);


    // Create Window
    [MenuItem("Tools/Timps/Show Dockable")]
    public static void ShowWindow()
    {
        Vector2  dockWindow = new Vector2(400.0f, 292.0f);
        //Show existing window instance. If one doesn't exist, make one.
        var window = EditorWindow.GetWindow(typeof(DockableTools));
        window.minSize = dockWindow;
    }

    void OnGUI()
    {
        GUILayout.BeginVertical("box");
        GUILayout.Label("Parent + Child tools", EditorStyles.boldLabel);
        GUILayout.Label("Parent Game Object to another");
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Select Child Object", GUILayout.Width(189))) { 
            newChild = Selection.activeGameObject;
            childName = Selection.activeGameObject.name;
            Debug.Log("Child object selected: " + childName);
            Selection.activeGameObject = null;
            hasChildPicked = true;
            source = newChild;
                    }
        GUI.enabled = hasChildPicked;
        if (GUILayout.Button("Select new parent", GUILayout.Width(189)))
        {
            if (!newChild)
            {
                Debug.Log("No child object selected");
            }
            else
            parentName = Selection.activeGameObject.name;
            newParent = Selection.activeGameObject.transform;
            newChild.transform.SetParent(newParent);
            Debug.Log(childName+" has been parented to "+parentName);
            newChild = null;
            newParent = null;
            hasChildPicked = false;
                        
        }
        GUILayout.EndHorizontal();
        GUI.enabled = true;
        GUILayout.Label("Or : Select Gameobjects to parent together");
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Child");
        source = (GameObject)EditorGUILayout.ObjectField(source, typeof(GameObject), true);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("New parent");
        destparent = (GameObject)EditorGUILayout.ObjectField(destparent, typeof(GameObject), true);
        GUILayout.EndHorizontal();
        GUI.enabled = bothObjectsPicked;
        if (destparent && source)
        {
            bothObjectsPicked = true;
        } else
        {
            bothObjectsPicked = false;
        }
        if (GUILayout.Button("Attach to new parent"))
        {
            source.transform.SetParent(destparent.transform);
            source = null;
            destparent = null;
        }
        GUI.enabled = true;
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("De Parent from GameObject");
        if (GUILayout.Button("Remove child from parent object"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.parent = null;
            }
            Debug.Log("All object/s have been sent to root of heirachy");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        GUILayout.Label("Heirachy Changes", EditorStyles.boldLabel);
        if (GUILayout.Button("Move to top"))
        {
            movingBox = Selection.activeGameObject;
            movingBoxPos = movingBox.transform;
            movingBoxPos.transform.SetSiblingIndex(0);
            Debug.Log(movingBox.name+" moved to top");
        }
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        GUILayout.Label("Console Tools", EditorStyles.boldLabel);
        if (GUILayout.Button("Clear Console"))
        {
            clearConsoleMethod.Invoke(new object(), null);
        }
        GUILayout.EndVertical();
        GUILayout.BeginVertical("box");
        GUILayout.Label("Transform Tools", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Copy Position", GUILayout.Width(189)))
        {
            copiedPosition = Selection.activeTransform.position;
            positionCopied = true;
        }
        GUI.enabled = positionCopied;
        if (GUILayout.Button("Paste Position", GUILayout.Width(189)))
        {
            Selection.activeTransform.position = copiedPosition;
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();
        copiedPosition = EditorGUILayout.Vector3Field("Copied Transform", copiedPosition);
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Copy Rotation", GUILayout.Width(189)))
        {
            copiedRotation = Selection.activeTransform.rotation;
                rotationCopied = true;
        }
        GUI.enabled = rotationCopied;
        if (GUILayout.Button("Paste Rotation", GUILayout.Width(189)))
        {
            Selection.activeTransform.localRotation = copiedRotation;
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Copy All", GUILayout.Width(189)))
        {
            copiedPosition = Selection.activeTransform.position;
            positionCopied = true;
            copiedRotation = Selection.activeTransform.rotation;
            rotationCopied = true;

        }
        if (GUILayout.Button("Paste All", GUILayout.Width(189)))
        {
            Selection.activeTransform.localRotation = copiedRotation;
            Selection.activeTransform.position = copiedPosition;

        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Reset Transform"))
        {
            Selection.activeTransform.position = homePosition;
            Selection.activeTransform.rotation = homeRotation;
        }
        GUILayout.EndVertical();
    }
        
          
    }
