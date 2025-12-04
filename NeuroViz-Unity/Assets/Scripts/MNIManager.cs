using UnityEngine;
using UnityEngine.UI;

public class MNIManager : MonoBehaviour
{

    public GameObject mniMarker;
    public Transform mniOrigin;
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;

    private const float ONE_UNIT_INCREMENT = 0.01f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Updates the position of the coordinate marker based on slider input <br/>
    /// In MNI: <br/>
    ///     x-axis is left to right (smaller to larger) <br/>
    ///     y-axis is back to front (smaller to larger) <br/>
    ///     z-axis is down to up (smaller to larger) <br/>
    /// We are using 1mm resolution here, so 1 MNI unit is 1mm <br/>
    /// The brain model is scaled 10x in the scene, so increment will be 10mm = 1cm = 0.01m
    /// </summary>
    public void UpdateMNIMarkerPosition()
    {
        Vector3 mniCoordinatesInUnitySpace = new Vector3(xSlider.value * ONE_UNIT_INCREMENT, zSlider.value * ONE_UNIT_INCREMENT, ySlider.value * ONE_UNIT_INCREMENT);
        mniMarker.transform.position = mniOrigin.position + mniCoordinatesInUnitySpace;
    }
}
