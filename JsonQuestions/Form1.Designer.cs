namespace JsonQuestions;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        flowLayoutPanel1 = new FlowLayoutPanel();
        QuestionGroupBox = new GroupBox();
        AnswerButton = new Button();
        radioButtonD = new RadioButton();
        radioButtonC = new RadioButton();
        radioButtonB = new RadioButton();
        radioButtonA = new RadioButton();
        QuestionLabel = new Label();
        QuestionGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Dock = DockStyle.Top;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Padding = new Padding(8, 3, 0, 0);
        flowLayoutPanel1.Size = new Size(800, 125);
        flowLayoutPanel1.TabIndex = 0;
        // 
        // QuestionGroupBox
        // 
        QuestionGroupBox.Controls.Add(AnswerButton);
        QuestionGroupBox.Controls.Add(radioButtonD);
        QuestionGroupBox.Controls.Add(radioButtonC);
        QuestionGroupBox.Controls.Add(radioButtonB);
        QuestionGroupBox.Controls.Add(radioButtonA);
        QuestionGroupBox.Controls.Add(QuestionLabel);
        QuestionGroupBox.Location = new Point(12, 144);
        QuestionGroupBox.Name = "QuestionGroupBox";
        QuestionGroupBox.Size = new Size(776, 213);
        QuestionGroupBox.TabIndex = 1;
        QuestionGroupBox.TabStop = false;
        QuestionGroupBox.Text = "Question";
        // 
        // AnswerButton
        // 
        AnswerButton.Location = new Point(676, 171);
        AnswerButton.Name = "AnswerButton";
        AnswerButton.Size = new Size(94, 29);
        AnswerButton.TabIndex = 5;
        AnswerButton.Text = "Answer";
        AnswerButton.UseVisualStyleBackColor = true;
        AnswerButton.Click += AnswerButton_Click;
        // 
        // radioButtonD
        // 
        radioButtonD.AutoSize = true;
        radioButtonD.Location = new Point(16, 171);
        radioButtonD.Name = "radioButtonD";
        radioButtonD.Size = new Size(117, 24);
        radioButtonD.TabIndex = 4;
        radioButtonD.Text = "radioButton4";
        radioButtonD.UseVisualStyleBackColor = true;
        // 
        // radioButtonC
        // 
        radioButtonC.AutoSize = true;
        radioButtonC.Location = new Point(16, 138);
        radioButtonC.Name = "radioButtonC";
        radioButtonC.Size = new Size(117, 24);
        radioButtonC.TabIndex = 3;
        radioButtonC.Text = "radioButton3";
        radioButtonC.UseVisualStyleBackColor = true;
        // 
        // radioButtonB
        // 
        radioButtonB.AutoSize = true;
        radioButtonB.Location = new Point(16, 105);
        radioButtonB.Name = "radioButtonB";
        radioButtonB.Size = new Size(117, 24);
        radioButtonB.TabIndex = 2;
        radioButtonB.Text = "radioButton2";
        radioButtonB.UseVisualStyleBackColor = true;
        // 
        // radioButtonA
        // 
        radioButtonA.AutoSize = true;
        radioButtonA.Location = new Point(16, 72);
        radioButtonA.Name = "radioButtonA";
        radioButtonA.Size = new Size(117, 24);
        radioButtonA.TabIndex = 1;
        radioButtonA.Text = "radioButton1";
        radioButtonA.UseVisualStyleBackColor = true;
        // 
        // QuestionLabel
        // 
        QuestionLabel.AutoSize = true;
        QuestionLabel.Location = new Point(16, 38);
        QuestionLabel.Name = "QuestionLabel";
        QuestionLabel.Size = new Size(68, 20);
        QuestionLabel.TabIndex = 0;
        QuestionLabel.Text = "Question";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(QuestionGroupBox);
        Controls.Add(flowLayoutPanel1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Questions/Answers";
        QuestionGroupBox.ResumeLayout(false);
        QuestionGroupBox.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel flowLayoutPanel1;
    private GroupBox QuestionGroupBox;
    private RadioButton radioButtonD;
    private RadioButton radioButtonC;
    private RadioButton radioButtonB;
    private RadioButton radioButtonA;
    private Label QuestionLabel;
    private Button AnswerButton;
}
