using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ============================================================================
// 🔹 Understanding "e" in Event Handlers
// ============================================================================
//
// In any event handler like:
//
//      private void Button_Click(object sender, EventArgs e)
//
// The parameters mean:
//
//   • sender → The object that raised the event (ex: the Button that was clicked)
//   • e       → The "event arguments" object — it carries extra information
//                about what exactly happened.
//
// ----------------------------------------------------------------------------
// 🧩 Think of it like this:
//
//   Event   = Notification
//   sender  = Who sent it
//   e       = What details came with it
//
// ----------------------------------------------------------------------------
// 🧠 Common Examples:
//
// 1️⃣ Click Event
//      private void button1_Click(object sender, EventArgs e)
//      → e is plain EventArgs (no extra info)
//
// 2️⃣ Mouse Event
//      private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
//      → e contains details like:
//          e.Button   // Which mouse button was clicked (Left, Right, Middle)
//          e.X, e.Y   // Cursor position
//          e.Delta    // Scroll wheel info
//
// 3️⃣ Keyboard Event
//      private void Form1_KeyDown(object sender, KeyEventArgs e)
//      → e contains:
//          e.KeyCode   // Which key was pressed
//          e.Control   // Whether CTRL is held
//          e.Shift     // Whether SHIFT is held
//
// 4️⃣ Paint Event
//      private void Form1_Paint(object sender, PaintEventArgs e)
//      → e contains:
//          e.Graphics      // The drawing surface
//          e.ClipRectangle // The area being redrawn
//
// ----------------------------------------------------------------------------
// ⚙️ Summary Table:
//
// | Event Type     | e Type            | What It Contains                        |
// |----------------|------------------|------------------------------------------|
// | Click          | EventArgs        | No extra info                            |
// | Mouse Events   | MouseEventArgs   | Button, coordinates, scroll info         |
// | Key Events     | KeyEventArgs     | Key pressed, modifier keys               |
// | Paint          | PaintEventArgs   | Graphics context, clip rectangle         |
// | Timer Tick     | EventArgs        | No extra info                            |
//
// ----------------------------------------------------------------------------
// 💡 In general:
//
// "e" stands for "event arguments"
// → It’s a data package that holds event-specific info.
//
// "EventArgs" is the base class; special events inherit from it:
//    MouseEventArgs, KeyEventArgs, PaintEventArgs, etc.
//
// ============================================================================



namespace _57___Draw_Line___ellipse___and_rectangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Color Black = Color.FromArgb(255, 0, 0, 0);   // we can chose colors with argp.
            Color Black = Color.Black;     // or from the Color struct ready properties;

            Pen pen = new Pen(Black);      // create a pen with the color we created
            pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;   // there are the start and end of the to draw line shape 
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 100, 100, 100, 200);
            e.Graphics.DrawRectangle(pen, 200, 100, 300, 200);
        }

        // use this method to see x,y points on the form name 
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X = {e.X} , Y = {e.Y}";
        }
    }
}
