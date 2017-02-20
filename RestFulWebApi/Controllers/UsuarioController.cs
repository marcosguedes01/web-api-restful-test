using RestFulWebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFulWebApi.Controllers
{
    [RoutePrefix("api")]
    public class UsuarioController : ApiController
    {

        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [HttpPost]
        //[AcceptVerbs("POST")]
        [Route("usuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            if (!String.IsNullOrEmpty(usuario.Nome))
            {
                listaUsuarios.Add(usuario);
                return "Usuário cadastrado com sucesso!";
            }
            else
            {
                return "Entrada de dados inválida.";
            }
        }

        [HttpPut]
        //[AcceptVerbs("PUT")]
        [Route("usuario")]
        public string AlterarUsuario(UsuarioModel usuario)
        {

            listaUsuarios.Where(n => n.Codigo == usuario.Codigo)
                         .Select(s =>
            {
                s.Codigo = usuario.Codigo;
                s.Login = usuario.Login;
                s.Nome = usuario.Nome;

                return s;

            }).ToList();



            return "Usuário alterado com sucesso!";
        }

        [HttpDelete]
        //[AcceptVerbs("DELETE")]
        [Route("usuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {

            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listaUsuarios.Remove(usuario);

            return "Registro excluido com sucesso!";
        }

        [HttpGet]
        //[AcceptVerbs("GET")]
        [Route("usuario/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {

            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return usuario;
        }

        [HttpGet]
        //[AcceptVerbs("GET")]
        [Route("usuario")]
        public IList ConsultarUsuarios() // Aqui havia apenas List
        {
            return listaUsuarios;
        }
    }
}