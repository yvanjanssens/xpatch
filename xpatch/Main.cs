using System;

namespace xpatch
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Patcher p = null;
			
			Console.WriteLine ("xpatch by yvanjanssens");
			
			if (args.Length == 2) {
				p = new Patcher(PatchFileType.IDA_DIFF, args[0], args[1]);
			} else if(args.Length == 3) {
				switch (args[0]) {
				case "ida":
					p = new Patcher(PatchFileType.IDA_DIFF, args[1], args[2]);
					break;
				case "xml":
					p = new Patcher(PatchFileType.XMLPATCH, args[1], args[2]);
					break;
				case "cxml":
					p = new Patcher(PatchFileType.COMPRESSED_XMLPATCH, args[1], args[2]);
					break;
					
				default:
					Usage();
					return;
				}
			} else {
				Usage();
				return;
			}
			
			if (p.DryRun()) {
				p.Patch();	
			} else {
				Console.WriteLine("dry-run failed. Aborting patch...");	
			}
		}
		
		private static void Usage() {
			Console.WriteLine("usage: xpatch [type] infile outfile");
			Console.WriteLine("where type is one of:");
			Console.WriteLine("  * ida: ida DIF  (default)");
			Console.WriteLine("	 * xml: xmlpatch ");
			Console.WriteLine("	 * cxml: compressed xmlpatch");
		}
	}
}

