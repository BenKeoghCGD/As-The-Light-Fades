using UnityEditor;
using UnityEngine;

/// <summary>
/// Groups all selected objects as childs of a new object
/// </summary>
public class GroupSceneObjects
{
    [MenuItem("GameObject/Group it %g")]
    private static void GroupSelectedSceneObjects()
    {
        // no transform selected return
        if (!Selection.activeTransform)
        {
            return;
        }

        GameObject go = new GameObject { name = "Group" };

        Undo.RegisterCreatedObjectUndo(go, "Group it");

        // Set parent to selected parent
        go.transform.SetParent(Selection.activeTransform.parent, false);

        // iterate over selection to add new group go
        foreach (var transform in Selection.transforms)
        {
            Undo.SetTransformParent(transform, go.transform, "Group it");
        }

        // make the new group the selected target
        Selection.activeGameObject = go;
    }
}