using System;
//Matheus Penteado CB3031501
//Joao Victor Sinopolli 3032094

namespace TP01
{
    internal class Author
    {
        private string name;
        private string email;
        private char gender;

        // Construtor
        internal Author(string name, string email, char gender)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
        }

        // Getters e Setters
        internal string GetName() => name;
        internal string GetEmail() => email;
        internal char GetGender() => gender;
        internal void SetEmail(string email) => this.email = email;

        // Formatação textual exigida no diagrama
        public override string ToString()
        {
            return $"Author[name={name},email={email},gender={gender}]";
        }
    }
}