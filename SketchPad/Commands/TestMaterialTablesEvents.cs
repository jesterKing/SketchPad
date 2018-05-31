using System;
using Rhino;
using Rhino.Commands;

namespace SketchPad.Commands
{
	public class TestMaterialTablesEvents : Command
	{
		static TestMaterialTablesEvents _instance;
		public TestMaterialTablesEvents()
		{
			_instance = this;
		}

		///<summary>The only instance of the TestMaterialTablesEvents command.</summary>
		public static TestMaterialTablesEvents Instance
		{
			get { return _instance; }
		}

		public override string EnglishName
		{
			get { return "TestMaterialTablesEvents"; }
		}

		private bool attached = false;
		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			if (!attached)
			{
				attached = true;
				RhinoDoc.RenderMaterialsTableEvent += RhinoDoc_RenderMaterialsTableEvent;
				RhinoDoc.MaterialTableEvent += RhinoDoc_MaterialTableEvent;
			} else
			{
				attached = false;
				RhinoDoc.RenderMaterialsTableEvent -= RhinoDoc_RenderMaterialsTableEvent;
				RhinoDoc.MaterialTableEvent -= RhinoDoc_MaterialTableEvent;
			}
			return Result.Success;
		}
		private void RhinoDoc_MaterialTableEvent(object sender, Rhino.DocObjects.Tables.MaterialTableEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine($"{sender} - {e.EventType}");
		}

		private void RhinoDoc_RenderMaterialsTableEvent(object sender, RhinoDoc.RenderContentTableEventArgs e)
		{
			var rme = e as RhinoDoc.RenderMaterialAssignmentChangedEventArgs;
			System.Diagnostics.Debug.WriteLine($"{sender} - {e.EventType} | {rme?.NewRenderMaterial.ToString() ?? "no_render_mat"}");
		}

	}
}