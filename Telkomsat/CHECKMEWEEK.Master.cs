﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class CHECKMEWEEK : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 2];
            if (thisURL.ToLower() == "week/") divweek.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "month/") divmonth.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "semester/") divsemester.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "year/") divyear.Attributes.Add("class", "small-box bg-aqua-gradient");
        }
    }
}