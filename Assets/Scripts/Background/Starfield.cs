using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;


public class Starfield : MonoBehaviour
{
    public int maxStars = 100;
    public float starSize = 0.1f;
    public float starSizeRange = 0.5f;
    public float fieldWidth = 20f;
    public float fieldHeight = 25f;
    public float parallaxFactor = 0f;
    public bool colorize = false;
    
    float xOffset;
    float yOffset;

    private ParticleSystem _particles;
    private ParticleSystem.Particle[] _stars;
    private Transform _theCamera;

    private void Awake()
    {
        _theCamera = Camera.main.transform;
        _stars = new ParticleSystem.Particle[maxStars];
        _particles = GetComponent<ParticleSystem>();
        
        Assert.IsNotNull(_particles, "Particle system missing from object!");
        // Offset the coordinates to distribute the spread
        xOffset = fieldWidth * 0.5f;  
        // around the object's center
        yOffset = fieldHeight * 0.5f;                                                                                                       

        for (var i = 0; i < maxStars; i++)
        {
            // Randomize star size within parameters
            var randSize = UnityEngine.Random.Range(1f - starSizeRange, starSizeRange + 1f);     
            // If coloration is desired, color based on size
            var scaledColor = (true == colorize) ? randSize - starSizeRange : 1f;    

            _stars[i].position = GetRandomInRectangle(fieldWidth, fieldHeight) + transform.position;
            _stars[i].startSize = starSize * randSize;
            _stars[i].startColor = new Color(1f, scaledColor, scaledColor, 1f);
        }
        // Write data to the particle system
        _particles.SetParticles(_stars, _stars.Length);                                                  
    }

    private void Update()
    {
        for (var i = 0; i < maxStars; i++)
        {
            var pos = _stars[i].position + transform.position;

            if (pos.x < (_theCamera.position.x - xOffset))
            {
                pos.x += fieldWidth;
            }
            else if (pos.x > (_theCamera.position.x + xOffset))
            {
                pos.x -= fieldWidth;
            }

            if (pos.y < (_theCamera.position.y - yOffset))
            {
                pos.y += fieldHeight;
            }
            else if (pos.y > (_theCamera.position.y + yOffset))
            {
                pos.y -= fieldHeight;
            }

            _stars[i].position = pos - transform.position;
        }
        _particles.SetParticles(_stars, _stars.Length);
        
        // Calculate the position of the object
        var newPos = _theCamera.position * parallaxFactor;  
        // Force Z-axis to zero, since we're in 2D
        newPos.z = 0;                                                                                                    
        transform.position = newPos;

    }

    // GetRandomInRectangle
    //----------------------------------------------------------
    // Get a random value within a certain rectangle area
    //
    private Vector3 GetRandomInRectangle(float width, float height)
    {
        var x = UnityEngine.Random.Range(0, width);
        var y = UnityEngine.Random.Range(0, height);
        return new Vector3(x - xOffset, y - yOffset, 0);
    }
}
