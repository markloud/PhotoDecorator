using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecoratorPattern_PhotoDecorator
{
    /// <summary>
    /// Client
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() // acts as a simple client
        {
            // declare component and decorators
            Photo photo;
            TaggedPhoto colorTaggedPhoto, tag;
            BorderedPhoto composition;

            photo = new Photo();
            Application.Run(new Photo());
            
            colorTaggedPhoto = new TaggedPhoto(new TaggedPhoto(new TaggedPhoto(photo, "Mountain"), "breeze"), "Yellow");
            composition = new BorderedPhoto(colorTaggedPhoto, Color.Blue);
            Application.Run(composition);
            colorTaggedPhoto.AddedBehavior();

            photo = new Photo();
            tag = new TaggedPhoto(photo, "Tent");
            composition = new BorderedPhoto(tag, Color.Yellow);
            Application.Run(composition);
        }
    }
}