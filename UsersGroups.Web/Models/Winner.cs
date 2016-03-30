namespace UsersGroups.Web.Models
{
    public class Winner
    {
        public int WinnerId { get; set; }
        public int AttendeeId { get; set; }
        public int MeetingId { get; set; }
        public int PrizeId { get; set; }


        public virtual Attendee Attendee { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual Prize Prize { get; set; }
    }
}