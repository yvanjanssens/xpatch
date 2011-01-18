using System;
namespace xpatch
{
	public class PatchOffset
	{
		public long offset {get; set; }
		public byte original {get; set; }
		public byte modified {get; set; }
		
		public PatchOffset (long offset, byte original, byte modified)
		{
			this.offset = offset;
			this.original = original;
			this.modified = modified;
		}
	}
}

