using System;
using System.Windows.Forms;

namespace _100__Introduction_to_Custom_Controls
{
    // inherit from TextBox to create a custom control with extended features
    public partial class CustomTextBox : TextBox
    {
        public enum TrueFalse
        {
            True,
            False
        }
       

        public TrueFalse IsRequired { get; set; } = TrueFalse.False;
        public TrueFalse OnlyNumbers { get; set; } = TrueFalse.False;

        public CustomTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (IsRequired == TrueFalse.True && string.IsNullOrWhiteSpace(this.Text))
            {
                e.Cancel = true;
                this.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("This field is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
            }
            base.OnValidating(e);

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (OnlyNumbers == TrueFalse.True && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnKeyPress(e);
        }

        /*
    ================================================================================
      HOW THE BASE CONTROL HANDLES OS SIGNALS WITHOUT OVERRIDING
    ================================================================================

    1. DIRECT ANSWER
    --------------------------------------------------------------------------------
    YES, EXACTLY.

    Whether you override `OnValidating` or not, the OS ALWAYS sends its raw window 
    message (focus lost signal) to the control.

    If you DO NOT override `OnValidating`:
    - The default `TextBox` base class built into .NET receives the OS signal.
    - It executes its default, un-overridden `OnValidating` method.
    - It checks if any external code (like `Form.cs`) subscribed to the `Validating` event.
    - If a subscription exists, it fires the event. If not, it simply does nothing extra.

    Overriding simply allows you to INTERCEPT that automatic pipeline and inject 
    your custom internal logic (like turning the box red) before the standard base 
    class code finishes.


    2. THE PIPELINE: WITH OVERRIDING vs. WITHOUT OVERRIDING
    --------------------------------------------------------------------------------

    SCENARIO A: NO OVERRIDE (Standard TextBox out of the box)
    --------------------------------------------------------
    [ OS Focus Lost Signal ] 
             │
             ▼
    [ Base TextBox.WndProc() ]  <-- Receives OS message
             │
             ▼
    [ Base TextBox.OnValidating() ]  <-- Standard framework method runs
             │
             ▼
    Checks: Did Form.cs write `txt.Validating += ...`?
             ├── YES --> Executes Form.cs method.
             └── NO  --> Does nothing. (Control remains unchanged).


    SCENARIO B: WITH OVERRIDE (Your CustomTextBox)
    -----------------------------------------------
    [ OS Focus Lost Signal ] 
             │
             ▼
    [ Base TextBox.WndProc() ]  <-- Receives OS message
             │
             ▼
    [ YOUR CustomTextBox.OnValidating() ]  <-- INTERCEPTED!
             │
             ├── 1. YOUR CODE RUNS FIRST (Turns text box RED).
             │
             └── 2. You call `base.OnValidating(e)`
                          │
                          ▼
            [ Base TextBox.OnValidating() ]  <-- Resumes normal framework path
                          │
                          ▼
            Checks: Did Form.cs write `txt.Validating += ...`?
                     ├── YES --> Executes Form.cs method SECOND.
                     └── NO  --> Does nothing. (Text box stays RED!).


    4. SUMMARY RECAP
    --------------------------------------------------------------------------------
    - The OS message pipeline NEVER stops running—it sends focus, mouse, and keyboard 
      signals to every window on screen constantly.
    - `OnX` methods exist in the base .NET control by default to handle those signals.
    - Overriding `OnX` does not create the pipeline; it just gives you a hook to 
      customize what happens inside that pipeline!
    */
    }
}
