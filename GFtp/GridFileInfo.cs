using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFtp
{
    public class GridFileInfo : IComparable
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public bool IsFolder { get; set; }
       

        public int CompareTo(object obj)
        {
            if(obj is GridFileInfo)
            {
                GridFileInfo tmp = (GridFileInfo)obj;
                if (tmp.IsFolder == IsFolder)
                    return 0;
                else if (tmp.IsFolder == true)
                    return 1;
                else if (IsFolder == true)
                    return -1;
            }
            throw new ArgumentException("Object is not a GridFileInfo");
        }
    }
}
