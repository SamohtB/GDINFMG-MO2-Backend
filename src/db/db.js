const mysql = require('mysql2');
require("dotenv").config();

const pool = mysql.createConnection({
    host: process.env.SQL_HOST,
    user: 'root',
    password: process.env.SQL_PASSWORD,
    database: process.env.SQL_DB,
});

function GetAllPokemon(callback) 
{
    //Add sprite later
    const stmt = `SELECT pokemonid, name FROM Pokemon`;
    results = pool.query(stmt, callback);
}

function GetPokemon(id, callback)
{
    const stmt = `SELECT * FROM Pokemon INNER JOIN Stats ON Pokemon.pokemonid = Stats.ownerid 
    WHERE pokemonid = ? AND Stats.level = ?`;
    pool.query(stmt, id, callback);
}

function GetAllBattleItems(callback)
{
    //Add sprite later
    const stmt = `SELECT battleid, name FROM BattleItem`;
    pool.query(stmt, callback);
}

function GetBattleItem(id, callback)
{
    const stmt = `SELECT * FROM BattleItem WHERE battleid = ?`;
    pool.query(stmt, id, callback);
}

module.exports = 
{
    AllPokemon: GetAllPokemon,
    OnePokemon: GetPokemon,
    AllBattle: GetAllBattleItems,
    OneBattle: GetBattleItem
}