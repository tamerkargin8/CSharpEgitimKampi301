using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x=> x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAverageCapacity.Text = db.Location.Average(x => x.LocationCapacity).Value.ToString("F0");
            lblAverageLocationPrice.Text = db.Location.Average(x => x.LocationPrice).Value.ToString("F2") + " TL ";
            #region Hocanın Son Eklenen Ülke İçin Yazdığı Kodlar
            //int lastCountryId = db.Location.Max(x => x.LocationId);
            //lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(Select => Select.LocationCountry).FirstOrDefault();
            #endregion
            lblLastCountryName.Text = db.Location.OrderByDescending(x => x.LocationId).FirstOrDefault().LocationCountry;
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(x => x.LocationCapacity).FirstOrDefault().ToString();
            lblTurkeyAverageCapacity.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(x => x.LocationCapacity).Value.ToString("F0");
            lblRomeGuideName.Text = db.Location
                .Where(x => x.LocationCity == "Roma")
                .Select(x => new { x.GuideId, GuideName = x.Guide.GuideName, GuideSurname = x.Guide.GuideSurname })
                .FirstOrDefault()?.GuideName + " " +
                db.Location.Where(x => x.LocationCity == "Roma")
                .Select(x => x.Guide.GuideSurname)
                .FirstOrDefault();
            #region Hocanın Yazdığı Roma Gezisi Rehber adı Bulma
            var romeGuideId = db.Location.Where(x => x.LocationCity == "Roma").Select(x => x.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(x => x.GuideName + " " + x.GuideSurname).FirstOrDefault();
            #endregion
            #region Hocanın Yazdığı En Fazla Kapasiteli Tur
            //var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            //lblMaxCapacityTour.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(x => x.LocationCity).FirstOrDefault();
            #endregion
            lblMaxCapacityTour.Text = db.Location.Where(x => x.LocationCapacity == db.Location.Max(y => y.LocationCapacity)).Select(x => x.LocationCity).FirstOrDefault();
            #region Hocanın Yazdığı En Fazla Fiyatlı Tur
            //var maxPrice = db.Location.Max(x => x.LocationPrice);
            //lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(x => x.LocationPrice).FirstOrDefault();
            #endregion
            lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == db.Location.Max(y => y.LocationPrice)).Select(x => x.LocationCity).FirstOrDefault();

            var maxTourGuideId = db.Location
                .GroupBy(x => x.GuideId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            lblHaveMaxTourGuideNameSurname.Text = db.Guide
                .Where(g => g.GuideId == maxTourGuideId)
                .Select(g => g.GuideName + " " + g.GuideSurname)
                .FirstOrDefault();
        }
    }
}
