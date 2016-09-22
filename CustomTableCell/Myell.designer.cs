// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CustomTableCell
{
    [Register ("Myell")]
    partial class Myell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Sex { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }

            if (Sex != null) {
                Sex.Dispose ();
                Sex = null;
            }
        }
    }
}