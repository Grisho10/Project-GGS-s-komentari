using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class NoteCreate
    {
        private NoteDate general = new NoteDate();

        public List<Note> GetAll()
        {
            return general.GetAll();
        }
        public Note Get(int id)
        {
            return general.Get(id);
        }
        public void Add(Note note)
        {
            general.Add(note);
        }
        public void Update(Note note)
        {
            general.Update(note);
        }
        public void Delete(int id)
        {
            general.Delete(id);
        }
    }
}
