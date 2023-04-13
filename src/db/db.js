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
    const stmt = `SELECT pokemonid, name, sprite FROM Pokemon`;
    pool.query(stmt, callback);
}

function GetFilteredPokemon(values, callback) 
{
    //Add sprite later
    filterparams = [];

    let typestmt = '';
    if(values[0] != 'NULL')
    {
        typestmt = `P2.attacktype = ?`;
        filterparams.push(values[0]);
    }

    let stylestmt = '';
    if(values[1] != 'NULL')
    {
        stylestmt = `P2.attackstyle = ?`;
        filterparams.push(values[1]);
    }

    let rolestmt = '';
    if(values[2] != 'NULL')
    {
        rolestmt = `P2.role = ?`;
        filterparams.push(values[2]);
    }

    let complexstmt = '';
    if(values[3] != 'NULL')
    {
        complexstmt = `P2.complexity = ?`;
        filterparams.push(values[3]);
    }

    // const whereClause = `(${typestmt}) AND (${stylestmt}) AND (${rolestmt}) AND (${complexstmt})`;
    // const whereClause = `${typestmt ? '(' + typestmt + ')' : ''} ${stylestmt ? 'AND (' + stylestmt + ')' : ''} ${rolestmt ? 'AND (' + rolestmt + ')' : ''} ${complexstmt ? 'AND (' + complexstmt + ')' : ''}`;
    const whereClause = `${typestmt ? '(' + typestmt + ')' : ''} ${stylestmt ? (typestmt ? 'AND ' : '') + 
    '(' + stylestmt + ')' : ''} ${rolestmt ? ((typestmt || stylestmt) ? 'AND ' : '') + '(' + rolestmt + ')' : ''} 
    ${complexstmt ? ((typestmt || stylestmt || rolestmt) ? 'AND ' : '') + '(' + complexstmt + ')' : ''}`;
    console.log(whereClause);
    const basestmt = `SELECT P1.pokemonid, P1.name, P1.sprite FROM Pokemon P1 WHERE P1.pokemonid IN (SELECT P2.pokemonid FROM pokemon P2 WHERE ${whereClause})`;
    pool.query(basestmt, filterparams, callback);
}

function GetPokemon(values, callback)
{
    const stmt = `SELECT * FROM Pokemon INNER JOIN Stats ON Pokemon.pokemonid = Stats.ownerid 
    WHERE pokemonid = ? AND Stats.level = ?`;
    pool.query(stmt, values, callback);
}

function GetPokemonStats(values, callback)
{
    const stmt = `SELECT * FROM Pokemon INNER JOIN Stats ON Pokemon.pokemonid = Stats.ownerid WHERE pokemonid = ?`;
    pool.query(stmt, values, callback);
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

function GetAllHeldItems(callback)
{
    //Add sprite later
    const stmt = `SELECT heldid, name FROM HeldItem`;
    pool.query(stmt, callback);
}

function GetHeldItem(values, callback)
{
    const stmt = `SELECT * FROM HeldItem WHERE heldid = ?`;
    pool.query(stmt, values, callback);
}

function GetBuilds(values, callback)
{
    const stmt = `SELECT * FROM PokemonBuild WHERE ownerid = ?`;
    pool.query(stmt, values, callback);
}

function CreateBuild(values, callback)
{
    const stmt = `INSERT INTO PokemonBuild(ownerid, name, move1, move2, helditemid1, helditemid2, helditemid3, battleitemid) VALUES ROW (?, ?, ?, ?, ?, ?, ?, ?)`;
    pool.query(stmt, values, callback);
}

function DeleteBuild(values, callback)
{
    const stmt = `DELETE FROM PokemonBuild WHERE buildid = ?`;
    pool.query(stmt, values, callback);
}

function UpdateBuild(values, callback)
{
    let stmt = `UPDATE PokemonBuild SET`;
    updated = [];

    for(let key in values)
    {
        if(values[key] && key != "buildid")
        {
            updated.push(`${key} = ${pool.escape(values[key])}`);
        }
    }

    stmt += " " + updated.join(", ") + " WHERE buildid = ?";
    pool.query(stmt, values["buildid"], callback);
}

module.exports = 
{
    AllPokemon: GetAllPokemon,
    FilteredPokemon: GetFilteredPokemon,
    OnePokemon: GetPokemon,
    OnePokemonAllStats: GetPokemonStats,
    AllBattle: GetAllBattleItems,
    OneBattle: GetBattleItem,
    AllHeld: GetAllHeldItems,
    OneHeld: GetHeldItem,
    Builds: GetBuilds,
    CreateBuild,
    DeleteBuild,
    UpdateBuild
}