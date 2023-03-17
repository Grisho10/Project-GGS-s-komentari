using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    class NoteDate 
    {
        public List<Note> GetAll()
        {
            var noteList = new List<Note>(); //  sazadavame prazen list kudeto shte se zaisvat 
            using (var connection = Database.GetConnection()) //pravim promenliva connection i svarzvame bazata danni s metoda sa zvarzvane
            {
                var command = new SqlCommand("SELECT * FROM note", connection); // pravim promenliva za comandite i selectirame-izbirame vsichko ot note-tablicata, vruzkata
                connection.Open();  //vruzkata se otvarq
                using (var reader = command.ExecuteReader()) // nova promenliva koqto shte chete comandite
                
                {
                    while (reader.Read()) // izpulnqva se dokato
                    {
                        var product = new Note(  // nova promenliva product t.e. belejkata q vzimame ot NOTE(kudeto sa sazdadeni kolonite)
                            reader.GetInt32(0),  //nadolu sa parametrite ot konstruktora, kato sa poisledovatelni vs
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3)
                        );

                        noteList.Add(product);    // nakraq se dobavq
                    }
                }
                connection.Close(); //vruzkata se zatvarq
            }
            return noteList;  //belejkata se vrushta veche pulna, a q bqhme saszadali gore-prazna
        }   
        public Note Get(int id)
        {
            Note note = null; //null e za da moje da vkarame stoinosti, ako ima nqma da e null, no to nqma da ima
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM note WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id); // kogat0 iskame da pravim neshto sus stoinostite na parametrite vinagi izpolzvame addwithvalue
                connection.Open();
                using (var reader = command.ExecuteReader()) //NE ZNAEM
                {
                    if (reader.Read()) //na vseki metod na novo se suzdava reader i e tazi promenliva.metoda
                    {
                        note = new Note(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3)
                        );
                    }
                }
                connection.Close();
            }
            return note;
        }
        public void Add(Note note) //tova note e razlichno ot gornoto note zashtoto za v razlichni metodi, a Note si ni e klasa
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO note (Title, Description, Level) VALUES(@title, @description, @level)", connection);
                command.Parameters.AddWithValue("title", note.Title);
                command.Parameters.AddWithValue("description", note.Description);
                command.Parameters.AddWithValue("level", note.Level);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(Note note)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE note SET Title=@title, Description=@description, Level=@level WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", note.Id);
                command.Parameters.AddWithValue("title", note.Title);
                command.Parameters.AddWithValue("description", note.Description);
                command.Parameters.AddWithValue("level", note.Level);
                connection.Open();
                command.ExecuteNonQuery(); // NE ZNAEM
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE note WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
