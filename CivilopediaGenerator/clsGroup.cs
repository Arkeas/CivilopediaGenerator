using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CivilopediaGenerator
{
	public class GroupItem
	{
		private string _strKey = "";
		private string _strName = "";
		private string _strImage = "";

		public GroupItem()
		{
		}

		/// <summary>
		/// Key.
		/// </summary>
		public string Key
		{
			get
			{
				return _strKey;
			}
			set
			{
				_strKey = value;
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name
		{
			get
			{
				return _strName;
			}
			set
			{
				_strName = value;
			}
		}

		/// <summary>
		/// Image.
		/// </summary>
		public string Image
		{
			get
			{
				return _strImage;
			}
			set
			{
				_strImage = value;
			}
		}
	}

	public class Group
	{
		private string _strKey = "";
		private string _strName = "";
		private List<GroupItem> _lstItems = new List<GroupItem>();

		public Group()
		{
		}

		public string Key
		{
			get
			{
				return _strKey;
			}
			set
			{
				_strKey = value;
			}
		}

		public string Name
		{
			get
			{
				return _strName;
			}
			set
			{
				_strName = value;
			}
		}

		public List<GroupItem> GroupItems
		{
			get
			{
				return _lstItems;
			}
			set
			{
				_lstItems = value;
			}
		}

		public void Sort()
		{
			_lstItems.Sort(delegate(GroupItem p1, GroupItem p2) { return p1.Name.CompareTo(p2.Name); });
		}
	}

	public class SortByName : IComparer
	{
		public int Compare(object objX, object objY)
		{
			Group objGroupX = (Group)objX;
			Group objGroupY = (Group)objY;

			return string.Compare(objGroupX.Name, objGroupY.Name);
		}
	}
}
