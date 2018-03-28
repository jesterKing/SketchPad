using System;
using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.Render;

namespace SketchPad
{
	public class DocumentCollectedExceptionCRMProvider : CustomRenderMeshProvider2
	{
		public override string Name => "DocumentCollectedException CRM Provider";

		public override bool BuildCustomMeshes(ViewportInfo vp, RhinoDoc doc, RenderPrimitiveList objMeshes, Guid requestingPlugIn, DisplayPipelineAttributes attrs)
		{
			return false;
		}

		public override bool WillBuildCustomMeshes(ViewportInfo vp, RhinoObject obj, RhinoDoc doc, Guid requestingPlugIn, DisplayPipelineAttributes attrs)
		{
			bool rc = false;
			try
			{
				var validity = obj.Geometry.IsValid ? "valid" : "invalid";
				RhinoApp.WriteLine(validity);
				rc = true;
			} catch(Rhino.Runtime.DocumentCollectedException)
			{
				rc = false;
			}

			return rc;
		}
	}
}
