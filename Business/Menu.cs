using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Tipo { get; set; }
        public int Quantidade { get; set; }

        public List<Menu> Lista()
        {
            // Inicializa a lista Menu, que contém os dados da tabela menuSB
            var lista = new List<Menu>();
            var menuDb = new Database.Menu();
            foreach (DataRow row in menuDb.Lista().Rows)
            {
                var menu = new Menu();
                menu.Id = Convert.ToInt32(row["id"]);
                menu.Nome = row["nome"].ToString();
                menu.Descricao = row["descricao"].ToString();
                menu.Tipo = Convert.ToBoolean(row["tipo"]);

                lista.Add(menu);
            }

            return lista;
        }
    }
}
