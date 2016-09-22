using System;

using Foundation;
using UIKit;

namespace CustomTableCell
{
	public partial class Myell : UITableViewCell
	{
		public User Model { get; set;}

		public static readonly UINib Nib = UINib.FromName("Myell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("MyID");

		public Myell(IntPtr handle) : base (handle)
		{
		}

		public static Myell Create()
		{
			return (Myell)Nib.Instantiate(null, null)[0];
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			this.Name.Text = Model.Name;
			this.Sex.Text = Model.Sex;

		}
	}
}
