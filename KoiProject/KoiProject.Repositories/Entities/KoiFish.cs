namespace KoiProject.Repositories.Entities
{
    public class KoiFish
    {
        public int KoiId { get; set; }
        public string KoiName { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal SizeCm { get; set; }
        public string FengShuiMeaning { get; set; }
        public string SuitableForBmenh { get; set; }

        // Các mối quan hệ khác nếu có
        public virtual ICollection<KoiOwnership> KoiOwnerships { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
    }
}
