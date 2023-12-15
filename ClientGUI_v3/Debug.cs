using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI_v3
{
    public partial class Debug : Form
    {

		#region Variables
		//---------------------------------
		private Int32 __maxLineCount;
		//---------------------------------
		#endregion



		#region Properties
		//---------------------------------
		public Int32 MaxLineCount
		{
			get
			{
				return __maxLineCount;
			}
			set
			{
				if(value < 1)
					__maxLineCount = 1;
				__maxLineCount = value;
				ClearMaxLines();
			}
		}
		public Int32 MaxMessageLength { get; set; }
		//---------------------------------
		#endregion



		//==================================
		public Debug()
        {
            InitializeComponent();
			this.MaxLineCount = 1000;
			this.MaxMessageLength = 512;
			rtbConsole.Location = new Point(0, 0);
			rtbConsole.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
		}
		//==================================



		#region Private Methods
		//---------------------------------
		private void ClearMaxLines()		
		{
			Int32 n;

			n = rtbConsole.Lines.Count();
			if (n <= this.MaxLineCount)
				return;

			rtbConsole.Invoke(new EventHandler(delegate
			{
				rtbConsole.Select(0, rtbConsole.GetFirstCharIndexFromLine(n - this.MaxLineCount - 1));
				rtbConsole.SelectedText = "";

				rtbConsole.SelectionStart = rtbConsole.Text.Length;
				rtbConsole.ScrollToCaret();
			}));
			Application.DoEvents();
		}
		//---------------------------------
		#endregion


		#region Public Methods
		//---------------------------------
		public void AddLine(string _Line, Color _Color, FontStyle _Style)
		{			
			rtbConsole.Invoke(new EventHandler(delegate
			{				
				rtbConsole.SelectionColor = _Color;
				rtbConsole.SelectionFont = new Font("Franklin Gothic Book", 10, _Style);

				if (_Line.Length > MaxMessageLength)
					_Line = _Line.Substring(0, MaxMessageLength - 1) + "...\n";

				rtbConsole.AppendText(_Line);

				ClearMaxLines();

				rtbConsole.SelectionStart = rtbConsole.Text.Length;
				rtbConsole.ScrollToCaret();
			}));			
			Application.DoEvents();
		}
		public void AddString(string _Line, Color _Color, FontStyle _Style)
		{
			rtbConsole.Invoke(new EventHandler(delegate
			{				
				rtbConsole.SelectionColor = _Color;
				rtbConsole.SelectionFont = new Font("Courier New", 10, _Style);
				rtbConsole.AppendText(_Line);

				ClearMaxLines();

				rtbConsole.SelectionStart = rtbConsole.Text.Length;
				rtbConsole.ScrollToCaret();
			}));			
			Application.DoEvents();
		}
		public void Clear()
		{
			rtbConsole.Invoke(new EventHandler(delegate
			{
				rtbConsole.Clear();
			}));			
			Application.DoEvents();
		}


		//---------------------------------
		#endregion


	}
}
