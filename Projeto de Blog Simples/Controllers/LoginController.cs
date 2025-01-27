using Projeto_de_Blog_Simples.Models;
using Projeto_de_Blog_Simples;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Dapper;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Linq;
using System;

namespace Projeto_de_Blog_Simples.Controllers
{
    public class LoginController : Controller
    {
        private RegisterUsers _registerUsers;
        private CreatePosts _createPosts;

        public LoginController()
        {
            _registerUsers = new RegisterUsers();
            _createPosts = new CreatePosts();  // Adicionando a instância de CreatePosts
        }

        // Método GET para renderizar a página de login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Método POST para processar o login
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta o usuário no banco de dados
                var query = "SELECT * FROM Users WHERE Username = @Username";
                var user = connection.QueryFirstOrDefault<Users>(query, new { Username });

                // Verifica se o usuário existe e a senha está correta
                if (user != null && user.PasswordHash == Password)
                {
                    Session["UserId"] = user.Id;
                    Session["Username"] = user.Username;

                    TempData["UserName"] = user.Username;
                    TempData["SuccessMessage"] = "Você está logado com sucesso!";

                    return RedirectToAction("Index", "Login");
                }
            }

            TempData["ErrorMessage"] = "Usuário ou senha inválidos!";
            return View();
        }

        // Método para renderizar a página de registro
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Método para processar o cadastro
        [HttpPost]
        public ActionResult Register(string NewUsername, string NewPassword)
        {
            if (_registerUsers.IsUsernameExists(NewUsername))
            {
                TempData["ErrorMessage"] = "Nome de usuário já está em uso. Por favor, escolha outro.";
                return View("Login");
            }

            _registerUsers.RegisterNewUser(NewUsername, NewPassword);

            TempData["SuccessMessage"] = "Usuário cadastrado com sucesso! Faça login para continuar.";
            return View("Login");
        }

        [HttpGet]
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Posts";
                var posts = connection.Query<Post>(query).ToList();

                return View(posts);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(string Title, string Content)
        {
            try
            {
                var authorId = (int)Session["UserId"]; // Pega o AuthorId da sessão (usuário logado)

                // Chama a classe CreatePosts para adicionar o post
                _createPosts.AddPost(Title, Content, authorId);

                TempData["SuccessMessage"] = "Post adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Houve um erro ao adicionar o post. Tente novamente.";
                return RedirectToAction("Index");
            }
        }
    }
}
