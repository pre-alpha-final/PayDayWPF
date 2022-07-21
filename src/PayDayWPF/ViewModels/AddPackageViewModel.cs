﻿using System.Threading.Tasks;
using System.Windows.Input;
using PayDayWPF.Infrastructure;
using PayDayWPF.Persistence;

namespace PayDayWPF.ViewModels
{
    public class AddPackageViewModel : ViewModelBase
    {
        private readonly IRepository _repository;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private decimal _meetingProfit;
        public decimal MeetingProfit
        {
            get => _meetingProfit;
            set
            {
                _meetingProfit = value;
                OnPropertyChanged();
            }
        }

        private int _meetingCount;
        public int MeetingCount
        {
            get => _meetingCount;
            set
            {
                _meetingCount = value;
                OnPropertyChanged();
            }
        }

        public AddPackageViewModel(IRepository repository)
        {
            _repository = repository;
        }

        public ICommand AddCommand => new RelayCommand(_ =>
        {
            Task.Run(() => _repository.AddPackage(new Package
            {
                Name = Name,
                Duration = Duration,
                MeetingProfit = MeetingProfit,
                MeetingCount = MeetingCount
            }));
        });
    }
}
