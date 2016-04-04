using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DecoratorPattern_PhotoDecorator
{
    /// <summary>
    /// IComponent Interface
    /// </summary>
    interface IDrawable
    {
        void Drawer(Object source, PaintEventArgs e);
    }

    /// <summary>
    /// Component
    /// </summary>
    public partial class Photo : Form, IDrawable
    {
        private Image image;

        public Photo()
        {
            image = new Bitmap(Application.StartupPath + @"\resource\tent.jpg");
            Size = new Size(1050, 650);
            Text = "Tent";
            Paint += new PaintEventHandler(Drawer);
        }

        public void Drawer(Object source, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 30, 20);
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    internal class BorderedPhoto : Photo, IDrawable // decorator with no interface, requires the operation to be virtual
    {
        IDrawable photo;
        Color color;

        public BorderedPhoto(IDrawable p, Color c)
        {
            photo = p;
            color = c;
            Paint += new PaintEventHandler(Drawer);
        }

        new public void Drawer(Object source, PaintEventArgs e)
        {
            photo.Drawer(source, e);
            e.Graphics.DrawRectangle(new Pen(color, 10), 25, 15, 970, 550);
        }
    }

    /// <summary>
    /// Decorator with added behavior
    /// </summary>
    class TaggedPhoto : Photo, IDrawable
    {
        IDrawable photo;
        string tag;
        int number;
        static int count;
        List<string> tags = new List<string>();

        public TaggedPhoto(IDrawable p, string t)
        {
            photo = p;
            tag = t;
            tags.Add(t);
            number = ++count;
            Paint += new PaintEventHandler(Drawer);
        }

        new public void Drawer(object source, PaintEventArgs e)
        {
            photo.Drawer(source, e);
            e.Graphics.DrawString(tag,
                new Font("Arial", 16),
                new SolidBrush(Color.Black),
                new Point(120, 150 + number * 20));
        }

        public void AddedBehavior() // Added Behavior
        {
            MessageBox.Show("Added Behavior from Tagged Photos Object");
        }
    }
}