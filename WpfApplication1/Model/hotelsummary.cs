using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public class hotelsummary
    {
        private String Rate;
        private String ShortDescription;

        private String thumbnailUrl;
        public String id  { get; set; }

        public String name { get; set; }

        public String address1 { get; set; }

        public String city { get; set; }

        public String postalcode { get; set; }

        public String countrycode { get; set; }

        public String tripadvisorratingurl { get; set; }

        public String thumbnailurl { get { return thumbnailUrl.Replace("_t.", "_l."); } set { thumbnailUrl = "http://images.travelnow.com" + value; } }

        public String ratecurrencycode { get; set; }

        public String locationdescription { get; set; }

        // public String shortdescription { get { if (!String.IsNullOrEmpty(ShortDescription)) { ShortDescription.Substring(ShortDescription.IndexOf("br /&gt;") + 8); }; return ""; } set { ShortDescription = value; } }
        public String shortdescription { get; set;}

        public String lowrate { get { return ratecurrencycode + " " + Rate; } set { Rate = value; } }

    }
}
