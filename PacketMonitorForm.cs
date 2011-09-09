/*
 *   Mentalis.org Packet Monitor
 * 
 *     Copyright © 2003, The KPD-Team
 *     All rights reserved.
 *     http://www.mentalis.org/
 *
 *   Redistribution and use in source and binary forms, with or without
 *   modification, are permitted provided that the following conditions
 *   are met:
 *
 *     - Redistributions of source code must retain the above copyright
 *        notice, this list of conditions and the following disclaimer. 
 *
 *     - Neither the name of the KPD-Team, nor the names of its contributors
 *        may be used to endorse or promote products derived from this
 *        software without specific prior written permission. 
 *
 *   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 *   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 *   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
 *   THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 *   INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *   (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 *   SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 *   HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 *   STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 *   ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 *   OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using PacketMonitor.Filter;

namespace PacketMonitor {
	public class PacketMonitorForm : System.Windows.Forms.Form {
        private delegate void UpdatePacketList(Packet p);
        /*****Cnfiguracion de Formulario Configuraciones***/
        Filter.Configuraciones f = new Filter.Configuraciones();
        private Filter.Configuraciones form = null;
        private Filter.Configuraciones FormInstance
        {
            get
            {
                if (form == null)
                {
                    form = new Filter.Configuraciones();
                    form.Disposed += new EventHandler(form_Disposed);
                }

                return form;
            }
        }
        void form_Disposed(object sender, EventArgs e)
        {
            form = null;
        }
        /**************************************************/
        
        public PacketMonitorForm() {
			// Required for Windows Form Designer support
			InitializeComponent();
			// initialize packet monitor
			Initialize();
		}
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketMonitorForm));
            this.ToolBar = new System.Windows.Forms.ToolBar();
            this.StartButton = new System.Windows.Forms.ToolBarButton();
            this.HostsMenu = new System.Windows.Forms.ContextMenu();
            this.StopButton = new System.Windows.Forms.ToolBarButton();
            this.ClearButton = new System.Windows.Forms.ToolBarButton();
            this.AboutButton = new System.Windows.Forms.ToolBarButton();
            this.ToobarImages = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.MonitorMenuItem = new System.Windows.Forms.MenuItem();
            this.StopMenuItem = new System.Windows.Forms.MenuItem();
            this.ClearMenuItem = new System.Windows.Forms.MenuItem();
            this.Splitter1MenuItem = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.HelpMenu = new System.Windows.Forms.MenuItem();
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.StatusBar = new System.Windows.Forms.StatusBar();
            this.PacketList = new System.Windows.Forms.ListView();
            this.TimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProtocolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestinationHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LengthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.ToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.StartButton,
            this.StopButton,
            this.ClearButton,
            this.AboutButton});
            this.ToolBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToolBar.DropDownArrows = true;
            this.ToolBar.ImageList = this.ToobarImages;
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.ShowToolTips = true;
            this.ToolBar.Size = new System.Drawing.Size(522, 28);
            this.ToolBar.TabIndex = 1;
            this.ToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.OnToolBarClick);
            // 
            // StartButton
            // 
            this.StartButton.DropDownMenu = this.HostsMenu;
            this.StartButton.ImageIndex = 0;
            this.StartButton.Name = "StartButton";
            this.StartButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.StartButton.ToolTipText = "Start monitoring";
            // 
            // StopButton
            // 
            this.StopButton.ImageIndex = 1;
            this.StopButton.Name = "StopButton";
            this.StopButton.ToolTipText = "Stop monitoring";
            // 
            // ClearButton
            // 
            this.ClearButton.ImageIndex = 3;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.ToolTipText = "Clear packet list";
            // 
            // AboutButton
            // 
            this.AboutButton.ImageIndex = 2;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.ToolTipText = "About...";
            // 
            // ToobarImages
            // 
            this.ToobarImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToobarImages.ImageStream")));
            this.ToobarImages.TransparentColor = System.Drawing.Color.Magenta;
            this.ToobarImages.Images.SetKeyName(0, "");
            this.ToobarImages.Images.SetKeyName(1, "");
            this.ToobarImages.Images.SetKeyName(2, "");
            this.ToobarImages.Images.SetKeyName(3, "");
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.menuItem1,
            this.HelpMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MonitorMenuItem,
            this.StopMenuItem,
            this.ClearMenuItem,
            this.Splitter1MenuItem,
            this.ExitMenuItem});
            this.FileMenu.Text = "Inicio";
            // 
            // MonitorMenuItem
            // 
            this.MonitorMenuItem.Index = 0;
            this.MonitorMenuItem.Text = "Interfaces";
            // 
            // StopMenuItem
            // 
            this.StopMenuItem.Index = 1;
            this.StopMenuItem.Text = "Parar";
            this.StopMenuItem.Click += new System.EventHandler(this.StopMenuItem_Click);
            // 
            // ClearMenuItem
            // 
            this.ClearMenuItem.Index = 2;
            this.ClearMenuItem.Text = "Limpiar Lista";
            this.ClearMenuItem.Click += new System.EventHandler(this.ClearMenuItem_Click);
            // 
            // Splitter1MenuItem
            // 
            this.Splitter1MenuItem.Index = 3;
            this.Splitter1MenuItem.Text = "-";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 4;
            this.ExitMenuItem.Text = "Salir";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text = "Filtro";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Por IP";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Por Puerto";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "Configuraciones";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Index = 2;
            this.HelpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AboutMenuItem});
            this.HelpMenu.Text = "Ayuda";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Index = 0;
            this.AboutMenuItem.Text = "Acerca de..";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 321);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(522, 16);
            this.StatusBar.TabIndex = 3;
            // 
            // PacketList
            // 
            this.PacketList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeHeader,
            this.ProtocolHeader,
            this.SourceHeader,
            this.DestinationHeader,
            this.LengthHeader});
            this.PacketList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PacketList.FullRowSelect = true;
            this.PacketList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PacketList.Location = new System.Drawing.Point(0, 28);
            this.PacketList.MultiSelect = false;
            this.PacketList.Name = "PacketList";
            this.PacketList.Size = new System.Drawing.Size(522, 293);
            this.PacketList.TabIndex = 4;
            this.PacketList.UseCompatibleStateImageBehavior = false;
            this.PacketList.View = System.Windows.Forms.View.Details;
            this.PacketList.DoubleClick += new System.EventHandler(this.OnPacketDoubleClick);
            // 
            // TimeHeader
            // 
            this.TimeHeader.Text = "Hora";
            this.TimeHeader.Width = 120;
            // 
            // ProtocolHeader
            // 
            this.ProtocolHeader.Text = "Protocolo";
            // 
            // SourceHeader
            // 
            this.SourceHeader.Text = "Origen";
            this.SourceHeader.Width = 130;
            // 
            // DestinationHeader
            // 
            this.DestinationHeader.Text = "Destino";
            this.DestinationHeader.Width = 130;
            // 
            // LengthHeader
            // 
            this.LengthHeader.Text = "Tamaño";
            // 
            // PacketMonitorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 337);
            this.Controls.Add(this.PacketList);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu;
            this.Name = "PacketMonitorForm";
            this.Text = "Miracle Cache V1";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PacketMonitormForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		static void Main() {
			try {
                FileHandler.ReadFromFileToArrayList(@"pIP.list", Filters.PacketIDFilterList);
                FileHandler.ReadFromFileToArrayList(@"port.list", Filters.PortFilterList);
				Application.Run(new PacketMonitorForm());
			} catch (Exception e) {
				MessageBox.Show(e.Message, "Miracle Cache V. 1.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Initialize() {
			// get all interfaces on this computer and list them
			IPAddress[] hosts = Dns.Resolve(Dns.GetHostName()).AddressList;
			if (hosts.Length == 0)
				throw new NotSupportedException("Esta PC no tiene Interfaces de RED instaladas..!");
			for(int i = 0; i < hosts.Length; i++) {
				MonitorMenuItem.MenuItems.Add(hosts[i].ToString(), new EventHandler(this.OnHostsClick));
				HostsMenu.MenuItems.Add(hosts[i].ToString(), new EventHandler(this.OnHostsClick));
			}
			m_PacketMonitors = new PacketMonitor[HostsMenu.MenuItems.Count];
			for(int i = 0; i < m_PacketMonitors.Length; i++) {
				m_PacketMonitors[i] = new PacketMonitor(hosts[i]);
				m_PacketMonitors[i].NewPacket += new NewPacketEventHandler(this.OnNewPacket);
			}
			m_Packets = new ArrayList();
		}
		private void PacketMonitormForm_Closing(object sender, CancelEventArgs e) {
			OnToolBarClick(this, new ToolBarButtonClickEventArgs(StopButton));
		}
		public void OnToolBarClick(object sender, ToolBarButtonClickEventArgs e) {
			if (e.Button == StopButton) { // stop listening on all interfaces
				for(int i = 0; i < m_PacketMonitors.Length; i++) {
					m_PacketMonitors[i].Stop();
					HostsMenu.MenuItems[i].Checked = false;
					MonitorMenuItem.MenuItems[i].Checked = false;
				}
				StatusBar.Text = "Parando Monitoreo";
			} else if (e.Button == StartButton) { // start listening on all interfaces
				for(int i = 0; i < m_PacketMonitors.Length; i++) {
					try {
						m_PacketMonitors[i].Start();
					} catch (Exception ex) {
						MessageBox.Show(this, "Ha ocurrido un problema al moniterear la Interface: " + m_PacketMonitors[i].IP.ToString() + "\r\n\r\n[" + ex.Message + "]", "Miracle Cache V 1.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					HostsMenu.MenuItems[i].Checked = true;
					MonitorMenuItem.MenuItems[i].Checked = true;
				}
				StatusBar.Text = "Monitoreando todas las interfaces";
		} else if (e.Button == ClearButton) { // clear the packet list
				PacketList.Items.Clear();
				m_Packets.Clear();
				StatusBar.Text = "Limpiando Lista de Paquetes";
			} else if (e.Button == AboutButton) {
				AboutForm af = new AboutForm();
				af.ShowDialog(this);
			}
		}
		public void OnHostsClick(object sender, EventArgs e) {
			// start or stop listening on the specified interface
			int index = ((MenuItem)sender).Index;
			HostsMenu.MenuItems[index].Checked = !HostsMenu.MenuItems[index].Checked;
			MonitorMenuItem.MenuItems[index].Checked = HostsMenu.MenuItems[index].Checked;
			if (HostsMenu.MenuItems[index].Checked) {
				m_PacketMonitors[index].Start();
				StatusBar.Text = "Monitoreando " + m_PacketMonitors[index].IP.ToString();
			} else {
				m_PacketMonitors[index].Stop();
				StatusBar.Text = "Parando Monitoreo " + m_PacketMonitors[index].IP.ToString();
			}
		}
		public void OnPacketDoubleClick(object sender, EventArgs e) {
			ListView l = (ListView)sender;
			if (l.SelectedItems.Count > 0) {
				PacketForm pf = new PacketForm((Packet)m_Packets[l.SelectedItems[0].Index]);
				pf.Show();
			}
		}
		private void OnNewPacket(PacketMonitor pm, Packet p) {
            if (f.sinFiltro() == true)
            {
                m_Packets.Add(p);			
                m_PacketsSize += p.TotalLength;
                this.Invoke(new UpdatePacketList(OnUpdatePacketList), p); 
            }
            else if(f.filtroPorP() == true)
            {
                if((p.Protocol.ToString() == "Tcp") && (Filters.CheckFilter(Filters.PortFilterList, p.SourcePort.ToString()) 
                || Filters.CheckFilter(Filters.PortFilterList, p.DestinationPort.ToString())))            
                {                
                    m_Packets.Add(p);                
                    m_PacketsSize += p.TotalLength;               
                    this.Invoke(new UpdatePacketList(OnUpdatePacketList), p);            
                }
            }
            else if (f.filtroPorPIP() == true)
            {
                if (((p.Protocol.ToString() == "Tcp") && (Filters.CheckFilter(Filters.PortFilterList, p.SourcePort.ToString())
                    || Filters.CheckFilter(Filters.PortFilterList, p.DestinationPort.ToString())) &&
                    (Filters.CheckFilter(Filters.PacketIDFilterList, p.SourceAddress.ToString()) || Filters.CheckFilter(Filters.PacketIDFilterList, p.DestinationAddress.ToString()))))
                {
                    // add the new packet to the list			
                    m_Packets.Add(p);
                    m_PacketsSize += p.TotalLength;
                    this.Invoke(new UpdatePacketList(OnUpdatePacketList), p);
                    //PacketList.Items.Add(new ListViewItem(new string[] { p.Time.ToString(), p.Protocol.ToString(), p.Source, p.Destination, p.TotalLength.ToString() }));			
                    //StatusBar.Text = string.Format("Intercepted {0} packet(s) [{1} bytes]", m_Packets.Count, m_PacketsSize);            
                    //UpdatePacketList
                }
            }
 
		}

        private void OnUpdatePacketList(Packet p) {
            PacketList.Items.Add(new ListViewItem(new string[] { p.Time.ToString(), p.Protocol.ToString(), p.Source, p.Destination, p.TotalLength.ToString() }));
            StatusBar.Text = string.Format("Interceptados {0} packet(s) [{1} bytes]", m_Packets.Count, m_PacketsSize);
        }

		private void StopMenuItem_Click(object sender, System.EventArgs e) {
			OnToolBarClick(this, new ToolBarButtonClickEventArgs(StopButton));
		}
		private void ClearMenuItem_Click(object sender, System.EventArgs e) {
			OnToolBarClick(this, new ToolBarButtonClickEventArgs(ClearButton));
		}
		private void AboutMenuItem_Click(object sender, System.EventArgs e) {
			OnToolBarClick(this, new ToolBarButtonClickEventArgs(AboutButton));
		}
		private void ExitMenuItem_Click(object sender, System.EventArgs e) {
			this.Close();
		}
		private System.Windows.Forms.ListView PacketList;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.ImageList ToobarImages;
		private System.Windows.Forms.ToolBar ToolBar;
		private System.Windows.Forms.StatusBar StatusBar;
		private System.Windows.Forms.ToolBarButton StartButton;
		private System.Windows.Forms.ToolBarButton StopButton;
		private System.Windows.Forms.ToolBarButton AboutButton;
		private System.Windows.Forms.ToolBarButton ClearButton;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem ExitMenuItem;
		private System.Windows.Forms.MenuItem HelpMenu;
		private System.Windows.Forms.MenuItem AboutMenuItem;
		private System.Windows.Forms.ColumnHeader TimeHeader;
		private System.Windows.Forms.ColumnHeader ProtocolHeader;
		private System.Windows.Forms.ColumnHeader SourceHeader;
		private System.Windows.Forms.ColumnHeader DestinationHeader;
		private System.Windows.Forms.ColumnHeader LengthHeader;
		private System.Windows.Forms.MenuItem MonitorMenuItem;
		private System.Windows.Forms.MenuItem StopMenuItem;
		private System.Windows.Forms.MenuItem ClearMenuItem;
		private System.Windows.Forms.MenuItem Splitter1MenuItem;
		private System.Windows.Forms.ContextMenu HostsMenu;
		private System.ComponentModel.IContainer components;
		private PacketMonitor[] m_PacketMonitors;
		private ArrayList m_Packets;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
		private int m_PacketsSize = 0;

        private void menuItem2_Click(object sender, EventArgs e)
        {
            new Filter.Filter(Filters.PacketIDFilterList).Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            new Filter.Filter(Filters.PortFilterList).Show();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Filter.Configuraciones frm = this.FormInstance;

            frm.Show();
            frm.BringToFront();
        }        
	}
}