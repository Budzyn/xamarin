using System.Collections.Generic;
using System.Windows.Input;
using Books.Core.Services;
using Cirrious.MvvmCross.ViewModels;
using System;

namespace Books.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private readonly IBooksService _books;

        public FirstViewModel(IBooksService books)
        {
            _books = books;
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; RaisePropertyChanged(() => SearchTerm); Update();
            }
        }

        private List<BookSearchItem> _results;
        public List<BookSearchItem> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
        }

        private void Update()
        {
            _books.StartSearchAsync(SearchTerm,
                result => Results = result.items,
                error => {});
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand
        {
            get
            {
                // TODO create a command that will navigate to details screen
                // it should be invoked on list item click
                // it should accept book id or url so that details screen can fetch additional info

                BookSearchItem ob = new BookSearchItem();
                ob.id = "";

                return null;
            }
        }
        
        /*private String getScreenOrientation()
        {
            if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_PORTRAIT)
                return "Портретная ориентация";
            else if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
                return "Альбомная ориентация";
            else
                return "";
        }*/

        private void showDetails(string url)
        {
            ShowViewModel<DetailsViewModel>(); // pass "reference to the book" here
        }
    }
}
