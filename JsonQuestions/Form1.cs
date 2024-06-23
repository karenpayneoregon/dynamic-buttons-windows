using System.ComponentModel;
using System.Runtime.InteropServices;
using JsonQuestions.Classes;
using JsonQuestions.Controls;
using Container = JsonQuestions.Models.Container;
#pragma warning disable CS0169 // Field is never used

#pragma warning disable IDE0305

namespace JsonQuestions;

public partial class Form1 : Form
{
    private BindingList<Container> _containers = new();
    private BindingSource _bindingSource = new();
    private Container _currentContainer;

    public Form1()
    {
        InitializeComponent();
        
        ButtonOperations.BaseName = "CategoryButton";


        var buttonSetup = new ButtonSetup
        {
            Control = this,
            Top = 20,
            BaseHeightPadding = 42,
            Left = 10,
            Width = 150,
            ButtonClick = ButtonClick,
            QuestionCount = 15
        };

        ButtonOperations.Initialize(buttonSetup);
        ButtonOperations.BuildButtons();
        var buttons = ButtonOperations.ButtonsList;

        foreach (var button in ButtonOperations.ButtonsList)
        {
            flowLayoutPanel1.Controls.Add(button);
        }

        _containers = new BindingList<Container>(ButtonOperations.Containers);
        _bindingSource.DataSource = _containers;
        
        QuestionLabel.DataBindings.Add("Text", _bindingSource, "Question");
        radioButtonA.DataBindings.Add("Text", _bindingSource, "A");
        radioButtonB.DataBindings.Add("Text", _bindingSource, "B");
        radioButtonC.DataBindings.Add("Text", _bindingSource, "C");
        radioButtonD.DataBindings.Add("Text", _bindingSource, "D");

        _currentContainer = _containers[0];

        var answer = _currentContainer.Answer;

        var rb = QuestionGroupBox.Controls.OfType<RadioButton>()
            .FirstOrDefault(x => x.Name.EndsWith(answer));

        rb.Tag = "Correct";
    }

    private void ButtonClick(object? sender, EventArgs e)
    {
        foreach (var radioButton in QuestionGroupBox.Controls.OfType<RadioButton>())
        {
            radioButton.Tag = null;
        }

        var button = (DataButton)sender!;
        _currentContainer = button.Container;

        var rb = QuestionGroupBox.Controls.OfType<RadioButton>()
            .FirstOrDefault(x => x.Name.EndsWith(_currentContainer.Answer));
        rb.Tag = "Correct";

        _bindingSource.Position = _containers.IndexOf(_currentContainer);

        foreach (var radioButton in QuestionGroupBox.RadioButtonList())
        {
            radioButton.Checked = false;
        }

    }

    private void AnswerButton_Click(object sender, EventArgs e)
    {
        var answer = QuestionGroupBox.RadioButtonChecked();
        if (answer is null) return;


        if (answer.Tag is not null)
        {
            MessageBox.Show("Correct");  
        }
        else
        {
            MessageBox.Show("Incorrect");
        }
    }
}
