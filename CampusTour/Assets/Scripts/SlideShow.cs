using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlideShow : MonoBehaviour
{
    public Sprite[] images; // An array to hold the images to be displayed
    public Image imageDisplay; // Reference to the Image component on the GameObject

    public float timeBetweenSlides = 2f; // Time between slides in seconds
    private int currentIndex = 0; // Index to keep track of the current image

    // Start is called before the first frame update
    void Start()
    {
        if (images.Length > 0)
        {
            // Start the slideshow
            StartCoroutine(PlaySlideShow());
        }
    }

    IEnumerator PlaySlideShow()
    {
        while (true)
        {
            // Display the current image
            imageDisplay.sprite = images[currentIndex];

            // Move to the next image
            currentIndex = (currentIndex + 1) % images.Length;

            // Wait for the specified time before showing the next image
            yield return new WaitForSeconds(timeBetweenSlides);
        }
    }
}