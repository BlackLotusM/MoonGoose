using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Waypoints
{
    public string name;
    [SerializeField]
    public int index;
    [SerializeField]
    public Transform waypointTransform;
    public Targets targets;
}

[System.Serializable]
public class Targets
{
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;
}

public class receiveEvent : EditorWindow
{
    [MenuItem("Examples/Receive Event")]
    static void Init()
    {
        receiveEvent window =
            EditorWindow.GetWindow<receiveEvent>(true, "Receive Event Window");
        window.Show();
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.commandName == "Paste")
            Debug.Log("Paste received");
    }
}

[CustomPropertyDrawer(typeof(Waypoints))]
public class IngredientDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var amountRect_1 = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        var amountRect_2 = new Rect(position.x + position.width / 2, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        var amountRect_3 = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 7, position.width / 2, EditorGUIUtility.singleLineHeight);
        var amountRect_4 = new Rect(position.x + position.width / 2 +  20, position.y + EditorGUIUtility.singleLineHeight + 7, position.width / 2, EditorGUIUtility.singleLineHeight);

        var target1 = new Rect(position.x + position.width / 2 , position.y + EditorGUIUtility.singleLineHeight * 2 + 7, position.width / 2, EditorGUIUtility.singleLineHeight);
        var target2 = new Rect(position.x + position.width / 2 , position.y + EditorGUIUtility.singleLineHeight * 3 + 10, position.width / 2 , EditorGUIUtility.singleLineHeight);
        var target3 = new Rect(position.x + position.width / 2 , position.y + EditorGUIUtility.singleLineHeight * 4 + 13, position.width / 2, EditorGUIUtility.singleLineHeight);
        var target4 = new Rect(position.x + position.width / 2 , position.y + EditorGUIUtility.singleLineHeight * 5 + 16, position.width / 2, EditorGUIUtility.singleLineHeight);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUIUtility.labelWidth = 40f;
        EditorGUI.PropertyField(amountRect_1, property.FindPropertyRelative("name"), new GUIContent("Name"));
        EditorGUI.PropertyField(amountRect_2, property.FindPropertyRelative("index"), new GUIContent(" Index"));
        EditorGUIUtility.labelWidth = 60f;
        EditorGUI.PropertyField(amountRect_3, property.FindPropertyRelative("waypointTransform"), new GUIContent("Transform"));

        property.isExpanded = EditorGUI.Foldout(amountRect_4, property.isExpanded, "Targets");
        property.FindPropertyRelative("targets");
        if (property.isExpanded)
        {
            EditorGUI.PropertyField(target1, property.FindPropertyRelative("targets.left"), new GUIContent(" Left"));
            EditorGUI.PropertyField(target2, property.FindPropertyRelative("targets.right"), new GUIContent(" Right"));
            EditorGUI.PropertyField(target3, property.FindPropertyRelative("targets.up"), new GUIContent(" Up"));
            EditorGUI.PropertyField(target4, property.FindPropertyRelative("targets.down"), new GUIContent(" Down"));
        }

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return property.isExpanded ? 18f * 7 : 52;
    }
}


public class CameraPositioner : MonoBehaviour
{
    private void OnValidate()
    {
        if (waypointPath.ToList().Count != waypointPath.ToList().Distinct().Count())
        {
            Debug.Log("ree");
        }

        foreach (SceneView scene in SceneView.sceneViews)
        {
            scene.ShowNotification(new GUIContent("Duplicate has been found!!!!"));
        }
    }

    public int currentIndex;
    public Waypoints[] waypointPath;
    [SerializeField]
    private Camera mainCam;
    private IEnumerator running;
    public float time;
    public bool done = true, atObject;

    //TEMP MOVE TO BETTER PLACE
    public GameObject canvasMap;

    private void Start()
    {
        mainCam = Camera.main;
        //currentIndex = 0;

        //Setup start postion waypoint 1
        mainCam.transform.position = waypointPath[currentIndex].waypointTransform.transform.position;
        mainCam.transform.rotation = waypointPath[currentIndex].waypointTransform.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //TEMP MOVE TO BETTER PLACE
        if (Input.GetKeyDown(KeyCode.M))
        {
            canvasMap.SetActive(!canvasMap.activeSelf);
        }
        if (atObject)
            return;

        // Scrol function To-Do check for solution if branche
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Mouse ScrollWheel") > 0f)
            currentDown();
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Mouse ScrollWheel") < 0f)
            currentUp();
    }

    public void currentUp()
    {
        ///if (currentIndex + 1 <= cameraData.cameraPosition.Length - 1)
        ///{
        ///    if (running != null)
        ///        StopCoroutine(running);
        ///    //Could be added to wait for corooutine to be finished
        ///    //return;
        ///    currentIndex++;
        ///    done = false;
        ///    running = MoveCamTo();
        ///    StartCoroutine(running);
        ///}
    }

    public void currentDown()
    {
        if (currentIndex - 1 > -1)
        {
            if (running != null)
                StopCoroutine(running);
            //Could be added to wait for corooutine to be finished
            //return;
            currentIndex--;
            done = false;
            running = MoveCamTo();
            StartCoroutine(running);
        }
    }

    public void targetIndex(int target)
    {
        canvasMap.SetActive(false);
        ///if (target > -1 && target <= cameraData.cameraPosition.Length - 1)
        ///{
        ///    if (running != null)
        ///        StopCoroutine(running);
        ///    currentIndex = target;
        ///    done = false;
        ///    running = MoveCamTo();
        ///    StartCoroutine(running);
        ///}
    }

    public IEnumerator MoveCamTo()
    {
        Vector3 startingPos = mainCam.transform.position;
        //Vector3 finalPos;/// = cameraData.cameraPosition[currentIndex].cameraPos.transform.position;

        Quaternion startingRotation = mainCam.transform.rotation;
        //Quaternion finalRotation;/// = cameraData.cameraPosition[currentIndex].cameraPos.transform.rotation;

        ///if (Vector3.Distance(startingPos, finalPos) < 0.1 && Quaternion.Angle(startingRotation, finalRotation) < 0.1)
        ///{
        ///    done = true;
        ///    yield break;
        ///}

        time = 0.89f;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            ///mainCam.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            ///mainCam.transform.rotation = Quaternion.Lerp(startingRotation, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //Could be added to add wait till end reached
        //running = null;
        done = true;
    }

    public IEnumerator MoveCamToObject(Transform camPos)
    {
        time = 0.6f;
        Vector3 startingPos = mainCam.transform.position;
        Vector3 finalPos = camPos.position;

        Quaternion startingRotation = mainCam.transform.rotation;
        Quaternion finalRotation = camPos.rotation;

        if (Vector3.Distance(startingPos, finalPos) < 0.1 && Quaternion.Angle(startingRotation, finalRotation) < 0.1)
        {
            done = true;
            yield break;
        }

        time = Vector3.Distance(startingPos, finalPos) / 10;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mainCam.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            mainCam.transform.rotation = Quaternion.Lerp(startingRotation, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        done = true;
    }
}
