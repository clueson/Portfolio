using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;

namespace TravelTutorial.Helpers
{
    class TestClass
    {

        private delegate void TestDel(string thetestsring);
        private delegate void Thevent(object sender, EventArgs e);
        //private delegate void Secondevent(object sender, EventArgs e);
        private event Thevent Theventraised;
        private EventHandler SecondEvent;

        public TestClass()
        {
            //default constructor

        }

        public TestClass(string themessage)
        {
            //creates a delegate instance and assigns the target
            TestDel thedelegate = new TestDel(ReceiveDelegate);
            //using the delegate
            thedelegate(themessage);
        }


        private void ReceiveDelegate(string thename)
        {
            string thereceivedmeassage = thename;
            Theventraised += new Thevent(EventReceivedEvent);
        }

        private void EventReceivedEvent(object sender, EventArgs e)
        {
            Theventraised -= new Thevent(EventReceivedEvent);
            SecondEvent += new EventHandler(TheSecondEvent);

        }

        private void TheSecondEvent(object sender, EventArgs e)
        {

        }
    }
}
