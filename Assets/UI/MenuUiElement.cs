using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuUiElement : MonoBehaviour
{
    public VisualElement ui;
    
    public Move player;
    
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        
    }

    private void OnEnable()
    {
        playButton = ui.Q<Button>("Play");
        playButton.clicked += PlayButtonOnclicked;
        
        optionsButton = ui.Q<Button>("Settings");
        optionsButton.clicked += OptionButtonOnclicked;
        
        exitButton = ui.Q<Button>("Exit");
        exitButton.clicked += ExitButtonOnclicked;
    }

    private void PlayButtonOnclicked()
    {
        gameObject.SetActive(false);
        player.CursorToggler(true);
        player.IsMenuOpen = false;
    }

    private void OptionButtonOnclicked()
    {
        Debug.Log("No options:)");
    }

    private void ExitButtonOnclicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }
    
    
}