using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace SampleEcommerce.Moblie.Abstractions
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public INavigationService NavigationService;
        protected IDialogService DialogService;

        private bool _isBusy;
        private string _title;

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        private IObservable<Exception> _thrownExceptions;
        protected void CatchObservableExceptions(params IHandleObservableErrors[] commands)
        {
            _thrownExceptions = _thrownExceptions == null ? MergeExceptionObservable(commands) : _thrownExceptions.Merge(MergeExceptionObservable(commands));
            _thrownExceptions.Subscribe(OnShowErrorMessage);
        }
        private IObservable<Exception> MergeExceptionObservable(params IHandleObservableErrors[] handleObservableErrors) =>
            handleObservableErrors.Select(errors => errors.ThrownExceptions).Merge();
        protected virtual void OnShowErrorMessage(Exception exception)
        {
            DialogService.ShowMessage("Something went wrong", exception.GetBaseException().Message);
        }
        protected IObservable<TSouse> OnObservableErrorMessage<TSouse>(Exception exception)
        {
            OnShowErrorMessage(exception);
            return Observable.Empty(default(TSouse));
        }
        protected BaseViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }
        public virtual Task ViewAppearing()
        {
            return Task.CompletedTask;
        }
        public virtual Task ViewDisappearing()
        {
            return Task.CompletedTask;
        }
    }
}
