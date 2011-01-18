using System;
namespace xpatch
{
	public class Patcher
	{
		private string infile {get; set; }
		private string outfile {get; set; }
		private PatchFileType filetype {get;set;}
		private PatchContents patchContents {get; set; }
		
		public Patcher (PatchFileType patchFileType, string infile, string outfile)
		{
			this.infile = infile;
			this.outfile = outfile;
			this.filetype = patchFileType;
		}
		
		public bool DryRun() {
			
			return false;
		}
		
		public void Patch() {
			
		}
	}
}

