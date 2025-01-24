using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleEnemy))]
    public class SimpleEnemyInspector :  Editor
    {
        public override void OnInspectorGUI()
        {
            SimpleEnemy controller = (SimpleEnemy)target;
            DrawDefaultInspector();

            
            if (GUILayout.Button("Kill"))
            {
                controller.Kill();
                controller.SpawnFish();
            }
        }
    }
