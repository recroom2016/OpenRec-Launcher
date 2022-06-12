using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRec2.Launcherapi
{
    internal class Images
    {

        //to be able to read image files as images in gui
        public static Image bytearraytoimage(byte[] source)
        {
            try
            {
                MemoryStream ms = new MemoryStream(source);
                Image ret = Image.FromStream(ms);
                return ret;
            }
            catch
            {
                return null;
            }
        }
    }
}
