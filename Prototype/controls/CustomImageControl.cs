using Xamarin.Forms;
using Prototype.models;


namespace Prototype.controls
{
    public class CustomImageControl : Image
    {
        private Detail detail;

        public void setDetail(Detail detail)
        {
            this.detail = detail;
        }

        public Detail getDetail()
        {
            return detail;
        }
    }
}
