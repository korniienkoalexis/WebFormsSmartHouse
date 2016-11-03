using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SmartHomeEquipment;

namespace WebFormsSmartHouse.Controls
{
       
    public class DeviceControl : Panel
    {
        private int id;
        bool doorStateFlag;
        private IDictionary<int, Device> devDictionary;

        private Label info;
        private Label warning;
        private Button stateButton;
        private Button volumeUpButton;
        private Button changeModeButton;
        private Button changeCDButton;
        private Button volumeDownButton;
        private Button radioChanelUPButton;
        private Button aircondModeButton;
        private Button radioChanelDownButton;
        private Button airconditionerTemperatoreUPButton;
        private Button airconditionerTemperatoreDownButton;
        //private Button DoorCloseButton;
        //private Button DoorOpenButton;
        private Button DoorOCButton;
        private Button FrostDoorOpenButton;
        private Button deleteButton;
        private int key;

        public DeviceControl(int id, IDictionary<int, Device> devDictionary)
        {
            this.id = id;
            this.devDictionary = devDictionary;
            Initializer();
        }

        protected void Initializer()
        {
            CssClass = "device-div";
            //Controls.Add(Span("Device: " + devDictionary[id].ToString() + "<br />"));
            info = new Label();
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            Controls.Add(info);
            Controls.Add(Span("State " + "<br />"));
            stateButton = new Button();
            stateButton.ID = stateButton + id.ToString();
            if (devDictionary[id].state)
            {
                stateButton.Text = "OFF";
                stateButton.Click += OffButtonClick;
            }
            else
            {
                stateButton.Text = "ON";
                stateButton.Click += OnButtonClick;
            }
            Controls.Add(stateButton);
            Controls.Add(Span("<br />"));

            


            if (devDictionary[id] is IVolume)
            {
                Controls.Add(Span("Volume: " + "<br />"));
                volumeDownButton = new Button();
                volumeDownButton.ID = "d" + id.ToString();
                volumeDownButton.Text = "Volume-";
                volumeDownButton.Click += VolumeDownButtonClick;
                Controls.Add(volumeDownButton);

                Controls.Add(Span("&nbsp"));

                volumeUpButton = new Button();
                volumeUpButton.ID = "u" + id.ToString();
                volumeUpButton.Text = "Volume+";
                volumeUpButton.Click += VolumeUpButtonClick;
                Controls.Add(volumeUpButton);

                Controls.Add(Span("<br />"));
                
            }

            if (devDictionary[id] is IRadioChannel)
            {
                Controls.Add(Span("Channel: " + "<br />"));

                radioChanelDownButton = new Button();
                radioChanelDownButton.ID = "cd" + id.ToString();
                radioChanelDownButton.Text = "Channel -";
                radioChanelDownButton.Click += RadioChanelDownButtonClick;
                Controls.Add(radioChanelDownButton);

                Controls.Add(Span("&nbsp"));

                radioChanelUPButton = new Button();
                radioChanelUPButton.ID = "cu" + id.ToString();
                radioChanelUPButton.Text = "Channel +";
                radioChanelUPButton.Click += RadioChanelUPButtonClick;
                Controls.Add(radioChanelUPButton);

                Controls.Add(Span("<br />"));
            }

            if (devDictionary[id] is ITVChangeChannel)
            {
                Controls.Add(Span("Channel: " + "<br />"));

                radioChanelDownButton = new Button();
                radioChanelDownButton.ID = "tcd" + id.ToString();
                radioChanelDownButton.Text = "Channel -";
                radioChanelDownButton.Click += TVChanelDownButtonClick;
                Controls.Add(radioChanelDownButton);

                Controls.Add(Span("&nbsp"));

                radioChanelUPButton = new Button();
                radioChanelUPButton.ID = "tcu" + id.ToString();
                radioChanelUPButton.Text = "Channel +";
                radioChanelUPButton.Click += TVChanelUPButtonClick;
                Controls.Add(radioChanelUPButton);

                Controls.Add(Span("<br />"));
            }

            if (devDictionary[id] is IMusicCenterMode)
            {
                Controls.Add(Span("Change mode: " + "<br />"));
                changeModeButton = new Button();
                changeModeButton.ID = "mcm" + id.ToString();
                changeModeButton.Text = "Change mode";
                changeModeButton.Click += ChangeMusicCenterButtonClick;
                Controls.Add(changeModeButton);
                Controls.Add(Span("<br />"));
            }

            if (devDictionary[id] is IChangeCD)
            {
                Controls.Add(Span("Change CD: " + "<br />"));
                changeCDButton = new Button();
                changeCDButton.ID = "mcc" + id.ToString();
                changeCDButton.Text = "Change CD";
                changeCDButton.Click += ChangeCDButtonClick;
                Controls.Add(changeCDButton);
                Controls.Add(Span("<br />"));
            }

            if (devDictionary[id] is IDeviceChangeMode)
            {
                Controls.Add(Span("Change mode: " + "<br />"));
                aircondModeButton = new Button();
                aircondModeButton.ID = "acm" + id.ToString();
                aircondModeButton.Text = "Change mode";
                aircondModeButton.Click += ChangeModeAirConditioner;
                Controls.Add(aircondModeButton);
                Controls.Add(Span("<br />"));
            }

            if (devDictionary[id] is ITemperature)
            {

                Controls.Add(Span("Temperature: " + "<br />"));
                airconditionerTemperatoreDownButton = new Button();
                airconditionerTemperatoreDownButton.ID = "u" + id.ToString();
                airconditionerTemperatoreDownButton.Text = "Temperature -";
                airconditionerTemperatoreDownButton.Click += TemperatureDownAirConditioner;
                Controls.Add(airconditionerTemperatoreDownButton);
                Controls.Add(Span("&nbsp"));
                airconditionerTemperatoreUPButton = new Button();
                airconditionerTemperatoreUPButton.ID = "d" + id.ToString();
                airconditionerTemperatoreUPButton.Text = "Temperature +";
                airconditionerTemperatoreUPButton.Click += TemperatureUpAirConditioner;
                Controls.Add(airconditionerTemperatoreUPButton);
                Controls.Add(Span("<br />"));
            }


            if (devDictionary[id] is IDoorOpen)
            {
                Controls.Add(Span("Front door: " + "<br />"));
                DoorOCButton = new Button();
                DoorOCButton.ID = "r" + id.ToString();
                DoorOCButton.Text = "Open";
                if ((devDictionary[id] as IDoorOpen).DoorState == false)
                {
                    DoorOCButton .Click+= DoorOpenButtonClick;
                }
                else if ((devDictionary[id] as IDoorOpen).DoorState == true)
                {
                    DoorOCButton.Click += DoorCloseButtonClick;
                    DoorOCButton.Text = "Close";
                }
                Controls.Add(DoorOCButton);
                Controls.Add(Span("<br />"));
            }


            if (devDictionary[id] is IFrostdoorOpen)
            {
                Controls.Add(Span("Frost door: " + "<br />"));
                FrostDoorOpenButton = new Button();
                FrostDoorOpenButton.ID = "fdo" + id.ToString();
                FrostDoorOpenButton.Text = "Open";
                Controls.Add(Span("&nbsp"));
                warning = new Label();
                warning.Text = "";
                if ((devDictionary[id] as IFrostdoorOpen).FrostDoorState == false)
                {
                    if ((devDictionary[id] as IDoorOpen).DoorState == false)
                    {
                        warning.Text = "You cannot open frost door when front door is closed";
                    }
                    FrostDoorOpenButton.Click += FrostDoorOpenButtonClick;
                }
                else if ((devDictionary[id] as IDoorOpen).DoorState == true)
                {
                    FrostDoorOpenButton.Click += FrostDoorCloseButtonClick;
                    FrostDoorOpenButton.Text = "Close";
                }
                Controls.Add(FrostDoorOpenButton);
                Controls.Add(Span("&nbsp"));
                warning = new Label();
                warning.Text = "";

                Controls.Add(Span("<br />"));

            }

            Controls.Add(Span("<br />"));

            deleteButton = new Button();
            deleteButton.ID = "del" + id.ToString();
            deleteButton.Text = "Delete";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);


        }

        
        /////////////////////////////ON\OFF///////////////////////////////////////

        protected void OffButtonClick(object sender, EventArgs e)
        {
            devDictionary[id].Off();
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            stateButton.Text = "ON";
        }

        protected void OnButtonClick(object sender, EventArgs e)
        {
            devDictionary[id].On();
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            stateButton.Text = "OFF";
        }
        /////////////////////////////VOLUME///////////////////////////////////////
        protected void VolumeUpButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IVolume)
            {
                ((IVolume)devDictionary[id]).UpVolume();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void VolumeDownButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IVolume)
            {
                ((IVolume)devDictionary[id]).DownVolume();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        /////////////////////////////RadioCannnelCahnge///////////////////////////////////////

        protected void RadioChanelUPButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IRadioChannel)
            {
                ((IRadioChannel)devDictionary[id]).NextChannal();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void RadioChanelDownButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IRadioChannel)
            {
                ((IRadioChannel)devDictionary[id]).PrevChannel();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        /////////////////////////////TVCannnelCahnge///////////////////////////////////////

        protected void TVChanelDownButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is ITVChangeChannel)
            {
                ((ITVChangeChannel)devDictionary[id]).PrevChannel();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void TVChanelUPButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is ITVChangeChannel)
            {
                ((ITVChangeChannel)devDictionary[id]).NextChannal();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        ////////////////////MusicCenetrFuncional//////////////////////////////
        protected void ChangeCDButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IChangeCD)
            {
                ((IChangeCD)devDictionary[id]).NextCD();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void ChangeMusicCenterButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IMusicCenterMode)
            {
                ((IMusicCenterMode)devDictionary[id]).ChangeMode();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        ////////////////////////////AirConditioner////////////////////////////

        protected void ChangeModeAirConditioner (object sender, EventArgs e)
        {
            if (devDictionary[id] is IDeviceChangeMode)
            {
                ((IDeviceChangeMode)devDictionary[id]).ChangeMode();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }


        protected void TemperatureUpAirConditioner(object sender, EventArgs e)
        {
            if (devDictionary[id] is ITemperature)
            {
                ((ITemperature)devDictionary[id]).UpTemperature();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void TemperatureDownAirConditioner(object sender, EventArgs e)
        {
            if (devDictionary[id] is ITemperature)
            {
                ((ITemperature)devDictionary[id]).DownTemperature();
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        /////////////////////////////////Refregerator////////////////////////

        protected void DoorOpenButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IDoorOpen)
            {
                    ((IDoorOpen)devDictionary[id]).RefrigeratDoorOpen();
                    DoorOCButton.Text = "Close";
                    info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void DoorCloseButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IDoorOpen)
            {
                ((IDoorOpen)devDictionary[id]).RefrigeratDoorClose();
                DoorOCButton.Text = "Open";
                info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void FrostDoorOpenButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IFrostdoorOpen)
            {
                ((IFrostdoorOpen)devDictionary[id]).FrostDoorStateOpen();
                FrostDoorOpenButton.Text = "Close";
                info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        }

        protected void FrostDoorCloseButtonClick(object sender, EventArgs e)
        {
            if (devDictionary[id] is IFrostdoorOpen)
            {
                ((IFrostdoorOpen)devDictionary[id]).FrostDoorStateClose();
                FrostDoorOpenButton.Text = "Open";
                info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
            }
            info.Text = "Device: " + devDictionary[id].ToString() + "<br />";
        } 

        

        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }


        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            devDictionary.Remove(id); 
            Parent.Controls.Remove(this); 
        }
    }

    
}