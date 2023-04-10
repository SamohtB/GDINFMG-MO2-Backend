const mysql = require('mysql2');

const pool = mysql.createPool({
    host: process.env.SQL_HOST,
    user: 'root',
    password: process.env.SQL_PASSWORD,
    database: process.env.SQL_DB,
    connectionLimit: 10,
    connectTimeout: 5000
});

function GetAllPokemon(callback) 
{
    const stmt = `SELECT name FROM Pokemon`;
    pool.query(stmt, callback);
}

module.exports = 
{
    AllPokemon: GetAllPokemon,
}