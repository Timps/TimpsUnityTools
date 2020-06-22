//C# Example (LookAtPoint.cs)
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    private GameObject newChild;
    private Transform newParent;
    private string parentName;
    private string childName;


    // Add menu item named "My Window" to the Window menu
    [MenuItem("Tools/Timps/Show Dockable")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(DockableTools));
        GUILayout.MinHeight(200);
        GUILayout.MinWidth(800);
    }

    void OnGUI()
    {
        
        GUILayout.Label("Parent Game Object to another", EditorStyles.boldLabel);
        if (GUILayout.Button("Select Child Object"))
        {
            newChild = Selection.activeGameObject;
            childName = Selection.activeGameObject.name;
            Debug.Log("Child object selected: " + childName);
        }
        if (GUILayout.Button("Select new parent"))
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
            
        }
        GUILayout.Label("Remove Parent Game Object", EditorStyles.boldLabel);
        if (GUILayout.Button("Remove parent of selected objects"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.parent = null;
            }
        }






    }

    

}
