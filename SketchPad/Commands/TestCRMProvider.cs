using System;
using Rhino;
using Rhino.Commands;

namespace SketchPad.Commands
{
	public class TestCRMProvider : Command
	{
		static TestCRMProvider _instance;
		public TestCRMProvider()
		{
			_instance = this;
		}

		///<summary>The only instance of the TestCRMProvider command.</summary>
		public static TestCRMProvider Instance
		{
			get { return _instance; }
		}

		public override string EnglishName
		{
			get { return "TestCRMProvider"; }
		}

		private bool inited = false;
		private static DocumentCollectedExceptionCRMProvider provider = null;
		protected override Result RunCommand(RhinoDoc doc, RunMode mode)
		{
			if (!inited)
			{
				Rhino.Render.CustomRenderMeshProvider2.RegisterProviders(PlugIn.Assembly, Id);
				inited = true;
				provider = new DocumentCollectedExceptionCRMProvider();
			}
			return Result.Success;
		}
	}
}