using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class Note
    {
        /*sazdavame 
        private int id; pole
        public int Id metod
        {get { return id; } set { id = value; } }
        =>
        public int Id { get; set; }
        */
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level  { get; set; }

        public Note() //prazen konstruktor za da ne bugva
        {
        }
        public Note(int id, string title, string description, int level)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Level = level;
        }

    }
}
