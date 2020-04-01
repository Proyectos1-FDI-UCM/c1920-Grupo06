using UnityEngine;

public class Lerp : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    [SerializeField] Transform startMarker;
    [SerializeField] Transform endMarker;


    // Movement speed in units per second.
    public float speed = 200.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private void Awake()
    {
        enabled = false;
    }

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }
    private void OnEnable()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }
}