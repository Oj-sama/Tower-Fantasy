using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour

{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color changeColor = Color.grey;
    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }
    void Update()
    {
        ToggleLabels();
        if (!Application.isPlaying)
        {

            DisplayCoordinates();

            ParentName();
        }

        ColorCoordinates();

    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            label.enabled = !label.IsActive();
        }
    }
    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = changeColor;
        }
    }
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void ParentName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
