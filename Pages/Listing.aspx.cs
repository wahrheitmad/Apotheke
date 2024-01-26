using Apotheke.Models;
using Apotheke.Models.Repository;
using Apotheke.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace Apotheke.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 9;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterDrugs().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }
        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        public IEnumerable<Drug> GetDrugs()
        {
            return FilterDrugs()
                .OrderBy(g => g.DrugID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

       

        public string GetPath(Drug drug)
        {
            string path = Convert.ToBase64String(drug.ImageData);
            string imgSrc = String.Format("data:image/jpg;base64,{0}", path);
            return imgSrc;
        }


        private IEnumerable<Drug> FilterDrugs()
        {
            IEnumerable<Drug> drugs = repository.Drugs;
            string currentCategory = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            return currentCategory == null ? drugs :
                drugs.Where(p => p.Category == currentCategory);
        }
        
        public IEnumerable<Drug> GetSearchedDrugs()
        {
            string find = Store.find;
           
            return FilterDrugs()
                .Select(g => g)
                .Where(g => g.Name.Contains(find) || g.Producer.Name.Contains(find))
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        public string FindUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "search",
                    null).VirtualPath;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "search",
            //    null).VirtualPath;

            if (IsPostBack)
            {
                int selectedDrugID;
                if (int.TryParse(Request.Form["add"], out selectedDrugID))
                {
                    Drug selectedDrug = repository.Drugs
                        .Where(g => g.DrugID == selectedDrugID).FirstOrDefault();

                    if (selectedDrug != null)
                    {

                        SessionHelper.GetCart(Session).AddItem(selectedDrug, 1);
                        SessionHelper.Set(Session, SessionKey.RETURN_URL,
                            Request.RawUrl);

                        Response.Redirect(RouteTable.Routes
                            .GetVirtualPath(null, "cart", null).VirtualPath);
                    }
                }
            }
        }
    }
}