using HKBlog.Database;
using HKBlog.Models;
using Newtonsoft.Json;

namespace HKBlog.UI.Data
{
    public class AdsControl
    {
        public List<Slides> AdsList { get; set; } = new();
        private readonly IDatabase database;
        public AdsControl(IDatabase database) 
        {
            this.database = database;
        }
        public async Task<bool> AddAds(Slides ad)
        {
            string key = JsonConvert.SerializeObject(ad.Id);
            string value = JsonConvert.SerializeObject(ad);
            bool isAdded = await database.Create("Ads", key, value);
            return isAdded;
        }
        public async Task GetAds()
        {
            List<Slides> ads = new List<Slides>();
            var data = await database.ReadAll("Ads");
            if (data != null && data.Count() > 0)
            {
                foreach (var ad in data)
                {
                    var a = JsonConvert.DeserializeObject<Slides>(ad.Value);
                    if (a != null)
                    {
                        ads.Add(a);
                    }
                }
                AdsList = ads.OrderByDescending(a => a.Date).ToList();
            }
        }
        public async Task<bool> CreateAdsTracker(AdsTracker adsTracker)
        {
            string key = JsonConvert.SerializeObject(adsTracker.Id);
            string value = JsonConvert.SerializeObject(adsTracker);
            bool isAdded = await database.Create("AdsTracker", key, value);
            return isAdded;
        }
        public async Task<List<AdsTracker>> GetAllAdsTrackers()
        {
            List<AdsTracker> ads = new List<AdsTracker>();
            var data = await database.ReadAll("AdsTracker");
            if (data != null && data.Count() > 0)
            {
                foreach (var ad in data)
                {
                    var a = JsonConvert.DeserializeObject<AdsTracker>(ad.Value);
                    if (a != null)
                    {
                        ads.Add(a);
                    }
                }
                 ads.OrderByDescending(a => a.Date).ToList();
            }
            return ads;
        }
        public async Task<bool> DeleteAds(string id)
        {
            var isDel = await database.Delete("Ads", JsonConvert.SerializeObject(id));
            return isDel;
        }
    }
}
