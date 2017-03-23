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

            try
            {
                List<FavoritesItem> items   = null;
                using (XmlReader reader = XmlReader.Create("favorites.xml", setting))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "Group")
                            {
                                items = favorites.GetGroup(reader.GetAttribute("name"));
                                continue;
                            }

                            if (reader.Name == "Item")
                            {
                                if(items == null)
                                {
                                    continue;
                                }

                                FavoritesItem item  = new FavoritesItem();
                                
                                item.Name   = reader.GetAttribute("name");
                                item.Address = reader.GetAttribute("address");
                                item.Port = reader.GetAttribute("port");
                                item.ID = reader.GetAttribute("id");
                                item.Password   = reader.GetAttribute("password");
                                
                                items.Add(item);
                            }
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Not found favorites.xml");
            }
            return true;
        }

        // Refresh favorites items
        static public void RefreshFavoritesItems(this TreeView treeView, Favorites favorites)
        {
            treeView.Nodes.Clear();
            foreach (var group in favorites._group)
            {
                string groupName = group.Key;

                TreeNode groupNode  = new TreeNode();
                groupNode.Text = groupName;
                treeView.Nodes.Add(groupNode);

                foreach (var item in group.Value)
                {
                    TreeNode itemNode = new TreeNode();
                    itemNode.Text = item.Name;
                    itemNode.ToolTipText = item.Address;
                    groupNode.Nodes.Add(itemNode);
                }
            }

            treeView.ExpandAll();
        }

        // Get selected favorites item
        static public FavoritesItem GetSelectedFavoritesItem(this TreeView treeView, Favorites favorites)
        {
            TreeNode selectedNode   = treeView.SelectedNode;
            if (selectedNode == null)
                return null;

            TreeNode parentNode = selectedNode.Parent;
            if (parentNode == null)
                return null;

            return favorites.FindItem(parentNode.Text, selectedNode.Text);
        }

        // Get selected favorites item group name
        static public string GetSelectedFavoritesItemGroupName(this TreeView treeView, Favorites favorites)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode == null)
                return "";

            TreeNode parentNode = selectedNode.Parent;
            if (parentNode == null)
                return "";

            return parentNode.Text;
        }

        // Delete selected favorites item 
        static public bool DeleteSelectedFavoritesItem(this TreeView treeView, Favorites favorites)
        {
            // get selected favorites item
            var item    = treeView.GetSelectedFavoritesItem(favorites);
            if (item == null)
                return false;
            string group = treeView.GetSelectedFavoritesItemGroupName(favorites);
            
            // delete favorites item with item namd and group name
            return favorites.DelItem(group, item);
        }
    }

  
    // favorites item list
    public class Favorites
    {
        public Dictionary<string, List<FavoritesItem>> _group = new Dictionary<string, List<FavoritesItem>>();
        public FavoritesItem FindItem(string groupName, string itemName)
        {
            foreach(var item in _group[groupName])
            {
                if (item.Name == itemName)
                    return item;
            }

            return null;
        }

        // get group if exists group otherwise create group and return it.
        public List<FavoritesItem> GetGroup(string groupName)
        {
            List<FavoritesItem> items;
            try
            {
                items = _group[groupName];
            }
            catch
            {
                items = new List<FavoritesItem>();
                _group[groupName] = items;
            }

            return items;
        }

        // Add new item
        public bool AddItem(string groupName, FavoritesItem item)
        {
            List<FavoritesItem> items = GetGroup(groupName);
            if (items == null)
                return false;

            items.Add(item);

            return true;
        }

        // Delete a item
        public bool DelItem(string groupName, FavoritesItem item)
        {
            List<FavoritesItem> items = GetGroup(groupName);
            if (items == null)
                return false;
            return items.Remove(item);
        }
    }
}
