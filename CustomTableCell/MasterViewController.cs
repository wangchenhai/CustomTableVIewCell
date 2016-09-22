using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace CustomTableCell
{
    public partial class MasterViewController : UITableViewController
    {
        DataSource dataSource;
		SomeView v;
        public MasterViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            addButton.AccessibilityLabel = "addButton";
            NavigationItem.RightBarButtonItem = addButton;



            TableView.RegisterNibForCellReuse(UINib.FromName("Myell", null), "Myell");
            TableView.Source = dataSource = new DataSource(this);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void AddNewItem(object sender, EventArgs args)
        {
            dataSource.Users.Insert(0, new User { Name = "a", Sex = "m" });

            using (var indexPath = NSIndexPath.FromRowSection(0, 0))
                TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = dataSource.Users[indexPath.Row];

                ((DetailViewController)segue.DestinationViewController).SetDetailItem(item);
            }
        }

        class DataSource : UITableViewSource
        {
	
			public List<User> Users = UserRepository.GetUsers();
					

            readonly MasterViewController controller;

            public DataSource(MasterViewController controller)
            {
                this.controller = controller;
            }


            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Users.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
				var User = Users[indexPath.Row];
				var cell = tableView.DequeueReusableCell(new NSString("Myell"), indexPath) as Myell;
				if (cell == null)
				{
					cell = Myell.Create();
				}
				//cell.TextLabel.Text = objects[indexPath.Row].ToString();
				cell.Model = User;
                return cell;	
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return true;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    Users.RemoveAt(indexPath.Row);
                    controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }
        }
    }
}

