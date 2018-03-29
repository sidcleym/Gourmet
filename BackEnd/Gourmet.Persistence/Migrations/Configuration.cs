using Gourmet.Domain.Models;
using Gourmet.Persistence.Infra;
using Gourmet.Shared.Utils;
using System;
using System.Data.Entity.Migrations;

namespace Gourmet.Persistence.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.Usuario.AddOrUpdate(new Usuario() { Nome="Sidcley Mendes", Email="sidcleym@gmail.com", SenhaCriptografada = CriptografiaHelper.CriptografarSenha("123456"), DtInclusao = DateTime.Now });
            //context.Prato.AddOrUpdate(new Prato() { Nome = "Sidcley Mendes", Email = "sidcleym@gmail.com",  DtInclusao = DateTime.Now });
            //context.Restaurante.AddOrUpdate(new Restaurante() { Descricao = "Street Figther", Ano=1998, DtInclusao = DateTime.Now });
        }
    }
}
