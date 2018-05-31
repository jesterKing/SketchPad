using Rhino;
using Rhino.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SketchPad
{
	[Guid("de7e148e-3de2-436e-b240-81bdcf55875e")]
	public class SPRenderMaterial : RenderMaterial
	{
		public override string TypeName => "SPRenderMaterial";

		public override string TypeDescription => "SPRenderMaterial Tests";
		public SPRenderMaterial()
		{
			//System.Diagnostics.Debug.WriteLine("constructing an SPRenderMaterial\n");
		}

		protected override void Dispose(bool disposing)
		{
			//System.Diagnostics.Debug.WriteLine($"Disposing SPRenderMaterial: {Id} {RenderHash}\n");
			base.Dispose(disposing);
		}
	}
}
