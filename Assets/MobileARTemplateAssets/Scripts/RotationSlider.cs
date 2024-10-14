using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RotationSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject target;
    public float speed = 1.0f;    
    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderChanged);
        
    }
    void OnSliderChanged(float value){
        target.transform.rotation = Quaternion.Euler(0, value, 0);        
    }
    // Update is called once per frame
    void Update()
    {
        target.transform.Rotate(Vector3.up, speed * Time.deltaTime);
        
    }
}
