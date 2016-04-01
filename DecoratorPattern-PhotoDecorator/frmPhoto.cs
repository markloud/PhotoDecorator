using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DecoratorPattern_PhotoDecorator
{
    public partial class Photo : Form
    {
        private Image image;

        public Photo()
        {
            image = new Bitmap(Application.StartupPath + @"\resource\tent.jpg");
            Size = new Size(1050, 650);
            Text = "Tent";
            Paint += new PaintEventHandler(Drawer);
            InitializeComponent();
        }

        public virtual void Drawer(Object source, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 30, 20);
        }
    }

    internal class BorderedPhoto : Photo // decorator with no interface, requires the operation to be virtual
    {
        private Photo photo;
        private Color color;

        public BorderedPhoto(Photo p, Color c)
        {
            photo = p;
            color = c;
        }

        public override void Drawer(Object source, PaintEventArgs e)
        {
            photo.Drawer(source, e);
            e.Graphics.DrawRectangle(new Pen(color, 10), 25, 15, 970, 550);
        }
    }

    internal class TaggedPhoto : Photo
    {
        private Photo photo;
        private string tag;
        private int number;
        private static int count;
        private List<string> tags = new List<string>();

        public TaggedPhoto(Photo p, string t)
        {
            photo = p;
            tag = t;
            tags.Add(t);
            number = ++count;
        }

        public override void Drawer(object source, PaintEventArgs e)
        {
            base.Drawer(source, e);
            e.Graphics.DrawString(tag,
                new Font("Arial", 16),
                new SolidBrush(Color.Black),
                new Point(120, 150 + number * 20));
        }

        public string ListTaggedPhotos()
        {
            var s = "Tags are: ";
            foreach (string t in tags) s += t + "";
            return s;
        }
    }
}