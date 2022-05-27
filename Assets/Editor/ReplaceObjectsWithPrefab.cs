using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ReplaceObjectsWithPrefab : EditorWindow
{
    GameObject objectsToReplace;
    GameObject prefab;
    Material materialToReplace;


    [MenuItem("Tools/Replace Objects with Prefab")]
    static void Init()
    {
        var window = (ReplaceObjectsWithPrefab)EditorWindow.GetWindow(typeof(ReplaceObjectsWithPrefab));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Object Replacer");
        objectsToReplace = (GameObject)EditorGUILayout.ObjectField(objectsToReplace, typeof(GameObject), true);
        prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), false);

        if (GUILayout.Button("Replace Objects"))
        {
            var objectChildren = objectsToReplace.GetComponents<EnemyHealth>();
            for (int i = 0; i < objectChildren.Length; i++)
            {
                Instantiate(prefab, objectChildren[i].gameObject.transform.position, Quaternion.identity);
                DestroyImmediate(objectChildren[i]);
            }
        }

        //

        GUILayout.Label("Delete All With Material");
        var enemies = FindObjectsOfType<EnemyHealth>();
        materialToReplace = (Material)EditorGUILayout.ObjectField(materialToReplace, typeof(Object), true);
        List<EnemyHealth> enemiesWithWood = new();
        
        for(int a = 0; a < enemies.Length; a++)
        {
            Debug.Log(enemies[a].GetComponentInChildren<MeshRenderer>().material.name.ToLower().Trim().Replace(" ", ""));
            Debug.Log(materialToReplace.name.ToLower().Trim().Replace(" ", "") + "(instance)");
            if (enemies[a].GetComponentInChildren<MeshRenderer>().material.name.ToLower().Trim().Replace(" ","") == materialToReplace.name.ToLower().Trim().Replace(" ","") + "(instance)")
            {
                enemiesWithWood.Add(enemies[a]);
            }
        }


        if(GUILayout.Button("Replace With Material"))
        {
            for (int q = 0; q < enemiesWithWood.Count; q++)
            {
                DestroyImmediate(enemiesWithWood[q].gameObject);
            }
        }
    }
}
