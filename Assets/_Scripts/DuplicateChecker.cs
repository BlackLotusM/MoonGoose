#if (UNITY_EDITOR) 
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class DuplicateChecker : MonoBehaviour
{
    public CameraManager cam;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        var query = cam.waypointPath.GroupBy(x => x.index)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

        if (query.Count > 0)
        {
            foreach (SceneView scene in SceneView.sceneViews)
            {
                scene.ShowNotification(new GUIContent("index duplicate has been found in WaypointPath"));
            }
        }
    }
}
#endif