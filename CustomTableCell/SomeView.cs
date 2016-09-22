
using Foundation;
using System;
using UIKit;
using ObjCRuntime;
namespace CustomTableCell
{
    public partial class SomeView : UIView
    {
        public SomeView (IntPtr handle) : base (handle)
        {
        }
		public static SomeView Create()
		{

			var arr = NSBundle.MainBundle.LoadNib("View", null, null);
			var v = Runtime.GetNSObject<SomeView>(arr.ValueAt(0));

			return v;
		}

		public override void AwakeFromNib()
		{

			MyLable.Text = "hello from the SomeView class";
		}
    }
}