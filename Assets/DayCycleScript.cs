using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class DayCycleScript : MonoBehaviour
{

    [Header("Positioning")]
    public float scaleX = 10f;
    public float scaleY = 7f;
    [Header("Timing")]
    //public float speed = 4f;
    public float timeUntilCommander = 10f;
    //Added 2019-03-18
    public float time;

    private Vector3 initialPos = new Vector3();
    private Vector3 tmpPos = new Vector3();

    [Header("Light")]
    private Light lightComponent;
    private HDAdditionalLightData hdLight;
    public float sunDownColorTemperature = 2000f;
    public float sunDownBrightnessLux = 550;
    public float sunUpColorTemperature = 5000f;
    public float sunUpBrightnessLux = 350;
    // Start is called before the first frame update
    void Start()
    {
        initialPos.Set(transform.position.x, transform.position.y, transform.position.z);
        lightComponent = this.GetComponent<Light>();
        hdLight = this.GetComponent<HDAdditionalLightData>();

        //Added 2019-03-18
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Time.frameCount % 2 == 0) {
        //float time = (Time.time < timeUntilCommander ? Time.time : timeUntilCommander);
            //Added 2019-03-18
            time = (time > timeUntilCommander ? time : time + Time.deltaTime);

            float timeRange = time / timeUntilCommander;
            float timeSin = Mathf.Sin(timeRange * Mathf.PI);
            float timeCos = Mathf.Cos(timeRange * Mathf.PI);

            // Set the sun position
            float waveX = timeCos;
            float waveY = timeSin;
            tmpPos.Set(waveX * scaleX, waveY * scaleY, 0f);

            tmpPos.Set(initialPos.x + tmpPos.x, initialPos.y + tmpPos.y, initialPos.z);
            transform.position = tmpPos;

            // Set the sun color and intensity
            lightComponent.colorTemperature = Mathf.Lerp(sunDownColorTemperature, sunUpColorTemperature, timeSin);
            hdLight.intensity = Mathf.Lerp(sunDownBrightnessLux, sunUpBrightnessLux, timeSin);
        //}
    }
}
