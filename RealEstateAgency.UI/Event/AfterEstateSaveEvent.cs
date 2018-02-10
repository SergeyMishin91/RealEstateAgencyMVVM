using Prism.Events;

namespace RealEstateAgency.UI.Event
{
    public class AfterEstateSaveEvent: PubSubEvent<AfterEstateSavedEventArgs>
    {
    }

    public class AfterEstateSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
