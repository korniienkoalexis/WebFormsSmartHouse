using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHomeEquipment;
using WebFormsSmartHouse.Controls;
using WebFormsSmartHouse.Factorys;

namespace WebFormsSmartHouse
{
     
    public partial class Default : System.Web.UI.Page
    {
        IDictionary<int, Device> devDictionary; //= new Dictionary<int, Device>();
        DeviceFactory Devises = new DeviceFactory();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                devDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            }
            else
            {
                devDictionary = new SortedDictionary<int, Device>();
                devDictionary.Add(1, Devises.GetRadioInstance());
                devDictionary.Add(2, Devises.GetTVInstance());
                devDictionary.Add(3, Devises.GetMusicCenterInstance());
                devDictionary.Add(4, Devises.GetCondicionerInstance());
                devDictionary.Add(5, Devises.GetRefrigiratorInstance());

                Session["Devices"] = devDictionary;
                Session["NextId"] = 6;
            }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            InitialiseFiguresPanel();
           
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //((IVolume)devDictionary[0]).UpVolume();
            
            devDictionary[0].Off();

            //foreach (var devs in devDictionary)
            //{
             //   Label1.Text = devs.Key + ", " + devs.Value.ToString();
           // }
            

        }

        Device newDevice;
        protected void AddDeviceButtonClick(object sender, EventArgs e)
        {
            
            //int id = (int)Session["NextId"];
            DeviceFactory Devises = new DeviceFactory();
            string deviceName = TextBox1.Text.ToString();
            switch (dropDownFiguresList.SelectedIndex)
            {
                default:
                    newDevice = Devises.GetRadioInstance(deviceName);
                    
                    break;
                case 1:
                    newDevice = Devises.GetTVInstance(deviceName);
                    
                    break;
                case 2:
                    newDevice = Devises.GetRefrigiratorInstance(deviceName);
                    break;
                case 3:
                    newDevice = Devises.GetCondicionerInstance(deviceName);
                    break;
                case 4:
                    newDevice = Devises.GetMusicCenterInstance(deviceName);
                    break;
            }

            int id = (int)Session["NextId"];
            devDictionary.Add(id, newDevice);
            
            figuresPanel.Controls.Add(new DeviceControl(id, devDictionary));
            id++;
            Session["NextId"] = id;
        }

        protected void InitialiseFiguresPanel()
        {
            foreach (int key in devDictionary.Keys)
            {
                figuresPanel.Controls.Add(new DeviceControl(key, devDictionary));
                
            }
        }

       
    }
}