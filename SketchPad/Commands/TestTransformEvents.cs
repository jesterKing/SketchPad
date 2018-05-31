using System;
using Rhino;
using Rhino.Commands;

namespace SketchPad.Commands
{
	public class TestTransformEvents : Command
	{
		private static TestTransformEvents _instance;
		public TestTransformEvents()
		{
			if(_instance==null) _instance = this;
		}

		///<summary>The only instance of the TestTransformEvents command.</summary>
		public static TestTransformEvents Instance
		{
			get { return _instance; }
		}

		public override string EnglishName
		{
			get { return "TestTransformEvents"; }
		}

		private bool attached = false;

		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			if (!attached)
			{
				attached = true;
				RhinoDoc.BeforeTransformObjects += RhinoDoc_BeforeTransformObjects;
			}
			else
			{
				attached = false;
				RhinoDoc.BeforeTransformObjects -= RhinoDoc_BeforeTransformObjects;
			}
			return Result.Success;
		}

		private void RhinoDoc_BeforeTransformObjects(object sender, Rhino.DocObjects.RhinoTransformObjectsEventArgs e)
		{
			RhinoApp.WriteLine($"Transforming {e.ObjectCount} object{(e.ObjectCount != 1 ? "s" : "")} with {e.Transform}");
		}
	}
}