using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace servico_aluno.Infrastructure;

public class DatabaseConnection
{
    private readonly string connectionString;

    public DatabaseConnection()
    {
        this.connectionString = Environment.GetEnvironmentVariable("ALUNO_CONNECTION_DB");
    }

    // Método para abrir uma conexão com o banco de dados
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    // Método para consultar dados do banco usando Dapper
    public IEnumerable<T> Query<T>(string sql, object? parameters = null)
    {
        using IDbConnection connection = GetConnection();
        try
        {
            connection.Open();
            return connection.Query<T>(sql, parameters);
        }
        finally
        {
            connection.Close();
        }
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        using MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            return await connection.QueryAsync<T>(sql, parameters);
        }
        finally
        {
            connection.Close();
        }
    }

    // Método para executar um comando de inserção, atualização ou exclusão no banco usando Dapper
    public int Execute(string sql, object? parameters = null)
    {
        using IDbConnection connection = GetConnection();
        try
        {
            connection.Open();
            return connection.Execute(sql, parameters);
        }
        finally
        {
            connection.Close();
        }

    }

    public async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null)
    {
        using MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            return await connection.ExecuteScalarAsync<T>(sql, parameters);  
        }
        finally
        {
            connection.Close();
        }

    }
}
