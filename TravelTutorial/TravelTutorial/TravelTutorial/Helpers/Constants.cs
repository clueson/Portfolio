using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTutorial.Helpers
{
    public class Constants
    {
        #region fields
        //foursqaure api endpoint with placeholder values
        public const string Venue_Search = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        //client Id string variable from foursqaure api
        public const string CLIENT_ID = "3OQM33DWJTI55Q4R2ZIHQ3BHR1IOEACNZWX0TXECUE3KXFXS";
        //secret string from the foursqaure api
        public const string CLIENT_SECRET = "CRELF2ZQMXUGIXJCXJKO4VFG0VDRLND2TFUKGEW3KPWR4KAH";
        #endregion
    }
}
