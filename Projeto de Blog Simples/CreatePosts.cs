using Dapper;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto_de_Blog_Simples
{
    public class CreatePosts
    {
        public void AddPost(string title, string content, int authorId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var post = new
                {
                    Title = title,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    AuthorId = authorId
                };

                var query = "INSERT INTO Posts (Title, Content, CreatedAt, AuthorId) VALUES (@Title, @Content, @CreatedAt, @AuthorId)";
                connection.Execute(query, post);
            }
        }
    }
}
