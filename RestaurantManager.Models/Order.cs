using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public class Order : INotifyPropertyChanged
    {
        [Key]
        private int id;
        public int Id { get { return id; } set { if (value != id) { id = value; OnPropertyChanged(); } } }

        public string SpecialRequests { get; set; }

        public List<MenuItem> Items { get; set; }

        public Table Table { get; set; }

        public bool Complete { get; set; }

        public bool Expedite { get; set; }

        public override string ToString()
        {
            return String.Join(", ", Items.Select(i => i.Title));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
