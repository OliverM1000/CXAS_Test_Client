using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI_v3
{
    public class OmColors
    {
		#region Variables
		//---------------------------------
		private static Color[] __ColorList = new Color[9] {	Color.Black,
															Color.Red,
															Color.Blue,
															Color.Green,
															Color.DarkOrange,
															Color.Magenta,
															Color.Cyan,
															Color.Purple,
															Color.Lime };
		//---------------------------------
		#endregion

		#region Properties
		//---------------------------------
		public static Color[] ColorList
		{
			get { return __ColorList; }
		}
		//---------------------------------
		#endregion

	}
}
