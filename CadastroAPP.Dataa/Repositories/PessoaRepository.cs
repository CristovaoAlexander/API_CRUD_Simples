using CadastroAPP.Data.Contexts;
using CadastroAPP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPP.Data.Repositories
{
    public class PessoaRepository
    {
        public void Salvar(Pessoa pessoa)
        {
            //abre a conexao e faz atualizacao no banco
            using (var dataContext = new DataContext())
            {
                //gravar
                dataContext.Add(pessoa);
                dataContext.SaveChanges();
            }
        }
        public void Update(Pessoa pessoa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(pessoa);
                dataContext.SaveChanges();
            }
        }
        public void Delete(Pessoa pessoa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(pessoa);
                dataContext.SaveChanges();
            }
        }

        // retorna uma lista que contenha onome 
        public List<Pessoa> GetByNomeLista(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Pessoa>()
                    .Where(p => p.Nome.Contains(nome))
                    .ToList();
            }
        }      

        public Pessoa? GetById(Guid id)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Pessoa>()                   
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        ///  retorna apenas um nome contendo o trecho informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Pessoa? GetByNomeUm(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Pessoa>()
                    .Where(p => p.Nome.Contains(nome))
                    .FirstOrDefault();
            }
        }

        public List<Pessoa> GetAll()
        {
            using (var datacontext = new DataContext())
            {// retorna uma lista de PESSOA
                return datacontext //conexao banco
                    .Set<Pessoa>() //iforma tabela
                    .OrderBy(p => p.Nome)
                    .ToList(); //retorna uma lisa
            }
        }








    }
}
