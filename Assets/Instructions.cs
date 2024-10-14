using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] instructionPages; // Array of instruction page GameObjects
    private int currentPageIndex = 0;      // Tracks the current page index
    public Button nextButton;              // Reference to the Next button
    public Button prevButton;              // Reference to the Previous button
    public Button startButton;             // Reference to the Start button

    public GameObject instructionPanel;    // Reference to the Instruction panel
    
    void Start()
    {
        startButton.gameObject.SetActive(false); // Show the Start button
        instructionPanel.SetActive(true); // Show the instruction panel
        nextButton.gameObject.SetActive(true); // Show the Next button

        // Hide all instruction pages except the first one
        for (int i = 1; i < instructionPages.Length; i++)
        {
            instructionPages[i].SetActive(false);
        }        
        instructionPages[0].SetActive(true); // Show the first page
        
        nextButton.onClick.AddListener(NextPage); // Register the Next button with the NextPage method
        prevButton.onClick.AddListener(PreviousPage); // Register the Previous button with the NextPage method
        startButton.onClick.AddListener(RestartInstructions); // Register the Start button with a lambda function that hides the instruction panel
        
    }

    void RestartInstructions()
    {
        // Hide all instruction pages except the first one
        for (int i = 1; i < instructionPages.Length; i++)
        {
            instructionPages[i].SetActive(false);
        }

        // Show the first page
        instructionPages[0].SetActive(true);

        // Reset the current page index
        currentPageIndex = 0;

        // Show the Next button
        nextButton.gameObject.SetActive(true);

        // Hide the Start button
        startButton.gameObject.SetActive(false);

        // Show the instruction panel
        instructionPanel.SetActive(true);
    }
    void Update()
    {
        if (currentPageIndex == 0)
        {
            prevButton.gameObject.SetActive(false);
        }
        else
        {
            prevButton.gameObject.SetActive(true);
        }
    }
    void PreviousPage()
    {
        instructionPages[currentPageIndex].SetActive(false);
        currentPageIndex -= 1;
        instructionPages[currentPageIndex].SetActive(true);        
    }
    void NextPage()
    {
        if (currentPageIndex < instructionPages.Length - 1)
        {
            // Hide the current page
            instructionPages[currentPageIndex].SetActive(false);

            // Move to the next page (loop back to the first if at the end)
            currentPageIndex+=1 ;

            // Show the next page
            instructionPages[currentPageIndex].SetActive(true);
        } else {
            // Hide the instruction panel
            instructionPanel.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
    }
}
    

