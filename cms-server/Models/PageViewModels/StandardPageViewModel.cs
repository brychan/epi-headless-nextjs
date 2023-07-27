using Models.PageTypes;

namespace Models.PageViewModels
{
    public class StandardPageViewModel
    {
        private readonly StandardPageTypeModel _standardPageType;

        public StandardPageViewModel(StandardPageTypeModel standardPageType)
        {
            this._standardPageType = standardPageType;
        }
        public string Heading => _standardPageType.Heading;

        public string Link { get; set; }
    }
}