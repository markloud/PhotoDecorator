using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecoratorPattern_PhotoDecorator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() // acts as a simple client
        {
            Photo photo;
            TaggedPhoto foodTaggedPhoto, colorTaggedPhoto, tag;
            BorderedPhoto composition;

            photo = new Photo();
            Application.Run(new Photo());

            foodTaggedPhoto = new TaggedPhoto(photo, "Food");
            colorTaggedPhoto = new TaggedPhoto(foodTaggedPhoto, "Yellow");
            composition = new BorderedPhoto(colorTaggedPhoto, Color.Blue);
            Application.Run(composition);
            MessageBox.Show(colorTaggedPhoto.ListTaggedPhotos());

            photo = new Photo();
            tag = new TaggedPhoto(photo, "Tent");
            composition = new BorderedPhoto(tag, Color.Yellow);
            Application.Run(composition);
        }
    }
}