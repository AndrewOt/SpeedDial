using System;
using Newtonsoft.Json;

namespace SpeedDial
{
    class Settings
    {
        //stored links
        private string Link1;
        private string Link2;
        private string Link3;
        private string Link4;
        private string Link5;
        private string Link6;
        private string Link7;
        private string Link8;
        private string Link9;
        private string Link0;
        // If set to true, this will allow the display of error messages when a user
        // calls a link that does not have any value. If this is false, it will supress
        // the warning.
        private bool _ShowError = true;

        public string Link_1
        {
            get
            {
                if (Link1 != null)
                    return Link1;
                throw new NullReferenceException("Link1 is empty!");
            }
            set => Link1 = value;
        }
        public string Link_2
        {
            get
            {
                if (Link2 != null)
                    return Link2;
                throw new NullReferenceException("Link2 is empty!");
            }
            set => Link2 = value;
        }
        public string Link_3
        {
            get
            {
                if (Link3 != null)
                    return Link3;
                throw new NullReferenceException("Link3 is empty!");
            }
            set => Link3 = value;
        }
        public string Link_4 { get
            {
                if (Link4 != null)
                    return Link4;
                throw new NullReferenceException("Link4 is empty!");
            }
            set => Link4 = value; }
        public string Link_5 {
            get
            {
                if (Link5 != null)
                    return Link5;
                throw new NullReferenceException("Link5 is empty!");
            }
            set => Link5 = value; }
        public string Link_6 {
            get
            {
                if (Link6 != null)
                    return Link6;
                throw new NullReferenceException("Link6 is empty!");
            }
            set => Link6 = value; }
        public string Link_7 {
            get
            {
                if (Link7 != null)
                    return Link7;
                throw new NullReferenceException("Link7 is empty!");
            }
            set => Link7 = value; }
        public string Link_8 {
            get
            {
                if (Link8 != null)
                    return Link8;
                throw new NullReferenceException("Link8 is empty!");
            }
            set => Link8 = value; }
        public string Link_9 {
            get
            {
                if (Link9 != null)
                    return Link9;
                throw new NullReferenceException("Link9 is empty!");
            }
            set => Link9 = value; }
        public string Link_0 {
            get
            {
                if (Link0 != null)
                    return Link0;
                throw new NullReferenceException("Link0 is empty!");
            }
            set => Link0 = value; }

        public bool ShowError { get => _ShowError; set => _ShowError = value; }

    }
}
