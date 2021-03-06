//
// System.Web.UI.WebControls.GridViewRow.cs
//
// Authors:
//	Lluis Sanchez Gual (lluis@novell.com)
//
// (C) 2004-2010 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Security.Permissions;

namespace System.Web.UI.WebControls
{
	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class GridViewRow: TableRow, IDataItemContainer, INamingContainer
	{
		object dataItem;
		int rowIndex;
		int dataItemIndex;
		DataControlRowState rowState;
		DataControlRowType rowType;
		
		public GridViewRow (int rowIndex, int dataItemIndex, DataControlRowType rowType, DataControlRowState rowState)
		{
			this.rowIndex = rowIndex;
			this.dataItemIndex = dataItemIndex;
			this.rowType = rowType;
			this.rowState = rowState;
		}
		
		public virtual object DataItem {
			get { return dataItem; }
			set { dataItem = value; }
		}
		
		public virtual int DataItemIndex {
			get { return dataItemIndex; }
		}
		
		public virtual int RowIndex {
			get { return rowIndex; }
		}
		
		public virtual DataControlRowState RowState {
			get { return rowState; }
			set { rowState = value; }
		}
		
		public virtual DataControlRowType RowType {
			get { return rowType; }
			set { rowType = value; }
		}
		
		object IDataItemContainer.DataItem {
			get { return DataItem; }
		}
		
		int IDataItemContainer.DataItemIndex {
			get { return DataItemIndex; }
		}
		
		int IDataItemContainer.DisplayIndex {
			get { return RowIndex; }
		}
		
		protected override bool OnBubbleEvent (object source, EventArgs e)
		{
			if (base.OnBubbleEvent (source, e))
				return true;
			
			if (e is CommandEventArgs) {
				GridViewCommandEventArgs args = new GridViewCommandEventArgs (this, source, (CommandEventArgs)e);
				RaiseBubbleEvent (source, args);
				return true;
			}
			return false;
		}
	}
}

