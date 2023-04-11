const mysql = require('mysql2');
require("dotenv").config();

const pool = mysql.createPool({
    host: process.env.SQL_HOST,
    user: 'root',
    password: process.env.SQL_PASSWORD,
    port: process.env.PORT,
    database: process.env.SQL_DB,
    connectionLimit: 10,
    connectTimeout: 5000
});

function GetAllPokemon(callback) 
{
    const stmt = `SELECT name FROM Pokemon INNER JOIN Stats ON Pokemon.pokemonid = Stats.ownerid`;
    pool.query(stmt, callback);
}

function GetPokemon(id, callback)
{
    const stmt = `SELECT * FROM Pokemon WHERE pokemonid = ?`;
    pool.query(stmt, id, callback);
}

function GetAllBattleItems(callback)
{
    const stmt = `SELECT name FROM BattleItem`;
    pool.query(stmt, callback);
}

function GetBattleItem(id, callback)
{
    const stmt = `SELECT name FROM BattleItem WHERE battleid = ?`;
    pool.query(stmt, id, callback);
}

module.exports = 
{
    AllPokemon: GetAllPokemon,
    OnePokemon: GetPokemon,
    AllBattle: GetAllBattleItems,
    OneBattle: GetBattleItem
}