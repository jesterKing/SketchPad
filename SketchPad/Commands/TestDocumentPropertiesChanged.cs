using System;
using Rhino;
using Rhino.Commands;
using Rhino.Display;
using Rhino.DocObjects;

namespace SketchPad.Commands
{
	public class TestDocumentPropertiesChanged : Command
	{
		static TestDocumentPropertiesChanged _instance;
		public TestDocumentPropertiesChanged()
		{
			_instance = this;
		}

		///<summary>The only instance of the TestDocumentPropertiesChanged command.</summary>
		public static TestDocumentPropertiesChanged Instance
		{
			get { return _instance; }
		}

		public override string EnglishName
		{
			get { return "TestDocumentPropertiesChanged"; }
		}

		private uint docSerial = uint.MaxValue;
		private bool subscribed = false;
		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			if (!subscribed) {
				docSerial = doc.RuntimeSerialNumber;
				RhinoDoc.DocumentPropertiesChanged += RhinoDoc_DocumentPropertiesChanged;
				RhinoView.SetActive += RhinoView_SetActive;
			} else
			{
				docSerial = uint.MaxValue;
				RhinoDoc.DocumentPropertiesChanged -= RhinoDoc_DocumentPropertiesChanged;
				RhinoView.SetActive -= RhinoView_SetActive;
			}
			subscribed = !subscribed;
			return Result.Success;
		}

		private void RhinoView_SetActive(object sender, ViewEventArgs e)
		{
			if (e.View != null && e.View.ActiveViewport != null) {
				var vi = new ViewInfo(e.View.ActiveViewport);
				RhinoApp.WriteLine($"{vi.FocalBlurDistance} & {vi.FocalBlurAperture}");
			}
		}

		private void RhinoDoc_DocumentPropertiesChanged(object sender, DocumentEventArgs e)
		{
			RhinoApp.WriteLine($"Document properties changed for {e.DocumentSerialNumber}");
		}
	}
}