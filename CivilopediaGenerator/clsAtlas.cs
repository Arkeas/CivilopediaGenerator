using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivilopediaGenerator
{
	class Atlas
	{
		private string _strAtlas = "";
		private int _intSize = 256;
		private string _strFilename = "";
		private int _intIconsPerRow = 0;
		private int _intIconsPerColumn = 0;

		/// <summary>
		/// Name of the Atlas as it appears in the XML files.
		/// </summary>
		public string Name
		{
			get
			{
				return _strAtlas;
			}
			set
			{
				_strAtlas = value;
			}
		}

		/// <summary>
		/// Size of the icons in pixels the Atlas contains.
		/// </summary>
		public int IconSize
		{
			get
			{
				return _intSize;
			}
			set
			{
				_intSize = value;
			}
		}

		/// <summary>
		/// Name of the png file.
		/// </summary>
		public string Filename
		{
			get
			{
				return _strFilename.Replace(".dds", ".png");
			}
			set
			{
				_strFilename = value;
			}
		}

		/// <summary>
		/// Number of icons that appear in each row of the Atlas.
		/// </summary>
		public int IconsPerRow
		{
			get
			{
				return _intIconsPerRow;
			}
			set
			{
				_intIconsPerRow = value;
			}
		}

		/// <summary>
		/// Number of icons that appear in each column of the Atlas.
		/// </summary>
		public int IconsPerColumn
		{
			get
			{
				return _intIconsPerColumn;
			}
			set
			{
				_intIconsPerColumn = value;
			}
		}
	}
}
