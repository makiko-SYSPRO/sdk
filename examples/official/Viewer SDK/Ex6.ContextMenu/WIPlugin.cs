using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using vrcontext.walkinside.sdk;

namespace WIExample
{
    /// <summary>
    /// A Walkinside plugin example concerning how to create a Walkinside context menu item.
    /// </summary>
    /// <remarks>
    /// Creates a context menu item and registers an event handler for the menu item click event.
    /// This context menu item pops up on mouse right click in 3D window.
    /// To activate the context menu, you need to click the "Example 6" menu item
    /// under Walkinside plugin menu.
    /// The plugin also shows how to use the raycast result. 
    /// </remarks>
    public class WIPlugin : IVRPlugin
    {
		internal static VRPluginDescriptor pDescriptor = new VRPluginDescriptor(
            VRPluginType.Unknown, 1, "", "19/01/2009", "Example 6: Context Menu.", "Walkinside Plugin Step 6.", "Vrcontext_SDK");
        /// <summary>
        /// Get the plugin descriptor without creating the plugin.
        /// </summary>
        static public VRPluginDescriptor GetDescriptor
        {
            get
            {
                return pDescriptor;
            }
        }

        /// <summary>
        /// Get the plugin descriptor.
        /// </summary>
        public VRPluginDescriptor Description
        {
            get
            {
                return pDescriptor;
            }
        }

        ToolStripMenuItem m_ToolStripItem = null;

        /// <summary>
        /// Called when attaching the plugin to the user interface.
        /// </summary>
        /// <param name="viewer">
        /// The walkinside viewer instance.
        /// </param>
        /// <returns>
        /// True if construction request succeeded.
        /// </returns>
        public bool CreatePlugin(IVRViewerSdk viewer)
        {
            // Create my menu item called "Example 6".
            m_ToolStripItem = viewer.UI.PluginMenu.DropDownItems.Add("Example 6") as ToolStripMenuItem;
            //  Register a form with the menu item created. So Walkinside will take care of the user click event handling.
            viewer.UI.RegisterVRFormWithMenu(Keys.NoName, m_ToolStripItem, typeof(MainForm));

            return true;
        }


        /// <summary>
        /// Called when detaching the plugin from the user interface.
        /// </summary>
        /// <param name="viewer">
        /// The walkinside viewer instance.
        /// </param>
        /// <returns>
        /// True if destruction request succeeded.
        /// </returns>
        public bool DestroyPlugin(IVRViewerSdk viewer)
        {
            // Remove the form registration from the menu item. This is necessary if the user disables the plugin, while it has been activated.
            viewer.UI.UnregisterVRFORM(m_ToolStripItem, typeof(MainForm));
            // Remove my menu item called "Example 6" from the plugin menu.
            viewer.UI.PluginMenu.DropDownItems.Remove(m_ToolStripItem);
            m_ToolStripItem = null;

            return true;
        }
    }
}
