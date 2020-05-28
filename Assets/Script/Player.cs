using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rigidbody;
    public ParticleSystem BottomThrust;
    public ParticleSystem LeftThrust;
    public ParticleSystem RightThrust;
    public Slider fuelBar;
    public float fuel = 1.00f;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
       fuelBar.value = fuel; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetAxis("Vertical")> 0.01f)
        {
            if(fuel>0.0f){
            rigidbody.AddForce(transform.up * 15.0f);
            fuel += -0.1f * Time.deltaTime;
            fuelBar.value = fuel;

            if(!BottomThrust.isPlaying)
            {
                BottomThrust.Play();
            }
        }
            
            else if(BottomThrust.isPlaying){
                BottomThrust.Stop();
            }
        }
        if(Input.GetAxis("Horizontal") > 0.01f || Input.GetAxis("Horizontal") < -0.01f){

            if(fuel>0.0f){
            rigidbody.AddForce((transform.right *6.0f) * Input.GetAxis("Horizontal"));
            fuel += -0.1f * Time.deltaTime;
            fuelBar.value = fuel;

            if(!LeftThrust.isPlaying && Input.GetAxis("Horizontal") > 0.01f ){
                LeftThrust.Play();
            }else if(!RightThrust.isPlaying && Input.GetAxis("Horizontal") < -0.01f ){
                RightThrust.Play();
            }
        }

            
        }

            if(LeftThrust.isPlaying && Input.GetAxis("Horizontal") < 0.01f){
                LeftThrust.Stop();
            }
            if(RightThrust.isPlaying && Input.GetAxis("Horizontal") > -0.01f){
                RightThrust.Stop();
            }

            if((RightThrust.isPlaying || LeftThrust.isPlaying || BottomThrust.isPlaying) && !audio.isPlaying){
                audio.Play();
            }else if((!RightThrust.isPlaying || !LeftThrust.isPlaying || !BottomThrust.isPlaying) && audio.isPlaying){
                audio.Stop();
            }


        // }
    }

}
