using UnityEngine;
using TMPro;

public class Customer : MonoBehaviour, IUsable
{
    #region Properties
    // Variables
    [SerializeField] TMP_Text _custEquationText;
    [SerializeField] TMP_Text _custAnswerText;

    Equation _equation;
    string _input = "";
    int _index = 0;

    // Properties
    public Equation Equation { get { return _equation; } set { _equation = value; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Get Equation
        _equation = GameManager.Instance.GetEquation();

        // Change equation text
        _custEquationText.text = _equation.Question;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OnUse(scr_Player user)
    {
        // If user has item
        if (user.Inventory != null)
        {
            // Check answer
            CheckAnswer(user.Inventory);

            // Remove item
            Destroy(user.Inventory.gameObject);

            // Return good use
            return true;
        }

        // Return bad use
        return false;
    }

    void CheckAnswer(Item item)
    {
        // If solution[index] does not match the item value
        if (item.Value != _equation.Answer[_index])
        {
            // End function
            return;
        }

        // If solution[index] matches the item value, add value to answer string
        _input += item.Value;

        // Change answer text value to answer
        _custAnswerText.text = _input;

        // If player answer string is equal to solution string
        if (_input == _equation.Answer)
        {
            // Remove customer
            Destroy(gameObject);
        }

        // If player answer string not finished
        else
        {
            // Add to index
            _index++;
        }
    }
}