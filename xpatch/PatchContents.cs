using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace xpatch
{
	public class PatchContents
	{
		private List<PatchOffset> _Offsets;
		
		public List<PatchOffset> OffsetList {
			get {
				return _Offsets;	
			}
		}
		
		public PatchContents(List<PatchOffset> Offsets) {
			this._Offsets = Offsets;	
		}
		
		public static PatchContents createFromIDA(string idafile) {
			string[] lines = File.ReadAllLines(idafile);
			List<PatchOffset> offsets = new List<PatchOffset>();
			foreach(string line in lines) {
				// lines which contain a ':' are patch lines.
				if (line.Contains(":")) {
					string offset, orig, alt;
					long offsetInLong;
					byte origInByte;
					byte altInByte;
					string line_alt;
					// Get the first part of the line, trim all spaces.
					offset = line.Split(':')[0].ToString().Trim();
					// Convert to valid hex number:
					offset = "0x" + offset;
					offsetInLong = long.Parse(offset, NumberStyles.HexNumber);
					
					// Remove the offset part.
					line_alt = line.Replace(":", "").Replace(offset.Replace("0x", ""), "");
					
					// Get original/modified byte
					orig = line_alt.Split(' ')[0].ToString();
					alt = line_alt.Split(' ')[1].ToString();
					
					// Convert to valid hex number:
					orig = "0x" + orig;
					alt = "0x" + alt;
					
					// Parse to correct data types
					origInByte = (byte) short.Parse(orig, NumberStyles.HexNumber);
					altInByte = (byte) short.Parse(orig, NumberStyles.HexNumber);
					
					offsets.Add(new PatchOffset(offsetInLong, origInByte, altInByte));
				}
			}
			return new PatchContents(offsets);
		}
	}
}

