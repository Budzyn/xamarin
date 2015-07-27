using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;
using System.IO;
using System.Net;

namespace Books.Core.ViewModels
{
    /// <summary>
    /// TODO implement Details view model to download and hold detail information about the book
    /// Also you need to implement views for each platform for this model
    /// </summary>
    public class DetailsViewModel 
        : MvxViewModel
    {
        private readonly IBooksService _books;

        public DetailsViewModel(IBooksService books)
        {
            _books = books;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            // TODO get and cast incomming bundle to the parameter passed from FirstViewModel
            // details here
            // https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation


            WebRequest req = WebRequest.Create("https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            ShowViewModel<FirstViewModel>();
            base.InitFromBundle(parameters);
        }
    }
}
