//C# Example (LookAtPoint.cs)
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