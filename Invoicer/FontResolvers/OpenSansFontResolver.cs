using PdfSharp.Fonts;
using System;
using System.IO;

namespace Invoicer.FontResolvers
{
    public class OpenSansFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(faceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool bold, bool italic)
        {
            if (familyName.Equals("OpenSans", StringComparison.CurrentCultureIgnoreCase))
            {
                if (bold && italic)
                {
                    return new FontResolverInfo("Fonts/Open_Sans/OpenSans-BoldItalic.ttf");
                }
                else if (bold)
                {
                    return new FontResolverInfo("Fonts/Open_Sans/OpenSans-Bold.ttf");
                }
                else if (italic)
                {
                    return new FontResolverInfo("Fonts/Open_Sans/OpenSans-Italic.ttf");
                }
                else
                {
                    return new FontResolverInfo("Fonts/Open_Sans/OpenSans-Regular.ttf");
                }
            }
            return null;
        }
    }
}
