using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class MazeMenu : MonoBehaviour
{
    // Declaring bounding sizes as specified in the task description. 
    private const int MAX_SIZE = 250;
    private const int MIN_SIZE = 10;

    [SerializeField]
    private Slider widthSlider, heightSlider;

    [SerializeField]
    private InputField widthInput, heightInput;

    [SerializeField]
    private Toggle toggleButton;

    [SerializeField]
    private Text toggleText;

    [SerializeField]
    private MazeGenerator generator;

    [SerializeField]
    FadeAnimator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        widthInput.text     = "" + widthSlider.value;
        heightInput.text    = "" + heightSlider.value;
        generator.SetWidth ((int)widthSlider.value);
        generator.SetHeight((int)heightSlider.value);

        AddListeners();
        fadeAnimator.FadeIn();
    }

    /// <summary>
    /// Adds listeners to sliders and input fields.
    /// Converts values vice versa and passes them to generator.
    /// </summary>
    private void AddListeners()
    {
        // According to the API
        widthSlider.onValueChanged.AddListener(delegate {
            widthInput.text = "" + widthSlider.value;
            generator.SetWidth((int)widthSlider.value);

            if (toggleButton.isOn)
            {
                heightSlider.value = widthSlider.value;
                heightInput.text = "" + widthSlider.value;
                generator.SetWidth((int)widthSlider.value);
            }
        });

        heightSlider.onValueChanged.AddListener(delegate {
            heightInput.text = "" + heightSlider.value;
            generator.SetHeight((int)heightSlider.value);

            if (toggleButton.isOn)
            {
                widthSlider.value = heightSlider.value;
                widthInput.text = "" + heightSlider.value;
                generator.SetWidth((int)heightSlider.value);
            } 
        });

        widthInput.onEndEdit.AddListener(delegate {
            int.TryParse(widthInput.text, out int value);
            value = Mathf.Clamp(value, MIN_SIZE, MAX_SIZE);
            widthInput.text = "" + value;
            widthSlider.value = value;
            generator.SetWidth(value);

            if (toggleButton.isOn)
            {
                int.TryParse(heightInput.text, out value);
                heightInput.text = "" + value;
                heightSlider.value = value;
                generator.SetHeight(value);
            }
        });

        heightInput.onEndEdit.AddListener(delegate {
            int.TryParse(heightInput.text, out int value);
            value = Mathf.Clamp(value, MIN_SIZE, MAX_SIZE);
            heightInput.text = "" + value;
            heightSlider.value = value;
            generator.SetHeight(value);

            if (toggleButton.isOn)
            {
                int.TryParse(widthInput.text, out value);
                widthInput.text = "" + value;
                widthSlider.value = value;
                generator.SetWidth(value);
            }
        });
    }

    public void ToggleText()
    {
        if (toggleButton.isOn)
        {
            toggleText.text = "Even";
        }
        else
        {
            toggleText.text = "Uneven";
        }
    }
}
