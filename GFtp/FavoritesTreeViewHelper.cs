using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GFtp
{
    static public class FavoritesTreeViewHelper
    {
        // Load favorites items from favorites.xml file.
        static public bool LoadFavoritesItems(this TreeView treeView, Favorites favorites)
        {
            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreWhitespace = true;
            setting.ConformanceLevel = ConformanceLevel.Fragment;

            using (XmlReader reader = XmlReader.Create("favorites.xml", setting))
            {
                string group = "";
                while(reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element)
                    {
                        if(reader.Name == "Group")
                        {
                            group = reader.GetAttribute("name");
                            continue;
                        }

                        if(reader.Name == "Item")
                        {
                            
                        }
                    }
                   
                }
            }
            return true;
        }

        // Refresh favorites items
        static public void RefreshFavoritesItems(this TreeView treeView, Favorites favorites)
        {
            
        }
    }

  
    // favorites item list
    public class Favorites
    {
        public Dictionary<string, List<FavoritesItem>> _group;
    }
}
